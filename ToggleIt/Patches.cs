using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;
using ToggleIt.Helpers;

namespace ToggleIt
{
    [HarmonyPatch(typeof(NetTool), "OnToolLateUpdate")]
    public static class NetToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] NetToolOnToolLateUpdatePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(NetTool), "OnDisable")]
    public static class NetToolOnDisablePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] NetToolOnDisablePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(ZoneTool), "OnToolLateUpdate")]
    public static class ZoneToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ZoneToolOnToolLateUpdatePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(ZoneTool), "OnDisable")]
    public static class ZoneToolOnDisablePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ZoneToolOnDisablePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(DistrictTool), "OnToolLateUpdate")]
    public static class DistrictToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] DistrictToolOnToolLateUpdatePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(DistrictTool), "OnDisable")]
    public static class DistrictToolOnDisablePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] DistrictToolOnDisablePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(BuildingTool), "OnToolLateUpdate")]
    public static class BuildingToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] BuildingToolOnToolLateUpdatePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(BuildingTool), "OnDisable")]
    public static class BuildingToolOnDisablePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] BuildingToolOnDisablePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(TerrainTool), "OnToolLateUpdate")]
    public static class TerrainToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TerrainToolOnToolLateUpdatePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(TerrainTool), "OnDisable")]
    public static class TerrainToolOnDisablePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TerrainToolOnDisablePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(BulldozeTool), "OnToolLateUpdate")]
    public static class BulldozeToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] BulldozeToolOnToolLateUpdatePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(BulldozeTool), "OnDisable")]
    public static class BulldozeToolOnDisablePatch
    {
        static void Postfix()
        {
            try
            {
                ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] BulldozeToolOnDisablePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(ToolBase), "ShowToolInfo")]
    public static class ToolBaseShowToolInfoPatch
    {
        static bool Prefix()
        {
            try
            {
                return ModConfig.Instance.DefaultToolInfo;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToolBaseShowToolInfoPatch:Prefix -> Exception: " + e.Message);
                return true;
            }
        }
    }

    [HarmonyPatch(typeof(ToolBase), "ShowExtraInfo")]
    public static class ToolBaseShowExtraInfoPatch
    {
        static bool Prefix()
        {
            try
            {
                return ModConfig.Instance.DefaultToolExtraInfo;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToolBaseShowExtraInfoPatch:Prefix -> Exception: " + e.Message);
                return true;
            }
        }
    }

    [HarmonyPatch(typeof(ToolBase), "ForceInfoMode")]
    public static class ToolBaseForceInfoModePatch
    {
        static bool Prefix(InfoManager.InfoMode mode, InfoManager.SubInfoMode subMode)
        {
            try
            {
                return ModConfig.Instance.AutomaticInfoViews;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToolBaseForceInfoModePatch:Prefix -> Exception: " + e.Message);
                return true;
            }
        }
    }

    [HarmonyPatch(typeof(InfoManager), "SetCurrentMode")]
    public static class InfoManagerSetCurrentModePatch
    {
        static void Postfix(InfoManager.InfoMode mode, InfoManager.SubInfoMode subMode)
        {
            try
            {
                if (mode == InfoManager.InfoMode.TrafficRoutes && subMode == InfoManager.SubInfoMode.JunctionSettings)
                {
                    ToggleHelper.UpdateNotificationIcons(true);
                }
                else
                {
                    ToggleHelper.UpdateNotificationIcons(ModConfig.Instance.NotificationIcons);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] InfoManagerSetCurrentModePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(CameraController), "UpdateFreeCamera")]
    public static class CameraControllerUpdateFreeCameraPatch
    {
        private static bool m_cachedFreeCamera;

        static void Prefix(CameraController __instance)
        {
            try
            {
                m_cachedFreeCamera = (bool)typeof(CameraController).GetField("m_cachedFreeCamera", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] CameraControllerUpdateFreeCameraPatch:Prefix -> Exception: " + e.Message);
            }
        }

        static void Postfix(CameraController __instance)
        {
            try
            {
                if (__instance.m_freeCamera != m_cachedFreeCamera)
                {
                    m_cachedFreeCamera = __instance.m_freeCamera;

                    if (__instance.m_freeCamera)
                    {
                        ToggleHelper.UpdateBuildings(true);
                        ToggleHelper.UpdateContourLines(false);
                        ToggleHelper.UpdateZoning(false);
                        ToggleHelper.UpdateDistrictZones(false);
                    }
                    else
                    {
                        ToggleHelper.UpdateBuildings(ModConfig.Instance.Buildings);
                        ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                        ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                        ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] CameraControllerUpdateFreeCameraPatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(CinematicCameraController), "SetUIVisible")]
    public static class CinematicCameraControllerSetUIVisiblePatch
    {
        static void Postfix(bool visible)
        {
            try
            {
                if (!visible)
                {
                    ToggleHelper.UpdateBuildings(true);
                    ToggleHelper.UpdateContourLines(false);
                    ToggleHelper.UpdateZoning(false);
                    ToggleHelper.UpdateDistrictZones(false);
                }
                else
                {
                    ToggleHelper.UpdateBuildings(ModConfig.Instance.Buildings);
                    ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                    ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                    ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] CinematicCameraControllerSetUIVisiblePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }
}
