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

        public void ResetToggles()
        {
            try
            {
                ModConfig.Instance.AutomaticInfoViews = true;
                ModConfig.Instance.NotificationIcons = true;
                ModConfig.Instance.RoadNames = true;
                ModConfig.Instance.Buildings = true;
                ModConfig.Instance.BorderLines = true;
                ModConfig.Instance.ContourLines = false;
                ModConfig.Instance.Zoning = false;
                ModConfig.Instance.ZoningGrid = true;
                ModConfig.Instance.ZoningColor = true;
                ModConfig.Instance.DistrictZones = false;
                ModConfig.Instance.DistrictNames = true;
                ModConfig.Instance.DistrictIcons = true;
                ModConfig.Instance.DefaultToolColors = true;
                ModConfig.Instance.DefaultToolInfo = true;
                ModConfig.Instance.DefaultToolExtraInfo = true;
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModProperties:ResetToggles -> Exception: " + e.Message);
            }
        }
    }
}
