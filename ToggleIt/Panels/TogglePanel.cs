using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using ToggleIt.Managers;

namespace ToggleIt.Panels
{
    public class TogglePanel : UIPanel
    {
        private bool _initialized;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UIPanel _togglePanel;
        private UIScrollablePanel _toggleScrollablePanel;
        private UIScrollbar _toggleScrollbar;
        private UISlicedSprite _toggleScrollbarTrack;
        private UISlicedSprite _toggleScrollbarThumb;

        private List<ToggleItem> _toggleItems;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:Awake -> Exception: " + e.Message);
            }
        }

        public override void Start()
        {
            base.Start();

            try
            {
                _ingameAtlas = ResourceLoader.GetAtlas("Ingame");

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:Start -> Exception: " + e.Message);
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
                Debug.Log("[Toggle It!] TogglePanel:Update -> Exception: " + e.Message);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            try
            {
                foreach (ToggleItem toggleItem in _toggleItems)
                {
                    toggleItem.DestroyToggleItem();
                }
                DestroyGameObject(_toggleScrollbarThumb);
                DestroyGameObject(_toggleScrollbarTrack);
                DestroyGameObject(_toggleScrollbar);
                DestroyGameObject(_toggleScrollablePanel);
                DestroyGameObject(_togglePanel);
                DestroyGameObject(_title);
                DestroyGameObject(_close);
                DestroyGameObject(_dragHandle);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                Destroy(component.gameObject);
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
                backgroundSprite = "MenuPanel2";
                isVisible = false;
                canFocus = true;
                isInteractive = true;
                width = 750f;
                height = 650f;
                relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2f), Mathf.Floor((GetUIView().fixedHeight - height) / 2f));

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Toggle It!");
                _close = UIUtils.CreateMenuPanelCloseButton(this, _ingameAtlas);
                _dragHandle = UIUtils.CreateMenuPanelDragHandle(this);

                _togglePanel = UIUtils.CreatePanel(this, "ToggleList");
                _togglePanel.width = width - 40f;
                _togglePanel.height = height - 80f;
                _togglePanel.relativePosition = new Vector3(20f, 60f);

                _toggleScrollablePanel = UIUtils.CreateScrollablePanel(_togglePanel, "ToggleScrollablePanel");
                _toggleScrollablePanel.autoLayout = true;
                _toggleScrollablePanel.autoLayoutDirection = LayoutDirection.Vertical;
                _toggleScrollablePanel.scrollWheelDirection = UIOrientation.Vertical;
                _toggleScrollablePanel.builtinKeyNavigation = true;
                _toggleScrollablePanel.clipChildren = true;
                _toggleScrollablePanel.width = _toggleScrollablePanel.parent.width - 25f;
                _toggleScrollablePanel.height = _toggleScrollablePanel.parent.height;
                _toggleScrollablePanel.relativePosition = new Vector3(0f, 0f);

                _toggleScrollbar = UIUtils.CreateScrollbar(_togglePanel, "ToggleScrollbar");
                _toggleScrollbar.orientation = UIOrientation.Vertical;
                _toggleScrollbar.incrementAmount = 25f;
                _toggleScrollbar.width = 20f;
                _toggleScrollbar.height = _toggleScrollbar.parent.height;
                _toggleScrollbar.relativePosition = new Vector3(_toggleScrollbar.parent.width - 20f, 0f);

                _toggleScrollbarTrack = UIUtils.CreateSlicedSprite(_toggleScrollbar, "ToggleScrollbarTrack");
                _toggleScrollbarTrack.spriteName = "ScrollbarTrack";
                _toggleScrollbarTrack.fillDirection = UIFillDirection.Vertical;
                _toggleScrollbarTrack.width = _toggleScrollbarTrack.parent.width;
                _toggleScrollbarTrack.height = _toggleScrollbarTrack.parent.height;
                _toggleScrollbarTrack.relativePosition = new Vector3(0f, 0f);

                _toggleScrollbarThumb = UIUtils.CreateSlicedSprite(_toggleScrollbar, "ToggleScrollbarThumb");
                _toggleScrollbarThumb.spriteName = "ScrollbarThumb";
                _toggleScrollbarThumb.fillDirection = UIFillDirection.Vertical;
                _toggleScrollbarThumb.width = _toggleScrollbarThumb.parent.width - 5f;
                _toggleScrollbarThumb.relativePosition = new Vector3(0f, 0f);

                _toggleScrollablePanel.verticalScrollbar = _toggleScrollbar;
                _toggleScrollbar.trackObject = _toggleScrollbarTrack;
                _toggleScrollbar.thumbObject = _toggleScrollbarThumb;

                CreateToggles();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {
                UpdateToggles();
                RefreshToggles();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        private void CreateToggles()
        {
            try
            {
                if (_toggleItems == null)
                {
                    _toggleItems = new List<ToggleItem>();
                }

                for (int i = 0; i < ToggleManager.Instance.AllToggles.Count; i++)
                {
                    _toggleItems.Add(CreateToggle("Toggle" + i));
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:CreateToggles -> Exception: " + e.Message);
            }
        }

        private void UpdateToggles()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:UpdateToggles -> Exception: " + e.Message);
            }
        }

        private ToggleItem CreateToggle(string name)
        {
            ToggleItem toggleItem = new ToggleItem();

            try
            {
                toggleItem.CreateToggleItem(_toggleScrollablePanel, name, _toggleItems.Count, _ingameAtlas);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] TogglePanel:CreateToggle -> Exception: " + e.Message);
            }

            return toggleItem;
        }

        private void RefreshToggles()
        {
            try
            {
                for (int i = 0; i < _toggleItems.Count; i++)
                {
                    _toggleItems[i].Toggle = ToggleManager.Instance.AllToggles[i];
                    _toggleItems[i].UpdateToggleItem();
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Watch It!] TogglePanel:RefreshToggles -> Exception: " + e.Message);
            }
        }
    }
}
