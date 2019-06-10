using Harmony;
using ICities;
using System.Reflection;

namespace ToggleIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Toggle It!";
        public string Description => "Allows to toggle different elements in the game.";

        public void OnEnabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.toggleit");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnDisabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.toggleit");
            harmony.UnpatchAll();
        }

        public static readonly string[] ToggleLabels =
        {
            "None",
            "Notification Icons",
            "District Names",
            "District Icons",
            "Line Borders",
            "Default Tool Colors",
            "Move It! Tool Colors"
        };

        public static readonly int[] ToggleValues =
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6
        };

        public static readonly string[] KeymappingLabels =
        {
            "None",
            "LEFT CTRL + H",
            "LEFT CTRL + I",
            "LEFT CTRL + J",
            "LEFT CTRL + K",
            "LEFT CTRL + L",
            "LEFT CTRL + M"
        };

        public static readonly int[] KeymappingValues =
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6
        };

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;
            int selectedValue;

            group = helper.AddGroup(Name);

            selected = ModConfig.Instance.ShowTogglePanel;
            group.AddCheckbox("Show Toggle Panel", selected, sel =>
            {
                ModConfig.Instance.ShowTogglePanel = sel;
                ModConfig.Instance.Save();
            });

            group.AddSpace(10);

            group.AddButton("Reset Positioning of Toggle Panel", () =>
            {
                ToggleProperties.Instance.ResetPanelPosition();
            });

            group = helper.AddGroup("Toggles");

            selectedValue = ModConfig.Instance.Toggles[0];
            group.AddDropdown("Toggle A", ToggleLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Toggles[0] = ToggleValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Toggles[1];
            group.AddDropdown("Toggle B", ToggleLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Toggles[1] = ToggleValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Toggles[2];
            group.AddDropdown("Toggle C", ToggleLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Toggles[2] = ToggleValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Toggles[3];
            group.AddDropdown("Toggle D", ToggleLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Toggles[3] = ToggleValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Toggles[4];
            group.AddDropdown("Toggle E", ToggleLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Toggles[4] = ToggleValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Toggles[5];
            group.AddDropdown("Toggle F", ToggleLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Toggles[5] = ToggleValues[sel];
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Keymappings");

            selectedValue = ModConfig.Instance.Keymappings[0];
            group.AddDropdown("Toggle A", KeymappingLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Keymappings[0] = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Keymappings[1];
            group.AddDropdown("Toggle B", KeymappingLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Keymappings[1] = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Keymappings[2];
            group.AddDropdown("Toggle C", KeymappingLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Keymappings[2] = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Keymappings[3];
            group.AddDropdown("Toggle D", KeymappingLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Keymappings[3] = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Keymappings[4];
            group.AddDropdown("Toggle E", KeymappingLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Keymappings[4] = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.Keymappings[5];
            group.AddDropdown("Toggle F", KeymappingLabels, selectedValue, sel =>
            {
                ModConfig.Instance.Keymappings[5] = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });
        }
    }
}