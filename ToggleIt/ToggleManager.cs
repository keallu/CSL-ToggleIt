using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.Reflection;
using UnityEngine;

namespace ToggleIt
{
    public class ToggleManager : MonoBehaviour
    {
        private bool _initialized;

        private UITextureAtlas _defaultIngameTextureAtlas;
        private Color _defaultValidColor;
        private Color _defaultWarningColor;
        private Color _defaultErrorColor;
        private Color _defaultMoveItHoverColor;
        private Color _defaultMoveItSelectedColor;
        private Color _defaultMoveItMoveColor;
        private Color _defaultMoveItRemoveColor;
        private Color _defaultMoveItDespawnColor;
        private Color _defaultMoveItAlignColor;
        private Color _defaultMoveItPOHoverColor;
        private Color _defaultMoveItPOSelectedColor;
        private Color _defaultMoveItPODisabledColor;

        public void Start()
        {
            try
            {
                _defaultIngameTextureAtlas = Singleton<DistrictManager>.instance.m_properties.m_areaIconAtlas;

                ToolController toolController = ToolsModifierControl.toolController;

                _defaultValidColor = toolController.m_validColor;
                _defaultWarningColor = toolController.m_warningColor;
                _defaultErrorColor = toolController.m_errorColor;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Start -> Exception: " + e.Message);
            }
        }

        public void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    ToggleNotificationIcons(ModConfig.Instance.NotificationIcons);
                    ToggleDistrictNames(ModConfig.Instance.DistrictNames);
                    ToggleDistrictIcons(ModConfig.Instance.DistrictIcons);
                    ToggleLineBorders(ModConfig.Instance.LineBorders);
                    ToggleToolColor(ModConfig.Instance.DefaultToolColors, ModConfig.Instance.MoveItToolColors);

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }

                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H))
                {
                    SelectToggle(ModConfig.Instance.Keymapping1);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.I))
                {
                    SelectToggle(ModConfig.Instance.Keymapping2);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.J))
                {
                    SelectToggle(ModConfig.Instance.Keymapping3);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.K))
                {
                    SelectToggle(ModConfig.Instance.Keymapping4);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
                {
                    SelectToggle(ModConfig.Instance.Keymapping5);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.M))
                {
                    SelectToggle(ModConfig.Instance.Keymapping6);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Update -> Exception: " + e.Message);
            }
        }

        private void SelectToggle(string keymapping)
        {
            try
            {
                switch (keymapping)
                {
                    case "Notification Icons":
                        ModConfig.Instance.NotificationIcons = !ModConfig.Instance.NotificationIcons;
                        ToggleNotificationIcons(ModConfig.Instance.NotificationIcons);
                        break;
                    case "District Names":
                        ModConfig.Instance.DistrictNames = !ModConfig.Instance.DistrictNames;
                        ToggleDistrictNames(ModConfig.Instance.DistrictNames);
                        break;
                    case "District Icons":
                        ModConfig.Instance.DistrictIcons = !ModConfig.Instance.DistrictIcons;
                        ToggleDistrictIcons(ModConfig.Instance.DistrictIcons);
                        break;
                    case "Line Borders":
                        ModConfig.Instance.LineBorders = !ModConfig.Instance.LineBorders;
                        ToggleLineBorders(ModConfig.Instance.LineBorders);
                        break;
                    case "Default Tool Colors":
                        ModConfig.Instance.DefaultToolColors = !ModConfig.Instance.DefaultToolColors;
                        ToggleToolColor(ModConfig.Instance.DefaultToolColors, ModConfig.Instance.MoveItToolColors);
                        break;
                    case "Move It! Tool Colors":
                        ModConfig.Instance.MoveItToolColors = !ModConfig.Instance.MoveItToolColors;
                        ToggleToolColor(ModConfig.Instance.DefaultToolColors, ModConfig.Instance.MoveItToolColors);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:SelectToggle -> Exception: " + e.Message);
            }
        }

        private void ToggleNotificationIcons(bool disableNotificationIcons)
        {
            try
            {
                Singleton<NotificationManager>.instance.NotificationsVisible = !disableNotificationIcons;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleeManager:ToggleNotificationIcons -> Exception: " + e.Message);
            }
        }

        private void ToggleDistrictNames(bool disableDistrictNames)
        {
            try
            {
                Singleton<DistrictManager>.instance.NamesVisible = !disableDistrictNames;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleDistrictNames -> Exception: " + e.Message);
            }
        }

        private void ToggleDistrictIcons(bool disableDistrictIcons)
        {
            try
            {
                DistrictManager districtManager = Singleton<DistrictManager>.instance;

                if (disableDistrictIcons)
                {
                    districtManager.m_properties.m_areaIconAtlas = null;
                }
                else
                {
                    districtManager.m_properties.m_areaIconAtlas = _defaultIngameTextureAtlas;
                }

                districtManager.NamesModified();
                districtManager.ParkNamesModified();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleDistrictIcons -> Exception: " + e.Message);
            }
        }

        private void ToggleLineBorders(bool disableLineBorders)
        {
            try
            {
                Singleton<GameAreaManager>.instance.BordersVisible = !disableLineBorders;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleLineBorders -> Exception: " + e.Message);
            }
        }

        private void ToggleToolColor(bool disableDefaultToolColors, bool disableMoveItToolColors)
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                if (toolController != null)
                {
                    toolController.m_validColor.a = disableDefaultToolColors ? 0f : _defaultValidColor.a;
                    toolController.m_warningColor.a = disableDefaultToolColors ? 0f : _defaultWarningColor.a;
                    toolController.m_errorColor.a = disableDefaultToolColors ? 0f : _defaultErrorColor.a;
                }

                if (ModUtils.IsModEnabled("moveit"))
                {
                    ToggleMoveItColor(disableMoveItToolColors, "m_hoverColor", ref _defaultMoveItHoverColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_selectedColor", ref _defaultMoveItSelectedColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_moveColor", ref _defaultMoveItMoveColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_removeColor", ref _defaultMoveItRemoveColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_despawnColor", ref _defaultMoveItDespawnColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_alignColor", ref _defaultMoveItAlignColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_POhoverColor", ref _defaultMoveItPOHoverColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_POselectedColor", ref _defaultMoveItPOSelectedColor);
                    ToggleMoveItColor(disableMoveItToolColors, "m_POdisabledColor", ref _defaultMoveItPODisabledColor);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleToolColor -> Exception: " + e.Message);
            }
        }

        private void ToggleMoveItColor(bool disable, string colorName, ref Color defaultColor)
        {
            try
            {
                FieldInfo fieldInfo;
                Color color;

                fieldInfo = Type.GetType("MoveIt.MoveItTool, MoveIt").GetField(colorName, BindingFlags.NonPublic | BindingFlags.Static);

                if (fieldInfo != null)
                {
                    if (defaultColor.r == 0f && defaultColor.g == 0f && defaultColor.b == 0f && defaultColor.a == 0f)
                    {
                        defaultColor = (Color)fieldInfo.GetValue(null);
                    }

                    color = new Color()
                    {
                        r = defaultColor.r,
                        g = defaultColor.g,
                        b = defaultColor.b,
                        a = disable ? 0f : defaultColor.a
                    };
                    fieldInfo.SetValue(null, color);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleMoveItColor -> Exception: " + e.Message);
            }
        }
    }
}
