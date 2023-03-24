using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToggleIt.Managers
{
    public class DefaultManager
    {
        private readonly Dictionary<string, object> _defaults = new Dictionary<string, object>();

        private static DefaultManager instance;

        public static DefaultManager Instance
        {
            get
            {
                return instance ?? (instance = new DefaultManager());
            }
        }

        public void Initialize()
        {
            try
            {
                _defaults.Clear();

                _defaults.Add("AutomaticInfoViews", true);
                _defaults.Add("NotificationIcons", true);
                _defaults.Add("RoadNames", true);
                _defaults.Add("Buildings", true);
                _defaults.Add("BorderLines", true);
                _defaults.Add("ContourLines", false);
                _defaults.Add("Zoning", false);
                _defaults.Add("ZoningGrids", true);
                _defaults.Add("ZoningColors", true);
                _defaults.Add("DistrictZones", false);
                _defaults.Add("DistrictNames", true);
                _defaults.Add("DistrictIcons", true);
                _defaults.Add("ToolColors", true);
                _defaults.Add("ToolInfo", true);
                _defaults.Add("ToolExtraInfo", true);
                _defaults.Add("DarkInfoViews", false);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] DefaultManager:Initialize -> Exception: " + e.Message);
            }
        }

        public object Get(string name)
        {
            object obj = null;

            try
            {
                if (_defaults == null || _defaults.Count < 1)
                {
                    Initialize();
                }

                _defaults.TryGetValue(name, out object value);

                if (value != null)
                {
                    obj = value;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] DefaultManager:Get -> Exception: " + e.Message);
            }

            return obj;
        }
    }
}
