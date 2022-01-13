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
        public bool AutomaticInfoViews { get; set; } = true;
        public bool NotificationIcons { get; set; } = true;
        public bool RoadNames { get; set; } = false;
        public bool Buildings { get; set; } = true;
        public bool BorderLines { get; set; } = true;
        public bool ContourLines { get; set; } = false;
        public bool Zoning { get; set; } = false;
        public bool ZoningGrid { get; set; } = true;
        public bool ZoningColor { get; set; } = true;
        public bool DistrictZones { get; set; } = false;
        public bool DistrictNames { get; set; } = true;
        public bool DistrictIcons { get; set; } = true;
        public bool Tunnels { get; set; } = false;
        public bool WaterPipes { get; set; } = false;
        public bool HeatingPipes { get; set; } = false;
        public bool DefaultToolColors { get; set; } = true;
        public bool DefaultToolInfo { get; set; } = true;
        public bool DefaultToolExtraInfo { get; set; } = true;

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