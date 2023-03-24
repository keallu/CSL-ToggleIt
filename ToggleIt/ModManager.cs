using System;
using System.Collections.Generic;
using ToggleIt.Managers;
using ToggleIt.Panels;
using UnityEngine;

namespace ToggleIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;

        private ControlPanel _controlPanel;
        private TogglePanel _togglePanel;

        public void Awake()
        {
            try
            {

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
                DefaultManager.Instance.Initialize();

                if (_controlPanel == null)
                {
                    _controlPanel = GameObject.Find("ToggleItControlPanel")?.GetComponent<ControlPanel>();
                }

                if (_togglePanel == null)
                {
                    _togglePanel = GameObject.Find("ToggleItTogglePanel")?.GetComponent<TogglePanel>();
                }

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
                    _controlPanel.ForceUpdateUI();
                    _togglePanel.ForceUpdateUI();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }

                if (KeyChecker.GetKeyCombo(out int key))
                {
                    List<Toggle> toggles = ToggleManager.Instance.GetByKeymappingId(key);

                    foreach (Toggle toggle in toggles)
                    {
                        ToggleManager.Instance.Apply(toggle.Id, !toggle.On);
                    }

                    ToggleManager.Instance.Save();
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

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ModManager:UpdateUI -> Exception: " + e.Message);
            }
        }
    }
}
