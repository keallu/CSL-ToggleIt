using ICities;
using System;
using UnityEngine;

namespace ToggleIt
{
    public class Loading : LoadingExtensionBase
    {
        private GameObject _modManagerGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _modManagerGameObject = new GameObject("ToggleItModManager");
                _modManagerGameObject.AddComponent<ModManager>();
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