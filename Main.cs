using System.Reflection;
using Harmony;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace LogoReplacement
{
    public static class Main
    {
        public static ModSettings Settings;
        public static string ModDirectory;

        public static void Init(string modDir, string modSettings)
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.LogoReplacement");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            ModDirectory = modDir;
            Settings = ModSettings.ParseSettings(modSettings);
        }
    }
}
