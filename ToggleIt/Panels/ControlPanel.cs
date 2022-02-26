using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using ToggleIt.Managers;
using System.Linq;

namespace ToggleIt.Panels
{
    public class ControlPanel : UIPanel
    {
        private bool _initialized;

        private TogglePanel _togglePanel;

        private UITextureAtlas _toggleItAtlas;
        private UIDragHandle _dragHandle;
        private UIPanel _innerPanel;
        private List<UICheckBox> _toggles;
        private UIButton _optionsButton;
        private UIButton _resetButton;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:Awake -> Exception: " + e.Message);
            }
        }

        public override void Start()
        {
            base.Start();

            try
            {
                if (_togglePanel == null)
                {
                    _togglePanel = GameObject.Find("ToggleItTogglePanel")?.GetComponent<TogglePanel>();
                }

                if (ModConfig.Instance.PanelPositionX == 0f && ModConfig.Instance.PanelPositionY == 0f)
                {
                    ModProperties.Instance.ResetPanelPosition();
                }

                _toggleItAtlas = LoadResources();

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:Start -> Exception: " + e.Message);
            }
        }

        public override void Update()
        {
            base.Update();

            try
            {
                if (!_initialized)
                {
                    UpdateUI();

                    _initialized = true;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:Update -> Exception: " + e.Message);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            try
            {
                DestroyGameObject(_resetButton);
                DestroyGameObject(_optionsButton);
                foreach (UICheckBox checkBox in _toggles)
                {
                    DestroyGameObject(checkBox);
                }
                DestroyGameObject(_innerPanel);
                DestroyGameObject(_dragHandle);
                if (_toggleItAtlas != null)
                {
                    Destroy(_toggleItAtlas);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                Destroy(component.gameObject);
            }
        }

        private UITextureAtlas LoadResources()
        {
            try
            {
                if (_toggleItAtlas == null)
                {
                    string[] spriteNames = new string[]
                    {
                        "options",
                        "reset"
                    };

                    _toggleItAtlas = ResourceLoader.CreateTextureAtlas("ToggleItAtlas", spriteNames, "ToggleIt.Icons.");

                    UITextureAtlas defaultAtlas = ResourceLoader.GetAtlas("Ingame");
                    Texture2D[] textures = new Texture2D[]
                    {
                        defaultAtlas["OptionBase"].texture,
                        defaultAtlas["OptionBaseFocused"].texture,
                        defaultAtlas["OptionBaseHovered"].texture,
                        defaultAtlas["OptionBasePressed"].texture,
                        defaultAtlas["OptionBaseDisabled"].texture
                    };

                    ResourceLoader.AddTexturesInAtlas(_toggleItAtlas, textures);
                }

                return _toggleItAtlas;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:LoadResources -> Exception: " + e.Message);
                return null;
            }
        }

        public void ForceUpdateUI()
        {
            UpdateUI();
        }

        private void CreateUI()
        {
            try
            {
                zOrder = 25;
                backgroundSprite = "GenericPanelLight";
                color = new Color32(96, 96, 96, 255);
                height = 62f;

                _dragHandle = UIUtils.CreateDragHandle(this, "DragHandle");
                _dragHandle.height = _dragHandle.parent.height;
                _dragHandle.relativePosition = new Vector3(0f, 0f);
                _dragHandle.eventMouseUp += (component, eventParam) =>
                {
                    ModConfig.Instance.PanelPositionX = _dragHandle.parent.absolutePosition.x;
                    ModConfig.Instance.PanelPositionY = _dragHandle.parent.absolutePosition.y;
                    ModConfig.Instance.Save();
                };

                _innerPanel = UIUtils.CreatePanel(this, "InnerPanel");
                _innerPanel.backgroundSprite = "GenericPanelLight";
                _innerPanel.color = new Color32(206, 206, 206, 255);
                _innerPanel.height = _innerPanel.parent.height - 16f;
                _innerPanel.relativePosition = new Vector3(8f, 8f);

                if (_toggles == null)
                {
                    _toggles = new List<UICheckBox>();
                }

                for (int i = 0; i < ToggleManager.Instance.AllToggles.Count; i++)
                {
                    UICheckBox checkbox = UIUtils.CreateButtonCheckBox(_innerPanel, "CheckBox" + i, _toggleItAtlas, "", false);
                    checkbox.isVisible = false;
                    checkbox.relativePosition = new Vector3(5f + i * 36f, 5f);
                    checkbox.eventCheckChanged += (component, value) =>
                    {
                        if (component.objectUserData != null)
                        {
                            ToggleManager.Instance.Apply((int)component.objectUserData, value);
                            ToggleManager.Instance.Save();
                        }
                    };

                    _toggles.Add(checkbox);
                }

                _optionsButton = UIUtils.CreateButton(this, "OptionsButton", _toggleItAtlas, "options");
                _optionsButton.tooltip = "Open settings panel";
                _optionsButton.height = 20f;
                _optionsButton.width = 20f;
                _optionsButton.eventClicked += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        if (_togglePanel != null)
                        {
                            if (_togglePanel.isVisible)
                            {
                                _togglePanel.Hide();
                            }
                            else
                            {
                                _togglePanel.Show();
                            }
                        }

                        eventParam.Use();
                    }
                };

                _resetButton = UIUtils.CreateButton(this, "ResetButton", _toggleItAtlas, "reset");
                _resetButton.tooltip = "Reset all toggle values to default";
                _resetButton.height = 20f;
                _resetButton.width = 20f;
                _resetButton.eventClicked += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        ToggleManager.Instance.ResetAll();
                        ToggleManager.Instance.Save();

                        eventParam.Use();
                    }
                };

                UpdateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {
                List<Toggle> toggles = ToggleManager.Instance.AllToggles.Where(x => x.Enabled && x.ShowInPanel).ToList();

                width = 16f + 24f + 10f + toggles.Count * 36f;
                absolutePosition = new Vector3(ModConfig.Instance.PanelPositionX, ModConfig.Instance.PanelPositionY);
                isVisible = ModConfig.Instance.ShowPanel;

                _dragHandle.width = _dragHandle.parent.width;
                _innerPanel.width = _innerPanel.parent.width - 16f - 24f;

                for (int i = 0; i < _toggles.Count; i++)
                {
                    if (i < toggles.Count)
                    {
                        _toggles[i].objectUserData = toggles[i].Id;
                        _toggles[i].tooltip = FormatTooltip(toggles[i].Id, toggles[i].KeymappingId);
                        _toggles[i].isChecked = toggles[i].On;

                        UIButton button = _toggles[i].GetComponentInChildren<UIButton>();
                        button.text = toggles[i].Glyph;

                        _toggles[i].Show();
                    }
                    else
                    {
                        _toggles[i].Hide();

                        _toggles[i].objectUserData = null;
                        _toggles[i].tooltip = string.Empty;

                        UIButton button = _toggles[i].GetComponentInChildren<UIButton>();
                        button.text = string.Empty;
                    }
                }

                _optionsButton.relativePosition = new Vector3(_optionsButton.parent.width - 28f, 8f);
                _resetButton.relativePosition = new Vector3(_resetButton.parent.width - 28f, 34f);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        private string FormatTooltip(int toggle, int keymapping)
        {
            try
            {
                string tooltip = ModInvariables.ToggleNames[toggle];
                tooltip += Environment.NewLine + Environment.NewLine;
                tooltip += "<color #50869a>" + ModInvariables.KeymappingNames[keymapping] + "</color>";

                return tooltip;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ControlPanel:FormatTooltip -> Exception: " + e.Message);
                return string.Empty;
            }
        }
    }
}
