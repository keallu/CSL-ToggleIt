using System;
using UnityEngine;

namespace ToggleIt
{
    public class ToggleProperties
    {
        public float PanelDefaultPositionX;
        public float PanelDefaultPositionY;

        private static ToggleProperties instance;

        public static ToggleProperties Instance
        {
            get
            {
                return instance ?? (instance = new ToggleProperties());
            }
        }

        public void ResetPanelPosition()
        {
            try
            {
                ModConfig.Instance.PositionX = PanelDefaultPositionX;
                ModConfig.Instance.PositionY = PanelDefaultPositionY;
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleProperties:ResetPanelPosition -> Exception: " + e.Message);
            }
        }
    }
}
