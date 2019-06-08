namespace ToggleIt
{
    [ConfigurationPath("ToggleItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public string Keymapping1 { get; set; } = "Notification Icons";
        public string Keymapping2 { get; set; } = "District Names";
        public string Keymapping3 { get; set; } = "District Icons";
        public string Keymapping4 { get; set; } = "Line Borders";
        public string Keymapping5 { get; set; } = "Default Tool Colors";
        public string Keymapping6 { get; set; } = "Move It! Tool Colors";
        public bool NotificationIcons { get; set; }
        public bool DistrictNames { get; set; }
        public bool DistrictIcons { get; set; }
        public bool LineBorders { get; set; }
        public bool DefaultToolColors { get; set; }
        public bool MoveItToolColors { get; set; }

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