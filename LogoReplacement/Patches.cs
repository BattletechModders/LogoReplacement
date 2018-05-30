using System;
using System.IO;
using System.Reflection;
using BattleTech.UI;
using Harmony;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace LogoReplacement
{
    [HarmonyPatch(typeof(MainMenu), "Init")]
    public static class MainMenu_Init_Patch
    {
        public static void Postfix()
        {
            var logo = GameObject.Find("logo-Battletech");
            var image = logo.GetComponent<Image>();
            image.sprite = Utilities.ImageUtils.LoadSprite(Path.Combine(Patches.ModDirectory, Patches.Settings.LogoPath));
        }
    }

    public class ModSettings
    {
        public string LogoPath = "uixTxr_landingLogo.png";
    }

    public static class Patches
    {
        public static ModSettings Settings;
        public static string ModDirectory;

        public static void Init(string modDir, string modSettings)
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.LogoReplacement");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModDirectory = modDir;

            // read settings
            try
            {
                Settings = JsonConvert.DeserializeObject<ModSettings>(modSettings);
            }
            catch (Exception)
            {
                Settings = new ModSettings();
            }
        }
    }
}