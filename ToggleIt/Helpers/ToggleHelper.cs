using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;
using static InfoProperties;

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

        public static void UpdateZoningGrids(bool enableZoningGrid)
        {
            try
            {
                Shader.SetGlobalColor("_ZoneEdgeColor", enableZoningGrid ? new Color(0.73f, 0.73f, 0.73f, 0.6f).linear : new Color(0f, 0f, 0f, 0f).linear);
                Shader.SetGlobalColor("_ZoneEdgeColorInfo", enableZoningGrid ? new Color(0.73f, 0.73f, 0.73f, 1f).linear : new Color(0f, 0f, 0f, 0f).linear);
                Shader.SetGlobalColor("_ZoneEdgeColorOccupied", enableZoningGrid ? new Color(0.26f, 0.26f, 0.26f, 0.8f).linear : new Color(0f, 0f, 0f, 0f).linear);
                Shader.SetGlobalColor("_ZoneEdgeColorOccupiedInfo", enableZoningGrid ? new Color(0.35f, 0.35f, 0.35f, 0.7f).linear : new Color(0f, 0f, 0f, 0f).linear);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateZoningGrid -> Exception: " + e.Message);
            }
        }

        public static void UpdateZoningColors(bool enableZoningColor)
        {
            try
            {
                Shader.SetGlobalColor("_ZoneFillColor", enableZoningColor ? new Color(1f, 1f, 1f, 0.75f).linear : new Color(0f, 0f, 0f, 0f).linear);
                Shader.SetGlobalColor("_ZoneFillColorInfo", enableZoningColor ? new Color(1f, 1f, 1f, 0.75f).linear : new Color(0f, 0f, 0f, 0f).linear);
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
                    UIView uIView = UIView.GetAView();

                    if (uIView != null)
                    {
                        districtManager.m_properties.m_areaIconAtlas = uIView.defaultAtlas;
                    }
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

        public static void UpdateDefaultToolColors(bool enableDefaultToolColors)
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                if (toolController != null)
                {
                    toolController.m_validColor.a = enableDefaultToolColors ? 1f : 0f;
                    toolController.m_warningColor.a = enableDefaultToolColors ? 1f : 0f;
                    toolController.m_errorColor.a = enableDefaultToolColors ? 1f : 0f;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDefaultToolColor -> Exception: " + e.Message);
            }
        }

        public static void UpdateDarkInfoViews(bool enableDarkInfoViews)
        {
            try
            {
                Shader.SetGlobalColor("_InfoObjectColor", enableDarkInfoViews ? new Color(0.27f, 0.27f, 0.27f, 0f).linear : new Color(0.73f, 0.73f, 0.73f, 0f).linear);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleHelper:UpdateDarkInfoViews -> Exception: " + e.Message);
            }
        }
    }
}
