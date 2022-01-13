using CitiesHarmony.API;
using ICities;

namespace ToggleIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Toggle It!";
        public string Description => "Allows to toggle different visual elements in the game.";

        public void OnEnabled()
        {
            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());
        }

        public void OnDisabled()
        {
            if (HarmonyHelper.IsHarmonyInstalled)
            {
                Patcher.UnpatchAll();
            }
        }

        public static readonly string[] ToggleLabels =
        {
            "None",
            "Automatic Info Views",
            "Notification Icons",
            "Road Names",
            "Buildings",
            "Border Lines",
            "Contour Lines",
            "Zoning",
            "Zoning Grid",
            "Zoning Color",
            "District Zones",
            "District Names",
            "District Icons",
            "Tunnels",
            "Water Pipes",
            "Heating Pipes",
            "Tool Colors",
            "Tool Info",
            "Tool Extra Info"
        };

        public static readonly int[] ToggleValues =
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18
        };

        public static readonly string[] KeymappingLabels =
        {
            "None",
            "LEFT CTRL + A",
            "LEFT CTRL + B",
            "LEFT CTRL + C",
            "LEFT CTRL + D",
            "LEFT CTRL + E",
            "LEFT CTRL + F",
            "LEFT CTRL + G",
            "LEFT CTRL + H",
            "LEFT CTRL + I",
            "LEFT CTRL + J",
            "LEFT CTRL + K",
            "LEFT CTRL + L",
            "LEFT CTRL + M",
            "LEFT CTRL + N",
            "LEFT CTRL + O",
            "LEFT CTRL + P",
            "LEFT CTRL + Q",
            "LEFT CTRL + R",
            "LEFT CTRL + S",
            "LEFT CTRL + T",
            "LEFT CTRL + U",
            "LEFT CTRL + V",
            "LEFT CTRL + W",
            "LEFT CTRL + X",
            "LEFT CTRL + Y",
            "LEFT CTRL + Z",
            "LEFT CTRL + 1",
            "LEFT CTRL + 2",
            "LEFT CTRL + 3",
            "LEFT CTRL + 4",
            "LEFT CTRL + 5",
            "LEFT CTRL + 6",
            "LEFT CTRL + 7",
            "LEFT CTRL + 8",
            "LEFT CTRL + 9"

        };

        public static readonly int[] KeymappingValues =
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24,
            25,
            26,
            27,
            28,
            29,
            30,
            31,
            32,
            33,
            34,
            35
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
                ModProperties.Instance.ResetPanelPosition();
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