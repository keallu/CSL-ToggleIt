using ICities;
using System;
using UnityEngine;

namespace ToggleIt
{
    public class Loading : LoadingExtensionBase
    {
        private GameObject _toggleManagerGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _toggleManagerGameObject = new GameObject("ToggleItToggleManager");
                _toggleManagerGameObject.AddComponent<ToggleManager>();
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
                if (_toggleManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_toggleManagerGameObject);
                }

            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}