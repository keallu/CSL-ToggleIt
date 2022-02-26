using ColossalFramework.UI;
using ICities;
using System;
using ToggleIt.Panels;
using UnityEngine;

namespace ToggleIt
{
    public class Loading : LoadingExtensionBase
    {
        private GameObject _modManagerGameObject;

        private GameObject _controlPanelGameObject;
        private GameObject _togglePanelGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _modManagerGameObject = new GameObject("ToggleItModManager");
                _modManagerGameObject.AddComponent<ModManager>();

                UIView uiView = UnityEngine.Object.FindObjectOfType<UIView>();
                if (uiView != null)
                {
                    _controlPanelGameObject = new GameObject("ToggleItControlPanel");
                    _controlPanelGameObject.transform.parent = uiView.transform;
                    _controlPanelGameObject.AddComponent<ControlPanel>();

                    _togglePanelGameObject = new GameObject("ToggleItTogglePanel");
                    _togglePanelGameObject.transform.parent = uiView.transform;
                    _togglePanelGameObject.AddComponent<TogglePanel>();
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] Loading:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (_togglePanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_togglePanelGameObject);
                }
                if (_controlPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_controlPanelGameObject);
                }
                if (_modManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_modManagerGameObject);
                }

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}