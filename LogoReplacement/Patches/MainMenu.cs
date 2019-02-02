using System.IO;
using BattleTech.UI;
using Harmony;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace LogoReplacement.Patches
{
    [HarmonyPatch(typeof(MainMenu), "Init")]
    public static class MainMenu_Init_Patch
    {
        public static void Postfix()
        {
            var logo = GameObject.Find("logo-Battletech");

            if (logo == null)
                return;

            var image = logo.GetComponent<Image>();
            image.sprite = Utilities.ImageUtils.LoadSprite(Path.Combine(Main.ModDirectory, Main.Settings.LogoPath));
        }
    }
}
