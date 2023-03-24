using ColossalFramework;
using HarmonyLib;
using System;
using System.Reflection;
using ToggleIt.Helpers;
using ToggleIt.Managers;
using UnityEngine;

namespace ToggleIt
{
    [HarmonyPatch(typeof(NetTool), "OnToolLateUpdate")]
    public static class NetToolOnToolLateUpdatePatch
    {
        static void Postfix()
        {
            try
            {
                // Contour Lines
                if (ToggleManager.Instance.GetById(5).Enabled)
                {
                    ToggleHelper.UpdateContourLines(ToggleManager.Instance.GetById(5).On);
                }
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
                ToggleManager.Instance.ApplyAll();
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
                // Contour Lines
                if (ToggleManager.Instance.GetById(5).Enabled)
                {
                    ToggleHelper.UpdateContourLines(ToggleManager.Instance.GetById(5).On);
                }
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
                ToggleManager.Instance.ApplyAll();
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
                // Contour Lines
                if (ToggleManager.Instance.GetById(5).Enabled)
                {
                    ToggleHelper.UpdateContourLines(ToggleManager.Instance.GetById(5).On);
                }
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
                ToggleManager.Instance.ApplyAll();
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
                // Contour Lines
                if (ToggleManager.Instance.GetById(5).Enabled)
                {
                    ToggleHelper.UpdateContourLines(ToggleManager.Instance.GetById(5).On);
                }
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
                ToggleManager.Instance.ApplyAll();
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
                // Contour Lines
                if (ToggleManager.Instance.GetById(5).Enabled)
                {
                    ToggleHelper.UpdateContourLines(ToggleManager.Instance.GetById(5).On);
                }
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
                ToggleManager.Instance.ApplyAll();
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
                // Contour Lines
                if (ToggleManager.Instance.GetById(5).Enabled)
                {
                    ToggleHelper.UpdateContourLines(ToggleManager.Instance.GetById(5).On);
                }
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
                ToggleManager.Instance.ApplyAll();
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
                // Tool Info
                if (ToggleManager.Instance.GetById(13).Enabled)
                {
                    return ToggleManager.Instance.GetById(13).On;
                }

                return true;
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
                // Tool Extra Info
                if (ToggleManager.Instance.GetById(14).Enabled)
                {
                    return ToggleManager.Instance.GetById(14).On;
                }

                return true;
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
        static void Postfix(InfoManager.InfoMode mode, InfoManager.SubInfoMode subMode)
        {
            try
            {
                // Automatic Info Views
                if (ToggleManager.Instance.GetById(0).Enabled)
                {
                    if (!ToggleManager.Instance.GetById(0).On)
                    {
                        Singleton<InfoManager>.instance.SetCurrentMode(InfoManager.InfoMode.None, InfoManager.SubInfoMode.None);

                        int natural = 0;

                        Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = 0;
                        Singleton<DisasterManager>.instance.HazardMapVisible = 0;
                        Singleton<ElectricityManager>.instance.ElectricityMapVisible = false;
                        Singleton<WaterManager>.instance.WaterMapVisible = false;
                        Singleton<WaterManager>.instance.HeatingMapVisible = false;
                        Singleton<DistrictManager>.instance.DistrictsInfoVisible = false;
                        Singleton<DistrictManager>.instance.ParksInfoVisible = false;
                        Singleton<DistrictManager>.instance.ParkGroupsInfoVisible = DistrictPark.ParkGroup.None;
                        Singleton<TransportManager>.instance.TunnelsVisibleInfo = false;
                        Singleton<TransportManager>.instance.LinesVisible = 0;
                        Singleton<WeatherManager>.instance.WindMapVisible = false;
                        Singleton<TerrainManager>.instance.RenderTopographyInfo = false;
                        Singleton<TerrainManager>.instance.TransparentWater = false;
                        Singleton<NetManager>.instance.RenderDirectionArrowsInfo = false;
                        Singleton<NetManager>.instance.PathVisualizer.PathsVisible = false;
                        Singleton<NetManager>.instance.NetAdjust.PathVisible = false;

                        switch (mode)
                        {
                            case InfoManager.InfoMode.None:
                                break;
                            case InfoManager.InfoMode.Electricity:
                                Singleton<ElectricityManager>.instance.ElectricityMapVisible = true;
                                if (subMode == InfoManager.SubInfoMode.WaterPower)
                                {
                                    Singleton<TerrainManager>.instance.RenderTopographyInfo = true;
                                }
                                else if (subMode == InfoManager.SubInfoMode.WindPower)
                                {
                                    Singleton<WeatherManager>.instance.WindMapVisible = true;
                                }
                                break;
                            case InfoManager.InfoMode.Water:
                                Singleton<WaterManager>.instance.WaterMapVisible = true;
                                break;
                            case InfoManager.InfoMode.CrimeRate:
                                break;
                            case InfoManager.InfoMode.Health:
                                break;
                            case InfoManager.InfoMode.Happiness:
                                break;
                            case InfoManager.InfoMode.Density:
                                break;
                            case InfoManager.InfoMode.NoisePollution:
                                Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.NoisePollution;
                                break;
                            case InfoManager.InfoMode.Transport:
                                Singleton<TransportManager>.instance.LinesVisible = -35969;
                                Singleton<TransportManager>.instance.TunnelsVisibleInfo = true;
                                Singleton<NetManager>.instance.RenderDirectionArrowsInfo = true;
                                if (subMode == InfoManager.SubInfoMode.WaterPower && SteamHelper.IsDLCOwned(SteamHelper.DLC.AirportDLC))
                                {
                                    Singleton<DistrictManager>.instance.ParksInfoVisible = true;
                                    Singleton<DistrictManager>.instance.ParkGroupsInfoVisible = DistrictPark.ParkGroup.Airport;
                                }
                                break;
                            case InfoManager.InfoMode.Pollution:
                                Singleton<WaterManager>.instance.WaterMapVisible = true;
                                break;
                            case InfoManager.InfoMode.NaturalResources:
                                natural = 15;
                                break;
                            case InfoManager.InfoMode.LandValue:
                                Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.LandValue;
                                break;
                            case InfoManager.InfoMode.Districts:
                                Singleton<DistrictManager>.instance.DistrictsInfoVisible = true;
                                break;
                            case InfoManager.InfoMode.Connections:
                                break;
                            case InfoManager.InfoMode.Traffic:
                                Singleton<TransportManager>.instance.TunnelsVisibleInfo = true;
                                Singleton<NetManager>.instance.RenderDirectionArrowsInfo = true;
                                break;
                            case InfoManager.InfoMode.Wind:
                                Singleton<WeatherManager>.instance.WindMapVisible = true;
                                break;
                            case InfoManager.InfoMode.Garbage:
                                break;
                            case InfoManager.InfoMode.BuildingLevel:
                                break;
                            case InfoManager.InfoMode.FireSafety:
                                Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.FirewatchCoverage;
                                break;
                            case InfoManager.InfoMode.Education:
                                if ((subMode == InfoManager.SubInfoMode.PipeWater || subMode == InfoManager.SubInfoMode.WindPower) && SteamHelper.IsDLCOwned(SteamHelper.DLC.CampusDLC))
                                {
                                    Singleton<DistrictManager>.instance.ParksInfoVisible = true;
                                    Singleton<DistrictManager>.instance.ParkGroupsInfoVisible = DistrictPark.ParkGroup.Campus;
                                }
                                break;
                            case InfoManager.InfoMode.Entertainment:
                                if (subMode == InfoManager.SubInfoMode.Default || subMode == InfoManager.SubInfoMode.WindPower || subMode == InfoManager.SubInfoMode.LibraryEducation)
                                {
                                    Singleton<DistrictManager>.instance.ParksInfoVisible = true;
                                    Singleton<DistrictManager>.instance.ParkGroupsInfoVisible = DistrictPark.ParkGroup.ParkLife;
                                }
                                break;
                            case InfoManager.InfoMode.TerrainHeight:
                                Singleton<TerrainManager>.instance.RenderTopographyInfo = true;
                                Singleton<TerrainManager>.instance.TransparentWater = true;
                                break;
                            case InfoManager.InfoMode.Heating:
                                Singleton<WaterManager>.instance.HeatingMapVisible = true;
                                break;
                            case InfoManager.InfoMode.Maintenance:
                                break;
                            case InfoManager.InfoMode.Snow:
                                break;
                            case InfoManager.InfoMode.EscapeRoutes:
                                Singleton<TransportManager>.instance.LinesVisible = 128;
                                Singleton<TransportManager>.instance.TunnelsVisibleInfo = true;
                                Singleton<NetManager>.instance.RenderDirectionArrowsInfo = true;
                                break;
                            case InfoManager.InfoMode.Radio:
                                Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.RadioCoverage;
                                break;
                            case InfoManager.InfoMode.Destruction:
                                break;
                            case InfoManager.InfoMode.DisasterDetection:
                                if (subMode == InfoManager.SubInfoMode.Default)
                                {
                                    Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.EarthquakeCoverage;
                                }
                                else if (subMode == InfoManager.SubInfoMode.WindPower)
                                {
                                    Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.EarthquakeCoverage;
                                }
                                break;
                            case InfoManager.InfoMode.DisasterHazard:
                                Singleton<DisasterManager>.instance.HazardMapVisible = 1 << (int)subMode;
                                break;
                            case InfoManager.InfoMode.TrafficRoutes:
                                Singleton<TransportManager>.instance.TunnelsVisibleInfo = true;
                                if (subMode == InfoManager.SubInfoMode.Default)
                                {
                                    Singleton<NetManager>.instance.PathVisualizer.PathsVisible = true;
                                }
                                else if (subMode == InfoManager.SubInfoMode.WaterPower)
                                {
                                    Singleton<NetManager>.instance.RenderDirectionArrowsInfo = true;
                                }
                                else if (subMode == InfoManager.SubInfoMode.WindPower)
                                {
                                    Singleton<NetManager>.instance.NetAdjust.PathVisible = true;
                                }
                                break;
                            case InfoManager.InfoMode.Underground:
                                if (subMode == InfoManager.SubInfoMode.Default)
                                {
                                    Singleton<TransportManager>.instance.TunnelsVisibleInfo = true;
                                }
                                else if (subMode == InfoManager.SubInfoMode.WaterPower)
                                {
                                    Singleton<WaterManager>.instance.WaterMapVisible = true;
                                }
                                break;
                            case InfoManager.InfoMode.Tours:
                                Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.Attractiveness;
                                Singleton<TransportManager>.instance.LinesVisible = 3072;
                                Singleton<TransportManager>.instance.TunnelsVisibleInfo = true;
                                Singleton<NetManager>.instance.RenderDirectionArrowsInfo = true;
                                break;
                            case InfoManager.InfoMode.ParkMaintenance:
                                break;
                            case InfoManager.InfoMode.Tourism:
                                break;
                            case InfoManager.InfoMode.Post:
                                break;
                            case InfoManager.InfoMode.Industry:
                                Singleton<DistrictManager>.instance.ParksInfoVisible = true;
                                Singleton<DistrictManager>.instance.ParkGroupsInfoVisible = DistrictPark.ParkGroup.Industry;
                                if (subMode == InfoManager.SubInfoMode.WaterPower)
                                {
                                    natural = 1;
                                }
                                else if (subMode == InfoManager.SubInfoMode.Default)
                                {
                                    natural = 2;
                                }
                                else if (subMode == InfoManager.SubInfoMode.WindPower)
                                {
                                    natural = 4;
                                }
                                else if (subMode == InfoManager.SubInfoMode.PipeWater)
                                {
                                    natural = 8;
                                }
                                break;
                            case InfoManager.InfoMode.Fishing:
                                Singleton<TransportManager>.instance.LinesVisible = 32768;
                                break;
                            case InfoManager.InfoMode.ServicePoint:
                                if (SteamHelper.IsDLCOwned(SteamHelper.DLC.PlazasAndPromenadesDLC))
                                {
                                    Singleton<DistrictManager>.instance.ParksInfoVisible = true;
                                    Singleton<DistrictManager>.instance.ParkGroupsInfoVisible = DistrictPark.ParkGroup.PedestrianZone;
                                }
                                break;
                            case InfoManager.InfoMode.Financial:
                                if (SteamHelper.IsDLCOwned(SteamHelper.DLC.FinancialDistrictsDLC) && subMode == InfoManager.SubInfoMode.Default)
                                {
                                    Singleton<ImmaterialResourceManager>.instance.ResourceMapVisible = ImmaterialResourceManager.Resource.TaxBonus;
                                }
                                break;
                            default:
                                break;
                        }

                        Singleton<BuildingManager>.instance.UpdateBuildingColors();
                        Singleton<NetManager>.instance.UpdateSegmentColors();
                        Singleton<NetManager>.instance.UpdateNodeColors();

                        if (natural != 0)
                        {
                            Vector4 value = default;
                            value.x = ((natural & 1) == 0) ? 0f : 1f;
                            value.y = ((natural & 2) == 0) ? 0f : 1f;
                            value.z = ((natural & 4) == 0) ? 0f : 1f;
                            value.w = ((natural & 8) == 0) ? 0f : 1f;
                            Shader.SetGlobalVector("_NaturalResourceMask", value);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToolBaseForceInfoModePatch:Prefix -> Exception: " + e.Message);
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
                    // Notification Icons
                    ToggleHelper.UpdateNotificationIcons(true);
                }
                else
                {
                    // Notification Icons
                    ToggleManager.Instance.Apply(1);
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
                        ToggleHelper.UpdateRoadNames(false);
                        ToggleHelper.UpdateBuildings(true);
                        ToggleHelper.UpdateContourLines(false);
                        ToggleHelper.UpdateZoning(false);
                        ToggleHelper.UpdateDistrictZones(false);
                    }
                    else
                    {
                        ToggleManager.Instance.ApplyAll();
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
                    ToggleHelper.UpdateRoadNames(false);
                    ToggleHelper.UpdateBuildings(true);
                    ToggleHelper.UpdateContourLines(false);
                    ToggleHelper.UpdateZoning(false);
                    ToggleHelper.UpdateDistrictZones(false);
                }
                else
                {
                    ToggleManager.Instance.ApplyAll();
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] CinematicCameraControllerSetUIVisiblePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }
}
