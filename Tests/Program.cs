using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

internal static class Program
{
    internal static string Metadata(string key) => Assembly.GetExecutingAssembly()
        .GetCustomAttributes<AssemblyMetadataAttribute>().Single(a => a.Key == key).Value;

    private static int Main()
    {
        // Assembly-CSharp pulls in the rest of the game's managed assemblies as it goes; resolving
        // them out of the installation keeps them out of the build output.
        AppDomain.CurrentDomain.AssemblyResolve += (_, e) =>
        {
            var path = Path.Combine(Metadata("RimWorldManaged"), new AssemblyName(e.Name).Name + ".dll");
            return File.Exists(path) ? Assembly.LoadFrom(path) : null;
        };
        return Run();
    }

    // Kept out of Main so the resolver above is installed before PatchTests is jitted.
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int Run() => PatchTests.Run();
}
