using Harmony;
using ICities;
using System;
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

        private static readonly string[] KeymappingLabels =
        {
            "Notification Icons",
            "District Names",
            "District Icons",
            "Line Borders",
            "Default Tool Colors",
            "Move It! Tool Colors"
        };

        private static readonly string[] KeymappingValues =
        {
            "Notification Icons",
            "District Names",
            "District Icons",
            "Line Borders",
            "Default Tool Colors",
            "Move It! Tool Colors"
        };

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            int selectedIndex;

            group = helper.AddGroup(Name);

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping1);
            group.AddDropdown("LEFT CTRL + H", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping1 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping2);
            group.AddDropdown("LEFT CTRL + I", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping2 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping3);
            group.AddDropdown("LEFT CTRL + J", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping3 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping4);
            group.AddDropdown("LEFT CTRL + K", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping4 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping5);
            group.AddDropdown("LEFT CTRL + L", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping5 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping6);
            group.AddDropdown("LEFT CTRL + M", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping6 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });
        }

        private int GetSelectedOptionIndex(string[] option, string value)
        {
            int index = Array.IndexOf(option, value);
            if (index < 0) index = 0;

            return index;
        }
    }
}