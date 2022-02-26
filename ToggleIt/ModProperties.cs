using ColossalFramework.UI;
using UnityEngine;

namespace ToggleIt
{
    public class ModProperties
    {
        private static ModProperties instance;

        public static ModProperties Instance
        {
            get
            {
                return instance ?? (instance = new ModProperties());
            }
        }

        public void ResetPanelPosition()
        {
            ModConfig.Instance.PanelPositionX = UIView.GetAView().GetScreenResolution().x * 0.75f;
            ModConfig.Instance.PanelPositionY = 10f;
            ModConfig.Instance.Save();
        }
    }
}
