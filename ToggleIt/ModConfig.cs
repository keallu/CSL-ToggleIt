namespace ToggleIt
{
    [ConfigurationPath("ToggleItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public bool ShowTogglePanel { get; set; } = true;
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public int[] Toggles { get; set; } = { 1, 2, 3, 4, 5, 6 };
        public int[] Keymappings { get; set; } = { 1, 2, 3, 4, 5, 6 };
        public bool NotificationIcons { get; set; } = true;
        public bool DistrictNames { get; set; } = true;
        public bool DistrictIcons { get; set; } = true;
        public bool BorderLines { get; set; } = true;
        public bool ContourLines { get; set; } = false;
        public bool ZoningGrid { get; set; } = true;
        public bool ZoningColor { get; set; } = true;
        public bool DefaultToolColors { get; set; } = true;
        public bool MoveItToolColors { get; set; } = true;
        public bool AutomaticInfoViews { get; set; } = true;

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

        public void SaveWithoutUpdate()
        {
            Configuration<ModConfig>.Save();
        }
    }
}