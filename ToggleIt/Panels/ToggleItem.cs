using ColossalFramework.UI;
using System;
using UnityEngine;
using ToggleIt.Managers;

namespace ToggleIt.Panels
{
    public class ToggleItem
    {
        public string Name { get; set; }
        public Toggle Toggle { get; set; }

        private UIPanel _panel;
        private UIButton _up;
        private UIButton _down;
        private UILabel _title;
        private UILabel _default;
        private UICheckBox _enabled;
        private UICheckBox _showInPanel;
        private UILabel _keymappingLabel;
        private UIDropDown _keymapping;
        private UILabel _glyphLabel;
        private UITextField _glyph;
        private UISprite _divider;

        public void CreateToggleItem(UIComponent parent, string name, int index, UITextureAtlas atlas)
        {
            try
            {
                Name = name;

                _panel = UIUtils.CreatePanel(parent, name);
                _panel.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left;
                _panel.height = 150f;
                _panel.width = parent.width;
                _panel.relativePosition = new Vector3(25f, 75f + (25f * index));

                if (index > 0)
                {
                    _up = UIUtils.CreateSpriteButton(_panel, "Up", atlas, "IconUpArrow2");
                    _up.height = 24f;
                    _up.width = 24f;
                    _up.relativePosition = new Vector3(10f, (_up.parent.height / 3f) - _up.height / 2f);
                    _up.eventClicked += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            ToggleManager.Instance.Move(Toggle.Id, -1);

                            eventParam.Use();
                        }
                    };
                }

                if (index < ToggleManager.Instance.AllToggles.Count - 1)
                {
                    _down = UIUtils.CreateSpriteButton(_panel, "Down", atlas, "IconDownArrow2");
                    _down.height = 24f;
                    _down.width = 24f;
                    _down.relativePosition = new Vector3(10f, (_down.parent.height / 3f * 2f) - _down.height / 2f);
                    _down.eventClicked += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            ToggleManager.Instance.Move(Toggle.Id, 1);

                            eventParam.Use();
                        }
                    };
                }

                _title = UIUtils.CreateTitle(_panel, "Title", "Title");
                _title.width = _title.parent.width / 2f - 20f;
                _title.relativePosition = new Vector3(60f, 10f);

                _default = UIUtils.CreateLabel(_panel, "Default", "Default: ");
                _default.width = _default.parent.width / 2f - 20f;
                _default.relativePosition = new Vector3(560f, 10f);

                _enabled = UIUtils.CreateCheckBox(_panel, "Enabled", atlas, "Enabled", false);
                _enabled.tooltip = "Enable toggle";
                _enabled.width = _enabled.parent.width / 2f - 20f;
                _enabled.relativePosition = new Vector3(60f, 40f);
                _enabled.eventCheckChanged += (component, value) =>
                {
                    if (Toggle != null)
                    {
                        if (value)
                        {
                            Toggle.Enabled = true;

                            Toggle.On = Toggle.On;
                            ToggleManager.Instance.Apply(Toggle);
                        }
                        else
                        {
                            Toggle.On = ToggleManager.Instance.GetDefault(Toggle.Id);
                            ToggleManager.Instance.Apply(Toggle);

                            Toggle.Enabled = false;
                        }

                        ToggleManager.Instance.Save();
                    }
                };

                _showInPanel = UIUtils.CreateCheckBox(_panel, "ShowInPanel", atlas, "Show in Panel", false);
                _showInPanel.tooltip = "Show toggle in panel (when enabled)";
                _showInPanel.width = _showInPanel.parent.width / 2f - 20f;
                _showInPanel.relativePosition = new Vector3(360f, 40f);
                _showInPanel.eventCheckChanged += (component, value) =>
                {
                    if (Toggle != null)
                    {
                        Toggle.ShowInPanel = value;
                        ToggleManager.Instance.Save();
                    }
                };

                _keymappingLabel = UIUtils.CreateLabel(_panel, "KeymappingLabel", "Keymapping");
                _keymappingLabel.tooltip = "Set the keymapping for toggle";
                _keymappingLabel.relativePosition = new Vector3(60f, 70f);

                _keymapping = UIUtils.CreateDropDown(_panel, "Keymapping", atlas);
                _keymapping.width = 200f;
                _keymapping.items = ModInvariables.KeymappingNames;
                _keymapping.relativePosition = new Vector3(60f, 90f);
                _keymapping.eventSelectedIndexChanged += (component, value) =>
                {
                    if (Toggle != null && value != -1)
                    {
                        Toggle.KeymappingId = value;
                        ToggleManager.Instance.Save();
                    }
                };

                _glyphLabel = UIUtils.CreateLabel(_panel, "GlyphLabel", "Glyph");
                _glyphLabel.tooltip = "Set the glyph for toggle when shown in panel";
                _glyphLabel.relativePosition = new Vector3(360f, 70f);

                _glyph = UIUtils.CreateTextField(_panel, "Glyph", atlas, "");
                _glyph.width = 50f;
                _glyph.maxLength = 1;
                _glyph.relativePosition = new Vector3(360f, 90f);
                _glyph.eventTextSubmitted += (component, value) =>
                {
                    if (Toggle != null)
                    {
                        Toggle.Glyph = value;
                        ToggleManager.Instance.Save();
                    }
                };

                _divider = UIUtils.CreateDivider(_panel, "Divider", atlas);
                _divider.relativePosition = new Vector3(0f, _divider.parent.height - 15f);

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleItem:CreateToggleItem -> Exception: " + e.Message);
            }
        }
        public void DestroyToggleItem()
        {
            try
            {
                DestroyGameObject(_divider);
                DestroyGameObject(_glyph);
                DestroyGameObject(_glyphLabel);
                DestroyGameObject(_keymapping);
                DestroyGameObject(_keymappingLabel);
                DestroyGameObject(_showInPanel);
                DestroyGameObject(_enabled);
                DestroyGameObject(_default);
                DestroyGameObject(_title);
                DestroyGameObject(_down);
                DestroyGameObject(_up);
                DestroyGameObject(_panel);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleItem:DestroyToggleItem -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                UnityEngine.Object.Destroy(component.gameObject);
            }
        }

        public void UpdateToggleItem()
        {
            try
            {
                _title.text = ModInvariables.ToggleNames[Toggle.Id];
                _default.text = "Default: " + (ToggleManager.Instance.GetDefault(Toggle.Id) ? "On" : "Off");
                _enabled.isChecked = Toggle.Enabled;
                _showInPanel.isChecked = Toggle.ShowInPanel;
                _keymapping.selectedIndex = Toggle.KeymappingId;
                _glyph.text = Toggle.Glyph;
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleItem:UpdateToggleItem -> Exception: " + e.Message);
            }
        }
    }
}
