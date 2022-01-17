﻿using ColossalFramework.UI;
using UnityEngine;

namespace ToggleIt
{
    public class ModProperties
    {
        public float PanelDefaultPositionX;
        public float PanelDefaultPositionY;

        public Color DefaultZoneEdgeColor;
        public Color DefaultZoneEdgeColorInfo;
        public Color DefaultZoneEdgeColorOccupiedColor;
        public Color DefaultZoneEdgeColorOccupiedInfo;
        public Color DefaultZoneFillColor;
        public Color DefaultZoneFillColorInfo;

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
            ModConfig.Instance.PositionX = PanelDefaultPositionX;
            ModConfig.Instance.PositionY = PanelDefaultPositionY;
            ModConfig.Instance.Save();
        }
    }
}
