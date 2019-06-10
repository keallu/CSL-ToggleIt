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

        private UIButton _esc;

        private UIPanel _togglePanel;
        private UIDragHandle _toggleDragHandle;
        private UIPanel _toggleInnerPanel;
        private UICheckBox[] _toggleCheckboxes;

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

        public void Awake()
        {
            try
            {
                if (_esc == null)
                {
                    _esc = GameObject.Find("Esc").GetComponent<UIButton>();
                    ToggleProperties.Instance.PanelDefaultPositionX = _esc.absolutePosition.x - 800f;
                    ToggleProperties.Instance.PanelDefaultPositionY = _esc.absolutePosition.y;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Awake -> Exception: " + e.Message);
            }
        }

        public void Start()
        {
            try
            {
                _defaultIngameTextureAtlas = Singleton<DistrictManager>.instance.m_properties.m_areaIconAtlas;

                ToolController toolController = ToolsModifierControl.toolController;

                _defaultValidColor = toolController.m_validColor;
                _defaultWarningColor = toolController.m_warningColor;
                _defaultErrorColor = toolController.m_errorColor;

                if (ModConfig.Instance.PositionX == 0.0f)
                {
                    ModConfig.Instance.PositionX = ToggleProperties.Instance.PanelDefaultPositionX;
                }

                if (ModConfig.Instance.PositionY == 0.0f)
                {
                    ModConfig.Instance.PositionY = ToggleProperties.Instance.PanelDefaultPositionY;
                }

                _toggleCheckboxes = new UICheckBox[6];

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Start -> Exception: " + e.Message);
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
                Debug.Log("[Toggle It!] ToggleManager:OnDestroy -> Exception: " + e.Message);
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

                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H))
                {
                    SelectToggle(1);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.I))
                {
                    SelectToggle(2);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.J))
                {
                    SelectToggle(3);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.K))
                {
                    SelectToggle(4);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
                {
                    SelectToggle(5);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.M))
                {
                    SelectToggle(6);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Update -> Exception: " + e.Message);
            }
        }

        private void CreateUI()
        {
            try
            {
                _togglePanel = UIUtils.CreatePanel("ToggleItTogglePanel");
                _togglePanel.zOrder = 0;
                _togglePanel.backgroundSprite = "SubcategoriesPanel";
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
                _toggleInnerPanel.backgroundSprite = "GenericPanel";
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
                Debug.Log("[Toggle It!] ToggleManager:CreateUI -> Exception: " + e.Message);
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
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:UpdateUI -> Exception: " + e.Message);
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
                Debug.Log("[Toggle It!] ToggleManager:CreateTooltip -> Exception: " + e.Message);
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
                        return ModConfig.Instance.NotificationIcons;
                    case 2:
                        return ModConfig.Instance.DistrictNames;
                    case 3:
                        return ModConfig.Instance.DistrictIcons;
                    case 4:
                        return ModConfig.Instance.LineBorders;
                    case 5:
                        return ModConfig.Instance.DefaultToolColors;
                    case 6:
                        return ModConfig.Instance.MoveItToolColors;
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:GetToggleState -> Exception: " + e.Message);
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
                Debug.Log("[Toggle It!] ToggleManager:SelectToggle -> Exception: " + e.Message);
            }
        }

        private void DoToggle(int toggle, bool autoToggle = true, bool enable = true)
        {
            try
            {
                switch (toggle)
                {
                    case 1:
                        ModConfig.Instance.NotificationIcons = autoToggle ? !ModConfig.Instance.NotificationIcons : enable;
                        ToggleNotificationIcons(ModConfig.Instance.NotificationIcons);
                        break;
                    case 2:
                        ModConfig.Instance.DistrictNames = autoToggle ? !ModConfig.Instance.DistrictNames : enable;
                        ToggleDistrictNames(ModConfig.Instance.DistrictNames);
                        break;
                    case 3:
                        ModConfig.Instance.DistrictIcons = autoToggle ? !ModConfig.Instance.DistrictIcons : enable;
                        ToggleDistrictIcons(ModConfig.Instance.DistrictIcons);
                        break;
                    case 4:
                        ModConfig.Instance.LineBorders = autoToggle ? !ModConfig.Instance.LineBorders : enable;
                        ToggleLineBorders(ModConfig.Instance.LineBorders);
                        break;
                    case 5:
                        ModConfig.Instance.DefaultToolColors = autoToggle ? !ModConfig.Instance.DefaultToolColors : enable;
                        ToggleDefaultToolColor(ModConfig.Instance.DefaultToolColors);
                        break;
                    case 6:
                        ModConfig.Instance.MoveItToolColors = autoToggle ? !ModConfig.Instance.MoveItToolColors : enable;
                        ToggleMoveItToolColor(ModConfig.Instance.MoveItToolColors);
                        break;
                    default:
                        break;
                }

                ModConfig.Instance.SaveWithoutUpdate();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:DoToggle -> Exception: " + e.Message);
            }
        }

        private void ToggleNotificationIcons(bool enableNotificationIcons)
        {
            try
            {
                Singleton<NotificationManager>.instance.NotificationsVisible = enableNotificationIcons;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleeManager:ToggleNotificationIcons -> Exception: " + e.Message);
            }
        }

        private void ToggleDistrictNames(bool enableDistrictNames)
        {
            try
            {
                Singleton<DistrictManager>.instance.NamesVisible = enableDistrictNames;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleDistrictNames -> Exception: " + e.Message);
            }
        }

        private void ToggleDistrictIcons(bool enableDistrictIcons)
        {
            try
            {
                DistrictManager districtManager = Singleton<DistrictManager>.instance;

                if (enableDistrictIcons)
                {
                    districtManager.m_properties.m_areaIconAtlas = _defaultIngameTextureAtlas;
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
                Debug.Log("[Toggle It!] ToggleManager:ToggleDistrictIcons -> Exception: " + e.Message);
            }
        }

        private void ToggleLineBorders(bool enableLineBorders)
        {
            try
            {
                Singleton<GameAreaManager>.instance.BordersVisible = enableLineBorders;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleLineBorders -> Exception: " + e.Message);
            }
        }

        private void ToggleDefaultToolColor(bool enableDefaultToolColors)
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                if (toolController != null)
                {
                    toolController.m_validColor.a = enableDefaultToolColors ? _defaultValidColor.a : 0f;
                    toolController.m_warningColor.a = enableDefaultToolColors ? _defaultWarningColor.a : 0f;
                    toolController.m_errorColor.a = enableDefaultToolColors ? _defaultErrorColor.a : 0f;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleDefaultToolColor -> Exception: " + e.Message);
            }
        }

        private void ToggleMoveItToolColor(bool enableMoveItToolColors)
        {
            try
            {
                if (ModUtils.IsModEnabled("moveit"))
                {
                    ToggleMoveItColor(enableMoveItToolColors, "m_hoverColor", ref _defaultMoveItHoverColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_selectedColor", ref _defaultMoveItSelectedColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_moveColor", ref _defaultMoveItMoveColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_removeColor", ref _defaultMoveItRemoveColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_despawnColor", ref _defaultMoveItDespawnColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_alignColor", ref _defaultMoveItAlignColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_POhoverColor", ref _defaultMoveItPOHoverColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_POselectedColor", ref _defaultMoveItPOSelectedColor);
                    ToggleMoveItColor(enableMoveItToolColors, "m_POdisabledColor", ref _defaultMoveItPODisabledColor);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ToggleMoveItToolColor -> Exception: " + e.Message);
            }
        }

        private void ToggleMoveItColor(bool enable, string colorName, ref Color defaultColor)
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
                        a = enable ? defaultColor.a : 0f
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
