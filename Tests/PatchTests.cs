using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Verse;

// Unit tests for a mod that ships no code.
//
// Every correction is a claim about what RimWorld's XML patcher will do to another mod's def.
// These tests make that claim executable: they build the shipped <Operation> blocks into the
// game's own PatchOperation objects and call Apply, in a console process, with no game running.
// That is the whole point - the same claim checked by the Pickle suite, minus the minutes and
// minus taking over the machine, so this is what runs on every change and Pickle is kept for
// what genuinely needs a live game.
//
// What is real here and what is a stand-in: the operations, their xpaths, their branch structure
// and their execution are RimWorld's. Only the documents they are applied to are ours - synthetic
// fixtures for the branch tests, and the installed source mods' actual def XML for the ones that
// matter most.
internal static class PatchTests
{
    private static int failures, passes;

    // An assertion that failed says everything in its message. Anything else is a fault in the
    // test itself or in what it is calling, and then only the stack says where.
    private sealed class AssertionException : Exception
    {
        public AssertionException(string message) : base(message) { }
    }

    private static void Test(string name, Action test)
    {
        try { test(); passes++; }
        catch (AssertionException e)
        {
            failures++;
            Console.WriteLine("FAIL  " + name);
            Console.WriteLine("      " + e.Message.Replace("\n", "\n      "));
        }
        catch (Exception e)
        {
            failures++;
            Console.WriteLine("ERROR " + name);
            Console.WriteLine("      " + e.ToString().Replace("\n", "\n      "));
        }
    }

    private static void Require(bool value, string because)
    {
        if (!value) throw new AssertionException(because);
    }

    private static void Equal<T>(T expected, T actual, string because)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException(because + ": expected <" + expected + ">, got <" + actual + ">");
    }

    private static string ModRoot => Program.Metadata("ModRoot");

    // One correction, as the shipped XML declares it.
    private sealed class Correction
    {
        public string SourceMod;     // the patch file's name, which is the source mod's packageId
        public string DefType;       // exactly as the xpath spells it, casing included
        public string DefName;
        public string TechLevel;
        public XmlNode Operation;

        // From the generated comment above the operation, "DefName : Industrial -> Medieval".
        // Independent of the XML below it, which is what makes it worth checking: the value the
        // operation writes comes from the same file, so asserting one against the other alone
        // would only say that the patch does what the patch says.
        public string CommentFrom;   // null when the source declared no techLevel ("(aucun)")
        public string CommentTo;
    }

    private static List<Correction> ReadCorrections()
    {
        var corrections = new List<Correction>();
        var dir = Path.Combine(ModRoot, "Patches");
        foreach (var file in Directory.GetFiles(dir, "*.xml").OrderBy(f => f))
        {
            var doc = new XmlDocument();
            doc.Load(file);
            var source = Path.GetFileNameWithoutExtension(file);
            foreach (XmlNode operation in doc.SelectNodes("Patch/Operation"))
            {
                string from = null, to = null;
                for (var sibling = operation.PreviousSibling; sibling != null; sibling = sibling.PreviousSibling)
                {
                    if (sibling.NodeType == XmlNodeType.Whitespace || sibling.NodeType == XmlNodeType.SignificantWhitespace) continue;
                    if (sibling.NodeType == XmlNodeType.Comment)
                    {
                        var m = System.Text.RegularExpressions.Regex.Match(sibling.Value.Trim(), @"^(\S+)\s*:\s*(.+?)\s*->\s*(\S+)$");
                        if (m.Success)
                        {
                            from = m.Groups[2].Value == "(aucun)" ? null : m.Groups[2].Value;
                            to = m.Groups[3].Value;
                        }
                    }
                    break;
                }

                var xpath = operation.SelectSingleNode("xpath").InnerText;
                var match = System.Text.RegularExpressions.Regex.Match(xpath, "^/Defs/([A-Za-z]+)\\[defName=\"([^\"]+)\"\\]$");
                Require(match.Success, source + ": unexpected outer xpath " + xpath);
                corrections.Add(new Correction
                {
                    SourceMod = source,
                    DefType = match.Groups[1].Value,
                    DefName = match.Groups[2].Value,
                    TechLevel = operation.SelectSingleNode("match/match/value/techLevel").InnerText,
                    Operation = operation,
                    CommentFrom = from,
                    CommentTo = to,
                });
            }
        }
        return corrections;
    }

    // Set a private field anywhere up the hierarchy. PatchOperation keeps xpath on
    // PatchOperationPathed and success on PatchOperation itself, so a single GetField on the
    // concrete type finds neither.
    private static void SetField(object target, string name, object value)
    {
        for (var type = target.GetType(); type != null; type = type.BaseType)
        {
            var field = type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field == null) continue;
            field.SetValue(target, value);
            return;
        }
        throw new Exception("No field " + name + " on " + target.GetType().Name);
    }

    // Build the game's own operation objects from the shipped XML, without the def loader, which
    // needs Unity. Execution below is RimWorld's PatchOperation.Apply, unchanged.
    private static PatchOperation ReadOperation(XmlNode node)
    {
        PatchOperation op;
        var className = node.Attributes["Class"].Value;
        switch (className)
        {
            case "PatchOperationConditional":
                op = new PatchOperationConditional();
                foreach (var branch in new[] { "match", "nomatch" })
                {
                    var child = node.SelectSingleNode(branch);
                    if (child != null) SetField(op, branch, ReadOperation(child));
                }
                break;
            case "PatchOperationReplace":
                op = new PatchOperationReplace();
                SetField(op, "value", new XmlContainer { node = node.SelectSingleNode("value") });
                break;
            case "PatchOperationAdd":
                op = new PatchOperationAdd();
                SetField(op, "value", new XmlContainer { node = node.SelectSingleNode("value") });
                break;
            default:
                throw new Exception("Unsupported patch class: " + className);
        }

        SetField(op, "xpath", node.SelectSingleNode("xpath").InnerText);

        // success decides what Apply returns when the xpath matches nothing. Every generated
        // operation says Always, which is exactly what makes an absent target harmless; reading it
        // from the XML rather than assuming it is what lets the "missing target" test mean anything.
        var success = node.SelectSingleNode("success");
        if (success != null)
        {
            var successType = typeof(PatchOperation).GetNestedType("Success", BindingFlags.Public | BindingFlags.NonPublic);
            SetField(op, "success", Enum.Parse(successType, success.InnerText));
        }
        return op;
    }

    private static XmlDocument Fixture(string defType, string defName, string existingTechLevel)
    {
        var doc = new XmlDocument();
        var level = existingTechLevel == null ? "" : "<techLevel>" + existingTechLevel + "</techLevel>";
        doc.LoadXml("<Defs><" + defType + "><defName>" + defName + "</defName><label>fixture</label>" +
                    level + "</" + defType + "></Defs>");
        return doc;
    }

    private static string TechLevelIn(XmlDocument doc, string defType, string defName)
    {
        var nodes = doc.SelectNodes("/Defs/" + defType + "[defName=\"" + defName + "\"]/techLevel");
        Equal(1, nodes.Count, defName + " should end with exactly one techLevel");
        return nodes[0].InnerText;
    }

    // PatchOperation.Apply opens a DeepProfiler section, and the profiler reaches for game
    // infrastructure that only exists inside a running RimWorld: outside it, every Apply dies on a
    // NullReferenceException before reaching the operation at all. Switching it off is what makes
    // these tests headless, and it touches nothing the operations themselves do.
    private static bool SkipInfrastructure() => false;

    private static void SilenceProfiler()
    {
        var harmony = new HarmonyLib.Harmony("nelim.techlevelfixes.tests");
        var skip = new HarmonyLib.HarmonyMethod(typeof(PatchTests).GetMethod(nameof(SkipInfrastructure),
            BindingFlags.Static | BindingFlags.NonPublic));
        foreach (var method in typeof(DeepProfiler).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                     .Where(m => m.Name == "Start" || m.Name == "End"))
            harmony.Patch(method, prefix: skip);
    }

    public static int Run()
    {
        SilenceProfiler();
        var corrections = ReadCorrections();
        var bySource = corrections.GroupBy(c => c.SourceMod).OrderBy(g => g.Key).ToList();

        Test("Every shipped XML parses", () =>
        {
            var files = Directory.GetFiles(ModRoot, "*.xml", SearchOption.AllDirectories);
            Require(files.Length > 0, "no XML found under " + ModRoot);
            foreach (var file in files) new XmlDocument().Load(file);
        });

        Test("The shipped patches declare " + corrections.Count + " corrections", () =>
            Require(corrections.Count > 0, "no corrections found"));

        // Catches a generator whose bookkeeping drifted from its own output: the comment a reader
        // trusts and the value the game will actually get must be the same.
        Test("Every correction's comment names the level its XML writes", () =>
        {
            foreach (var c in corrections)
            {
                Require(c.CommentTo != null, c.SourceMod + "/" + c.DefName + ": no \"from -> to\" comment above the operation");
                Equal(c.CommentTo, c.TechLevel, c.SourceMod + "/" + c.DefName + ": comment and XML disagree");
            }
        });

        foreach (var group in bySource)
        {
            var source = group.Key;
            var items = group.ToList();

            // The replace branch: the source mod already gave the def a techLevel.
            Test(source + ": replace branch sets the arbitrated level", () =>
            {
                foreach (var c in items)
                {
                    // Start from a level that is never the answer, so a no-op would fail here.
                    var starting = c.TechLevel == "Undefined" ? "Archotech" : "Undefined";
                    var doc = Fixture(c.DefType, c.DefName, starting);
                    Require(ReadOperation(c.Operation).Apply(doc), c.DefName + ": Apply reported failure");
                    Equal(c.TechLevel, TechLevelIn(doc, c.DefType, c.DefName), c.DefName + " after the replace branch");
                }
            });

            // The add branch: the source mod declared no techLevel at all.
            Test(source + ": add branch sets the arbitrated level", () =>
            {
                foreach (var c in items)
                {
                    var doc = Fixture(c.DefType, c.DefName, null);
                    Require(ReadOperation(c.Operation).Apply(doc), c.DefName + ": Apply reported failure");
                    Equal(c.TechLevel, TechLevelIn(doc, c.DefType, c.DefName), c.DefName + " after the add branch");
                    Equal(1, doc.SelectNodes("/Defs/" + c.DefType + "/label").Count, c.DefName + ": the rest of the def survived");
                }
            });

            // README promises that a correction whose item is missing does nothing. This is the
            // only place that promise is executed rather than read off the success field.
            Test(source + ": a missing target changes nothing and is not an error", () =>
            {
                foreach (var c in items)
                {
                    var doc = new XmlDocument();
                    doc.LoadXml("<Defs><ThingDef><defName>SomethingElse</defName></ThingDef></Defs>");
                    var before = doc.OuterXml;
                    Require(ReadOperation(c.Operation).Apply(doc), c.DefName + ": a missing target must not report failure");
                    Equal(before, doc.OuterXml, c.DefName + ": the document must be untouched");
                }
            });
        }

        RealDefTests(bySource);

        Console.WriteLine();
        Console.WriteLine(passes + " passed, " + failures + " failed.");
        return failures == 0 ? 0 : 1;
    }

    // The tests that matter most: the shipped operations, run against the source mods' real def
    // XML as installed. A renamed defName, a def-type casing that does not match the source, or a
    // def that moved to another mod all fail here and nowhere else in this file.
    private static void RealDefTests(List<IGrouping<string, Correction>> bySource)
    {
        var installed = InstalledMods();
        Console.WriteLine("Installed source mods found: " + bySource.Count(g => installed.ContainsKey(g.Key.ToLowerInvariant())) +
                          " of " + bySource.Count);

        foreach (var group in bySource)
        {
            if (!installed.TryGetValue(group.Key.ToLowerInvariant(), out var folder))
            {
                // Not a failure: which mods are installed is a property of this machine, not of
                // the corrections. Named so the run says what it could not check.
                Console.WriteLine("SKIP  " + group.Key + ": not installed, real-def check not possible here");
                continue;
            }

            Test(group.Key + ": applies to the installed mod's real defs", () =>
            {
                var combined = CombinedDefs(folder);
                foreach (var c in group)
                {
                    var before = combined.SelectNodes("/Defs/" + c.DefType + "[defName=\"" + c.DefName + "\"]");
                    Equal(1, before.Count, c.DefName + " should exist exactly once in " + group.Key +
                                           " (checked with the xpath's own casing, which is what the patcher uses)");
                    Require(ReadOperation(c.Operation).Apply(combined), c.DefName + ": Apply reported failure");
                    Equal(c.TechLevel, TechLevelIn(combined, c.DefType, c.DefName), c.DefName + " after the real patch");
                }
            });

        }
    }

    private static Dictionary<string, string> InstalledMods()
    {
        var roots = new[]
        {
            @"C:\Program Files (x86)\Steam\steamapps\workshop\content\294100",
            @"C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods",
        };
        var found = new Dictionary<string, string>();
        foreach (var root in roots.Where(Directory.Exists))
            foreach (var dir in Directory.GetDirectories(root))
            {
                var about = Path.Combine(dir, "About", "About.xml");
                if (!File.Exists(about)) continue;
                try
                {
                    var doc = new XmlDocument();
                    doc.Load(about);
                    // Anchored, not "//packageId": a mod that lists modDependencies before its own
                    // packageId would otherwise be indexed under a dependency's id.
                    var id = doc.SelectSingleNode("/ModMetaData/packageId");
                    if (id == null) continue;
                    var key = id.InnerText.Trim().ToLowerInvariant();
                    if (!found.ContainsKey(key)) found[key] = dir;
                }
                catch (XmlException) { /* a mod with malformed About.xml is not ours to report */ }
            }
        return found;
    }

    private const string GameVersion = "1.6";

    private static bool IsVersionFolder(string name) =>
        System.Text.RegularExpressions.Regex.IsMatch(name, @"^\d+\.\d+$");

    // Which of a mod's folders the game would actually read for 1.6. Getting this wrong is not
    // academic: a mod carrying 1.3 to 1.6 folders holds four copies of the same def, and a naive
    // recursive walk reports every corrected defName as existing six times.
    private static List<string> ContentFolders(string modFolder)
    {
        var folders = new List<string>();
        var loadFolders = Path.Combine(modFolder, "LoadFolders.xml");
        if (File.Exists(loadFolders))
        {
            var doc = new XmlDocument();
            doc.Load(loadFolders);
            var entries = doc.SelectNodes("loadFolders/v" + GameVersion + "/li");
            if (entries != null)
                foreach (XmlNode li in entries)
                {
                    // Conditional entries depend on a whole modlist, which this test does not model.
                    if (li.Attributes["IfModActive"] != null || li.Attributes["IfModNotActive"] != null) continue;
                    var relative = li.InnerText.Trim();
                    var path = relative == "/" ? modFolder : Path.Combine(modFolder, relative);
                    if (Directory.Exists(path)) folders.Add(path);
                }
            if (folders.Count > 0) return folders;
        }

        // Without LoadFolders.xml: the root, plus the folder named for the game version if there
        // is one. Older version folders are skipped by the walk below.
        folders.Add(modFolder);
        var versioned = Path.Combine(modFolder, GameVersion);
        if (Directory.Exists(versioned)) folders.Add(versioned);
        return folders;
    }

    private static IEnumerable<string> DefFiles(string modFolder, string folder)
    {
        foreach (var file in Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories))
        {
            var relative = file.Substring(modFolder.Length).TrimStart('\\');
            var segments = relative.Split('\\');
            if (segments.Any(s => s.Equals("About", StringComparison.OrdinalIgnoreCase) ||
                                  s.Equals("Languages", StringComparison.OrdinalIgnoreCase))) continue;
            // A version folder other than the one in play belongs to another RimWorld.
            if (segments.Take(segments.Length - 1).Any(s => IsVersionFolder(s) && s != GameVersion)) continue;
            yield return file;
        }
    }

    // RimWorld patches one document holding every def of every active mod, so the fixture closest
    // to the real thing is the source mod's defs, from the folders 1.6 actually loads, merged
    // under a single <Defs> root.
    private static XmlDocument CombinedDefs(string modFolder)
    {
        var combined = new XmlDocument();
        combined.AppendChild(combined.CreateElement("Defs"));
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var folder in ContentFolders(modFolder))
            foreach (var file in DefFiles(modFolder, folder))
            {
                if (!seen.Add(file)) continue;
                XmlDocument doc;
                try { doc = new XmlDocument(); doc.Load(file); }
                catch (XmlException) { continue; }
                if (doc.DocumentElement == null || doc.DocumentElement.Name != "Defs") continue;
                foreach (XmlNode def in doc.DocumentElement.ChildNodes)
                    if (def.NodeType == XmlNodeType.Element)
                        combined.DocumentElement.AppendChild(combined.ImportNode(def, true));
            }
        return combined;
    }
}
