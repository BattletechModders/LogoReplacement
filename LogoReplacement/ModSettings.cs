using System;
using Newtonsoft.Json;

namespace LogoReplacement
{
    public class ModSettings
    {
        public string LogoPath = "uixTxr_landingLogo.png";

        public static ModSettings ParseSettings(string json)
        {
            // read settings
            try
            {
                return JsonConvert.DeserializeObject<ModSettings>(json);
            }
            catch (Exception)
            {
                return new ModSettings();
            }
        }
    }
}
