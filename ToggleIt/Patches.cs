using ColossalFramework;
using Harmony;
using System;
using System.Reflection;
using UnityEngine;

namespace ToggleIt
{
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
                    Singleton<NotificationManager>.instance.NotificationsVisible = __instance.m_freeCamera ? false : !ModConfig.Instance.NotificationIcons;
                    Singleton<GameAreaManager>.instance.BordersVisible = __instance.m_freeCamera ? false : !ModConfig.Instance.LineBorders;
                    Singleton<DistrictManager>.instance.NamesVisible = __instance.m_freeCamera ? false : !ModConfig.Instance.DistrictNames;
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
                if (visible)
                {
                    Singleton<NotificationManager>.instance.NotificationsVisible = !ModConfig.Instance.NotificationIcons;
                    Singleton<GameAreaManager>.instance.BordersVisible = !ModConfig.Instance.LineBorders;
                    Singleton<DistrictManager>.instance.NamesVisible = !ModConfig.Instance.DistrictNames;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] CinematicCameraControllerSetUIVisiblePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }
}
