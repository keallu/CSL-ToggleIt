using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;
using ToggleIt.Helpers;

namespace ToggleIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;

        private UIButton _esc;

        private UIPanel _togglePanel;
        private UIDragHandle _toggleDragHandle;
        private UIPanel _toggleInnerPanel;
        private UICheckBox[] _toggleCheckboxes;

        private UITextureAtlas _defaultIngameTextureAtlas;
        private Color _defaultZoneEdgeColor;
        private Color _defaultZoneEdgeColorInfo;
        private Color _defaultZoneEdgeColorOccupiedColor;
        private Color _defaultZoneEdgeColorOccupiedInfo;
        private Color _defaultZoneFillColor;
        private Color _defaultZoneFillColorInfo;
        private Color _defaultValidColor;
        private Color _defaultWarningColor;
        private Color _defaultErrorColor;

        public void Awake()
        {
            try
            {
                if (_esc == null)
                {
                    _esc = GameObject.Find("Esc").GetComponent<UIButton>();
                    ModProperties.Instance.PanelDefaultPositionX = _esc.absolutePosition.x - 800f;
                    ModProperties.Instance.PanelDefaultPositionY = _esc.absolutePosition.y;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:Awake -> Exception: " + e.Message);
            }
        }

        public void Start()
        {
            try
            {
                _defaultIngameTextureAtlas = Singleton<DistrictManager>.instance.m_properties.m_areaIconAtlas;

                _defaultZoneEdgeColor = Shader.GetGlobalColor("_ZoneEdgeColor");
                _defaultZoneEdgeColorInfo = Shader.GetGlobalColor("_ZoneEdgeColorInfo");
                _defaultZoneEdgeColorOccupiedColor = Shader.GetGlobalColor("_ZoneEdgeColorOccupied");
                _defaultZoneEdgeColorOccupiedInfo = Shader.GetGlobalColor("_ZoneEdgeColorOccupiedInfo");
                _defaultZoneFillColor = Shader.GetGlobalColor("_ZoneFillColor");
                _defaultZoneFillColorInfo = Shader.GetGlobalColor("_ZoneFillColorInfo");

                ToolController toolController = ToolsModifierControl.toolController;
                _defaultValidColor = toolController.m_validColor;
                _defaultWarningColor = toolController.m_warningColor;
                _defaultErrorColor = toolController.m_errorColor;

                if (ModConfig.Instance.PositionX == 0.0f)
                {
                    ModConfig.Instance.PositionX = ModProperties.Instance.PanelDefaultPositionX;
                }

                if (ModConfig.Instance.PositionY == 0.0f)
                {
                    ModConfig.Instance.PositionY = ModProperties.Instance.PanelDefaultPositionY;
                }

                _toggleCheckboxes = new UICheckBox[6];

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:Start -> Exception: " + e.Message);
            }
        }

        public void OnDestroy()
        {
            try
            {
                foreach (UICheckBox checkbox in _toggleCheckboxes)
                {
                    Destroy(checkbox);
                }
                if (_toggleInnerPanel != null)
                {
                    Destroy(_toggleInnerPanel);
                }
                if (_toggleDragHandle != null)
                {
                    Destroy(_toggleDragHandle);
                }
                if (_togglePanel != null)
                {
                    Destroy(_togglePanel);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:OnDestroy -> Exception: " + e.Message);
            }
        }

        public void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    UpdateUI();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }

                if (KeyChecker.GetKeyCombo(out int key))
                {
                    SelectToggle(key);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:Update -> Exception: " + e.Message);
            }
        }

        private void CreateUI()
        {
            try
            {
                _togglePanel = UIUtils.CreatePanel("ToggleItTogglePanel");
                _togglePanel.zOrder = 25;
                _togglePanel.backgroundSprite = "GenericPanelLight";
                _togglePanel.color = new Color32(96, 96, 96, 255);
                _togglePanel.size = new Vector2(242f, 62f);

                _toggleDragHandle = UIUtils.CreateDragHandle(_togglePanel, "ToggleDragHandle");
                _toggleDragHandle.size = new Vector2(_toggleDragHandle.parent.width, _toggleDragHandle.parent.height);
                _toggleDragHandle.relativePosition = new Vector3(0f, 0f);
                _toggleDragHandle.eventMouseUp += (component, eventParam) =>
                {
                    ModConfig.Instance.PositionX = _togglePanel.absolutePosition.x;
                    ModConfig.Instance.PositionY = _togglePanel.absolutePosition.y;
                    ModConfig.Instance.Save();
                };

                _toggleInnerPanel = UIUtils.CreatePanel(_togglePanel, "ToggleInnerPanel");
                _toggleInnerPanel.backgroundSprite = "GenericPanelLight";
                _toggleInnerPanel.color = new Color32(206, 206, 206, 255);
                _toggleInnerPanel.size = new Vector2(_toggleInnerPanel.parent.width - 16f, _toggleInnerPanel.parent.height - 16f);
                _toggleInnerPanel.relativePosition = new Vector3(8f, 8f);

                string capitalLetter;

                for (int i = 0; i < 6; i++)
                {
                    capitalLetter = ((char)(65 + i)).ToString();

                    UICheckBox checkbox = UIUtils.CreateButtonCheckBox(_toggleInnerPanel, "Toggle" + capitalLetter, capitalLetter, false);
                    checkbox.objectUserData = i;
                    checkbox.relativePosition = new Vector3(5f + i * 36f, 5f);
                    checkbox.eventCheckChanged += (component, value) =>
                    {
                        DoToggle(ModConfig.Instance.Toggles[(int)checkbox.objectUserData], false, value);
                    };

                    _toggleCheckboxes[i] = checkbox;
                }

                UpdateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {
                _togglePanel.absolutePosition = new Vector3(ModConfig.Instance.PositionX, ModConfig.Instance.PositionY);
                _togglePanel.isVisible = ModConfig.Instance.ShowTogglePanel;

                for (int i = 0; i < 6; i++)
                {
                    if (ModConfig.Instance.Toggles[i] == 0)
                    {
                        _toggleCheckboxes[i].tooltip = "Unassigned";
                        _toggleCheckboxes[i].isChecked = false;
                        _toggleCheckboxes[i].isEnabled = false;
                    }
                    else
                    {
                        _toggleCheckboxes[i].isEnabled = true;
                        _toggleCheckboxes[i].isChecked = GetToggleState(ModConfig.Instance.Toggles[i]);
                        _toggleCheckboxes[i].tooltip = CreateTooltip(ModConfig.Instance.Toggles[i], ModConfig.Instance.Keymappings[i]);

                        DoToggle(ModConfig.Instance.Toggles[(int)_toggleCheckboxes[i].objectUserData], false, _toggleCheckboxes[i].isChecked);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:UpdateUI -> Exception: " + e.Message);
            }
        }

        private string CreateTooltip(int toggle, int keymapping)
        {
            try
            {
                string tooltip = ModInfo.ToggleLabels[toggle];
                tooltip += Environment.NewLine + Environment.NewLine;
                tooltip += "<color #50869a>" + ModInfo.KeymappingLabels[keymapping] + "</color>";

                return tooltip;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:CreateTooltip -> Exception: " + e.Message);
                return string.Empty;
            }
        }

        private bool GetToggleState(int toggle)
        {
            try
            {
                switch (toggle)
                {
                    case 1:
                        return ModConfig.Instance.AutomaticInfoViews;
                    case 2:
                        return ModConfig.Instance.NotificationIcons;
                    case 3:
                        return ModConfig.Instance.RoadNames;
                    case 4:
                        return ModConfig.Instance.Buildings;
                    case 5:
                        return ModConfig.Instance.BorderLines;
                    case 6:
                        return ModConfig.Instance.ContourLines;
                    case 7:
                        return ModConfig.Instance.Zoning;
                    case 8:
                        return ModConfig.Instance.ZoningGrid;
                    case 9:
                        return ModConfig.Instance.ZoningColor;
                    case 10:
                        return ModConfig.Instance.DistrictZones;
                    case 11:
                        return ModConfig.Instance.DistrictNames;
                    case 12:
                        return ModConfig.Instance.DistrictIcons;
                    case 13:
                        return ModConfig.Instance.Tunnels;
                    case 14:
                        return ModConfig.Instance.WaterPipes;
                    case 15:
                        return ModConfig.Instance.HeatingPipes;
                    case 16:
                        return ModConfig.Instance.DefaultToolColors;
                    case 17:
                        return ModConfig.Instance.DefaultToolInfo;
                    case 18:
                        return ModConfig.Instance.DefaultToolExtraInfo;
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:GetToggleState -> Exception: " + e.Message);
                return false;
            }
        }

        private void SelectToggle(int key)
        {
            try
            {
                if (ModConfig.Instance.Keymappings[0] == key)
                {
                    _toggleCheckboxes[0].isChecked = !_toggleCheckboxes[0].isChecked;
                }
                if (ModConfig.Instance.Keymappings[1] == key)
                {
                    _toggleCheckboxes[1].isChecked = !_toggleCheckboxes[1].isChecked;
                }
                if (ModConfig.Instance.Keymappings[2] == key)
                {
                    _toggleCheckboxes[2].isChecked = !_toggleCheckboxes[2].isChecked;
                }
                if (ModConfig.Instance.Keymappings[3] == key)
                {
                    _toggleCheckboxes[3].isChecked = !_toggleCheckboxes[3].isChecked;
                }
                if (ModConfig.Instance.Keymappings[4] == key)
                {
                    _toggleCheckboxes[4].isChecked = !_toggleCheckboxes[4].isChecked;
                }
                if (ModConfig.Instance.Keymappings[5] == key)
                {
                    _toggleCheckboxes[5].isChecked = !_toggleCheckboxes[5].isChecked;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:SelectToggle -> Exception: " + e.Message);
            }
        }

        private void DoToggle(int toggle, bool autoToggle = true, bool enable = true)
        {
            try
            {
                switch (toggle)
                {
                    case 1:
                        ModConfig.Instance.AutomaticInfoViews = autoToggle ? !ModConfig.Instance.AutomaticInfoViews : enable;
                        break;
                    case 2:
                        ModConfig.Instance.NotificationIcons = autoToggle ? !ModConfig.Instance.NotificationIcons : enable;
                        ToggleHelper.UpdateNotificationIcons(ModConfig.Instance.NotificationIcons);
                        break;
                    case 3:
                        ModConfig.Instance.RoadNames = autoToggle ? !ModConfig.Instance.RoadNames : enable;
                        ToggleHelper.UpdateRoadNames(ModConfig.Instance.RoadNames);
                        break;
                    case 4:
                        ModConfig.Instance.Buildings = autoToggle ? !ModConfig.Instance.Buildings : enable;
                        ToggleHelper.UpdateBuildings(ModConfig.Instance.Buildings);
                        break;
                    case 5:
                        ModConfig.Instance.BorderLines = autoToggle ? !ModConfig.Instance.BorderLines : enable;
                        ToggleHelper.UpdateBorderLines(ModConfig.Instance.BorderLines);
                        break;
                    case 6:
                        ModConfig.Instance.ContourLines = autoToggle ? !ModConfig.Instance.ContourLines : enable;
                        ToggleHelper.UpdateContourLines(ModConfig.Instance.ContourLines);
                        break;
                    case 7:
                        ModConfig.Instance.Zoning = autoToggle ? !ModConfig.Instance.Zoning : enable;
                        ToggleHelper.UpdateZoning(ModConfig.Instance.Zoning);
                        break;
                    case 8:
                        ModConfig.Instance.ZoningGrid = autoToggle ? !ModConfig.Instance.ZoningGrid : enable;
                        ToggleHelper.UpdateZoningGrid(ModConfig.Instance.ZoningGrid, _defaultZoneEdgeColor, _defaultZoneEdgeColorInfo, _defaultZoneEdgeColorOccupiedColor, _defaultZoneEdgeColorOccupiedInfo);
                        break;
                    case 9:
                        ModConfig.Instance.ZoningColor = autoToggle ? !ModConfig.Instance.ZoningColor : enable;
                        ToggleHelper.UpdateZoningColor(ModConfig.Instance.ZoningColor, _defaultZoneFillColor, _defaultZoneFillColorInfo);
                        break;
                    case 10:
                        ModConfig.Instance.DistrictZones = autoToggle ? !ModConfig.Instance.DistrictZones : enable;
                        ToggleHelper.UpdateDistrictZones(ModConfig.Instance.DistrictZones);
                        break;
                    case 11:
                        ModConfig.Instance.DistrictNames = autoToggle ? !ModConfig.Instance.DistrictNames : enable;
                        ToggleHelper.UpdateDistrictNames(ModConfig.Instance.DistrictNames);
                        break;
                    case 12:
                        ModConfig.Instance.DistrictIcons = autoToggle ? !ModConfig.Instance.DistrictIcons : enable;
                        ToggleHelper.UpdateDistrictIcons(ModConfig.Instance.DistrictIcons, _defaultIngameTextureAtlas);
                        break;
                    case 13:
                        ModConfig.Instance.Tunnels = autoToggle ? !ModConfig.Instance.Tunnels : enable;
                        ToggleHelper.UpdateTunnels(ModConfig.Instance.Tunnels);
                        break;
                    case 14:
                        ModConfig.Instance.WaterPipes = autoToggle ? !ModConfig.Instance.WaterPipes : enable;
                        ToggleHelper.UpdateWaterPipes(ModConfig.Instance.WaterPipes);
                        break;
                    case 15:
                        ModConfig.Instance.HeatingPipes = autoToggle ? !ModConfig.Instance.HeatingPipes : enable;
                        ToggleHelper.UpdateHeatingPipes(ModConfig.Instance.HeatingPipes);
                        break;
                    case 16:
                        ModConfig.Instance.DefaultToolColors = autoToggle ? !ModConfig.Instance.DefaultToolColors : enable;
                        ToggleHelper.UpdateDefaultToolColor(ModConfig.Instance.DefaultToolColors, _defaultValidColor, _defaultWarningColor, _defaultErrorColor);
                        break;
                    case 17:
                        ModConfig.Instance.DefaultToolInfo = autoToggle ? !ModConfig.Instance.DefaultToolInfo : enable;
                        break;
                    case 18:
                        ModConfig.Instance.DefaultToolExtraInfo = autoToggle ? !ModConfig.Instance.DefaultToolExtraInfo : enable;
                        break;
                    default:
                        break;
                }

                ModConfig.Instance.SaveWithoutUpdate();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:DoToggle -> Exception: " + e.Message);
            }
        }
    }
}
