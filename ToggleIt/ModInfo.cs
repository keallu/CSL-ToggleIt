using CitiesHarmony.API;
using ICities;
using System.Reflection;

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

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

            group = helper.AddGroup(Name + " - " + assemblyName.Version.Major + "." + assemblyName.Version.Minor);

            selected = ModConfig.Instance.ShowPanel;
            group.AddCheckbox("Show Panel", selected, sel =>
            {
                ModConfig.Instance.ShowPanel = sel;
                ModConfig.Instance.Save();
            });

            group.AddSpace(10);

            group.AddButton("Reset Positioning of Panel", () =>
            {
                ModProperties.Instance.ResetPanelPosition();
            });
        }
    }
}