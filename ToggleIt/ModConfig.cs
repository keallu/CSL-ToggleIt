using System.Collections.Generic;

namespace ToggleIt
{
    [ConfigurationPath("ToggleItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public bool ShowPanel { get; set; } = true;
        public float PanelPositionX { get; set; }
        public float PanelPositionY { get; set; }
        public List<Toggle> Toggles { get; set; } = new List<Toggle> { };

        private static ModConfig instance;

        public static ModConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Configuration<ModConfig>.Load();
                }

                return instance;
            }
        }

        public void Save()
        {
            Configuration<ModConfig>.Save();
            ConfigUpdated = true;
        }
    }
}