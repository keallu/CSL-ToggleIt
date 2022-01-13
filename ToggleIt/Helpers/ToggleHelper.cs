using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.Reflection;
using UnityEngine;

namespace ToggleIt.Helpers
{
    public static class ToggleHelper
    {
        public static void UpdateNotificationIcons(bool enableNotificationIcons)
        {
            try
            {
                Singleton<NotificationManager>.instance.NotificationsVisible = enableNotificationIcons;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateNotificationIcons -> Exception: " + e.Message);
            }
        }

        public static void UpdateRoadNames(bool enableRoadNames)
        {
            try
            {
                Singleton<NetManager>.instance.RoadNamesVisible = enableRoadNames;

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateRoadNames -> Exception: " + e.Message);
            }
        }

        public static void UpdateBuildings(bool enableBuildings)
        {
            try
            {
                if (enableBuildings)
                {
                    Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Buildings");
                }
                else
                {
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Buildings"));
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateBuildings -> Exception: " + e.Message);
            }
        }

        public static void UpdateBorderLines(bool enableBorderLines)
        {
            try
            {
                Singleton<GameAreaManager>.instance.BordersVisible = enableBorderLines;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateBorderLines -> Exception: " + e.Message);
            }
        }

        public static void UpdateContourLines(bool enableContourLines)
        {
            try
            {
                Singleton<TerrainManager>.instance.RenderTopography = enableContourLines;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateContourLines -> Exception: " + e.Message);
            }
        }

        public static void UpdateZoning(bool enableZoning)
        {
            try
            {
                Singleton<TerrainManager>.instance.RenderZones = enableZoning;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateZoning -> Exception: " + e.Message);
            }
        }

        public static void UpdateZoningGrid(bool enableZoningGrid, Color defaultZoneEdgeColor, Color defaultZoneEdgeColorInfo, Color defaultZoneEdgeColorOccupiedColor, Color defaultZoneEdgeColorOccupiedInfo)
        {
            try
            {
                Shader.SetGlobalColor("_ZoneEdgeColor", enableZoningGrid ? defaultZoneEdgeColor : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneEdgeColorInfo", enableZoningGrid ? defaultZoneEdgeColorInfo : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneEdgeColorOccupied", enableZoningGrid ? defaultZoneEdgeColorOccupiedColor : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneEdgeColorOccupiedInfo", enableZoningGrid ? defaultZoneEdgeColorOccupiedInfo : new Color(0f, 0f, 0f, 0f));
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateZoningGrid -> Exception: " + e.Message);
            }
        }

        public static void UpdateZoningColor(bool enableZoningColor, Color defaultZoneFillColor, Color defaultZoneFillColorInfo)
        {
            try
            {
                Shader.SetGlobalColor("_ZoneFillColor", enableZoningColor ? defaultZoneFillColor : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneFillColorInfo", enableZoningColor ? defaultZoneFillColorInfo : new Color(0f, 0f, 0f, 0f));
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateZoningColor -> Exception: " + e.Message);
            }
        }

        public static void UpdateDistrictZones(bool enableDistrictZones)
        {
            try
            {
                Singleton<DistrictManager>.instance.DistrictsVisible = enableDistrictZones;
                Singleton<DistrictManager>.instance.ParksVisible = enableDistrictZones;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDistrictZones -> Exception: " + e.Message);
            }
        }

        public static void UpdateDistrictNames(bool enableDistrictNames)
        {
            try
            {
                Singleton<DistrictManager>.instance.NamesVisible = enableDistrictNames;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDistrictNames -> Exception: " + e.Message);
            }
        }

        public static void UpdateDistrictIcons(bool enableDistrictIcons, UITextureAtlas defaultIngameTextureAtlas)
        {
            try
            {
                DistrictManager districtManager = Singleton<DistrictManager>.instance;

                if (enableDistrictIcons)
                {
                    districtManager.m_properties.m_areaIconAtlas = defaultIngameTextureAtlas;
                }
                else
                {
                    districtManager.m_properties.m_areaIconAtlas = null;
                }

                districtManager.NamesModified();
                districtManager.ParkNamesModified();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDistrictIcons -> Exception: " + e.Message);
            }
        }
        public static void UpdateTunnels(bool enableTunnels)
        {
            try
            {
                Singleton<TransportManager>.instance.TunnelsVisible = enableTunnels;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateTunnels -> Exception: " + e.Message);
            }
        }

        public static void UpdateWaterPipes(bool enableWaterPipes)
        {
            try
            {
                Singleton<WaterManager>.instance.WaterMapVisible = enableWaterPipes;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateWaterPipes -> Exception: " + e.Message);
            }
        }

        public static void UpdateHeatingPipes(bool enableHeatingPipes)
        {
            try
            {
                Singleton<WaterManager>.instance.HeatingMapVisible = enableHeatingPipes;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateHeatingPipes -> Exception: " + e.Message);
            }
        }

        public static void UpdateDefaultToolColor(bool enableDefaultToolColors, Color defaultValidColor, Color defaultWarningColor, Color defaultErrorColor)
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                if (toolController != null)
                {
                    toolController.m_validColor.a = enableDefaultToolColors ? defaultValidColor.a : 0f;
                    toolController.m_warningColor.a = enableDefaultToolColors ? defaultWarningColor.a : 0f;
                    toolController.m_errorColor.a = enableDefaultToolColors ? defaultErrorColor.a : 0f;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDefaultToolColor -> Exception: " + e.Message);
            }
        }
    }
}
