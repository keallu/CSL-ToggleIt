using ColossalFramework;
using System;
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

        public static void UpdateZoningGrid(bool enableZoningGrid)
        {
            try
            {
                Shader.SetGlobalColor("_ZoneEdgeColor", enableZoningGrid ? ModProperties.Instance.DefaultZoneEdgeColor : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneEdgeColorInfo", enableZoningGrid ? ModProperties.Instance.DefaultZoneEdgeColorInfo : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneEdgeColorOccupied", enableZoningGrid ? ModProperties.Instance.DefaultZoneEdgeColorOccupiedColor : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneEdgeColorOccupiedInfo", enableZoningGrid ? ModProperties.Instance.DefaultZoneEdgeColorOccupiedInfo : new Color(0f, 0f, 0f, 0f));
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateZoningGrid -> Exception: " + e.Message);
            }
        }

        public static void UpdateZoningColor(bool enableZoningColor)
        {
            try
            {
                Shader.SetGlobalColor("_ZoneFillColor", enableZoningColor ? ModProperties.Instance.DefaultZoneFillColor : new Color(0f, 0f, 0f, 0f));
                Shader.SetGlobalColor("_ZoneFillColorInfo", enableZoningColor ? ModProperties.Instance.DefaultZoneFillColorInfo : new Color(0f, 0f, 0f, 0f));
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

        public static void UpdateDistrictIcons(bool enableDistrictIcons)
        {
            try
            {
                DistrictManager districtManager = Singleton<DistrictManager>.instance;

                if (enableDistrictIcons)
                {
                    districtManager.m_properties.m_areaIconAtlas = ModProperties.Instance.DefaultIngameTextureAtlas;
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

        public static void UpdateDefaultToolColor(bool enableDefaultToolColors)
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                if (toolController != null)
                {
                    toolController.m_validColor.a = enableDefaultToolColors ? ModProperties.Instance.DefaultValidColor.a : 0f;
                    toolController.m_warningColor.a = enableDefaultToolColors ? ModProperties.Instance.DefaultWarningColor.a : 0f;
                    toolController.m_errorColor.a = enableDefaultToolColors ? ModProperties.Instance.DefaultErrorColor.a : 0f;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDefaultToolColor -> Exception: " + e.Message);
            }
        }
    }
}
