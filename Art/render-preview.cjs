// Set NODE_PATH to a directory containing playwright and sharp before running.
const fs = require('fs');
const path = require('path');
const {pathToFileURL} = require('url');
const {chromium} = require('playwright');
const sharp = require('sharp');
const root = path.resolve(__dirname, '..');
const qa = path.join(root, '.build/preview-qa');
const lum = rgb => rgb.map(v=>v/255).map(v=>v<=.04045?v/12.92:((v+.055)/1.055)**2.4).reduce((s,v,i)=>s+v*[.2126,.7152,.0722][i],0);
const rgb = hex => hex.slice(1).match(/../g).map(v=>parseInt(v,16));
const ratio = (a,b) => (Math.max(a,b)+.05)/(Math.min(a,b)+.05);
const hue = ([r,g,b]) => { r/=255; g/=255; b/=255; const mx=Math.max(r,g,b), d=mx-Math.min(r,g,b); if(!d) return 0;
  const h = mx===r ? ((g-b)/d)%6 : mx===g ? (b-r)/d+2 : (r-g)/d+4; return (h*60+360)%360; };
(async()=>{
  fs.mkdirSync(qa,{recursive:true});
  const browser = await chromium.launch({executablePath: process.env.CHROME_PATH || 'C:/Program Files/Google/Chrome/Application/chrome.exe',headless:true,args:['--allow-file-access-from-files']});
  try {
    const page = await browser.newPage({viewport:{width:896,height:504},deviceScaleFactor:1});
    await page.goto(pathToFileURL(path.join(__dirname,'preview.html')).href);
    const config = await page.evaluate(()=>window.previewReady);
    const cdp = await page.context().newCDPSession(page); await cdp.send('DOM.enable'); await cdp.send('CSS.enable');
    const {root:dom} = await cdp.send('DOM.getDocument');
    const fonts = {}, bounds = {};
    for (const selector of ['h1','h1 .prefix','.version']) {
      const {nodeId} = await cdp.send('DOM.querySelector',{nodeId:dom.nodeId,selector});
      if (!nodeId) continue;
      fonts[selector] = (await cdp.send('CSS.getPlatformFontsForNode',{nodeId})).fonts;
      bounds[selector] = await page.locator(selector).boundingBox();
    }
    const output = path.join(root,'Mod/About/Preview.png');
    const png = await page.screenshot();
    await sharp(png).removeAlpha().png({compressionLevel:9}).toFile(output);
    await sharp(png).resize(268).png().toFile(path.join(qa,'thumbnail.png'));
    await page.evaluate(()=>document.body.classList.add('no-text'));
    const background = await page.screenshot();
    await sharp(background).toFile(path.join(qa,'background.png'));
    const {data,info} = await sharp(background).removeAlpha().raw().toBuffer({resolveWithObject:true});
    const contrast = {};
    for (const selector of ['h1','h1 .prefix']) {
      const b=bounds[selector], ink=lum(rgb(config.palette[selector==='h1 .prefix'?'inkSecondary':'inkPrimary']));
      let minimum=Infinity;
      for(let y=Math.floor(b.y);y<Math.ceil(b.y+b.height);y++) for(let x=Math.floor(b.x);x<Math.ceil(b.x+b.width);x++) {
        const i=(y*info.width+x)*3, bg=lum([...data.subarray(i,i+3)]);
        minimum=Math.min(minimum,ratio(ink,bg));
      }
      contrast[selector]=minimum;
    }
    contrast['.version']=ratio(lum(rgb(config.palette.accent)),lum(rgb(config.palette.badgeInk)));
    const p = config.palette;
    const separation = {
      inkSecondaryHue: Math.round(hue(rgb(p.inkSecondary))),
      accentHue: Math.round(hue(rgb(p.accent))),
      hueGap: Math.round(Math.min(Math.abs(hue(rgb(p.inkSecondary))-hue(rgb(p.accent))), 360-Math.abs(hue(rgb(p.inkSecondary))-hue(rgb(p.accent))))),
      luminanceContrastSecondaryVsAccent: ratio(lum(rgb(p.inkSecondary)),lum(rgb(p.accent)))
    };
    const report={...config,fonts,bounds,contrast,separation,bytes:fs.statSync(output).size};
    fs.writeFileSync(path.join(__dirname,'preview-qa.json'),JSON.stringify(report,null,2)+'\n');
    console.log(JSON.stringify(report,null,2));
    if(Object.values(contrast).some(v=>v<4.5)) throw new Error('Contrast below 4.5:1');
    if(report.bytes>=900000) throw new Error('Preview exceeds 900 KB');
    for(const boundsValue of Object.values(bounds)) if(boundsValue.x<0||boundsValue.y<0||boundsValue.x+boundsValue.width>896||boundsValue.y+boundsValue.height>504) throw new Error('Text outside frame');
    if(bounds['h1'].x+bounds['h1'].width > 816-24) throw new Error('Title closer than 24 px to the badge');
  } finally { await browser.close(); }
})().catch(e=>{console.error(e);process.exitCode=1;});
