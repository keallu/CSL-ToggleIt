using System;
using UnityEngine;

namespace ToggleIt
{
    public class ModProperties
    {
        public float PanelDefaultPositionX;
        public float PanelDefaultPositionY;

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
            try
            {
                ModConfig.Instance.PositionX = PanelDefaultPositionX;
                ModConfig.Instance.PositionY = PanelDefaultPositionY;
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModProperties:ResetPanelPosition -> Exception: " + e.Message);
            }
        }
    }
}
