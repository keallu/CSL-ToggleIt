using System;
using System.Collections.Generic;
using System.Linq;
using ToggleIt.Helpers;
using UnityEngine;

namespace ToggleIt.Managers
{
    public class ToggleManager
    {
        public List<Toggle> AllToggles
        {
            get
            {
                if (ModConfig.Instance.Toggles.Count < ModInvariables.Toggles.Length)
                {
                    AddMissingToggles();
                }

                return ModConfig.Instance.Toggles;
            }
        }

        private static ToggleManager instance;

        public static ToggleManager Instance
        {
            get
            {
                return instance ?? (instance = new ToggleManager());
            }
        }

        public bool GetDefault(int id)
        {
            bool on = false;

            try
            {
                switch (id)
                {
                    case 0:
                        on = (bool)DefaultManager.Instance.Get("AutomaticInfoViews");
                        break;
                    case 1:
                        on = (bool)DefaultManager.Instance.Get("NotificationIcons");
                        break;
                    case 2:
                        on = (bool)DefaultManager.Instance.Get("RoadNames");
                        break;
                    case 3:
                        on = (bool)DefaultManager.Instance.Get("Buildings");
                        break;
                    case 4:
                        on = (bool)DefaultManager.Instance.Get("BorderLines");
                        break;
                    case 5:
                        on = (bool)DefaultManager.Instance.Get("ContourLines");
                        break;
                    case 6:
                        on = (bool)DefaultManager.Instance.Get("Zoning");
                        break;
                    case 7:
                        on = (bool)DefaultManager.Instance.Get("ZoningGrids");
                        break;
                    case 8:
                        on = (bool)DefaultManager.Instance.Get("ZoningColors");
                        break;
                    case 9:
                        on = (bool)DefaultManager.Instance.Get("DistrictZones");
                        break;
                    case 10:
                        on = (bool)DefaultManager.Instance.Get("DistrictNames");
                        break;
                    case 11:
                        on = (bool)DefaultManager.Instance.Get("DistrictIcons");
                        break;
                    case 12:
                        on = (bool)DefaultManager.Instance.Get("ToolColors");
                        break;
                    case 13:
                        on = (bool)DefaultManager.Instance.Get("ToolInfo");
                        break;
                    case 14:
                        on = (bool)DefaultManager.Instance.Get("ToolExtraInfo");
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:GetDefault -> Exception: " + e.Message);
            }

            return on;
        }

        public Toggle GetById(int id)
        {
            return AllToggles.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Toggle> GetByKeymappingId(int keymappingId)
        {
            return AllToggles.Where(x => x.KeymappingId == keymappingId).ToList();
        }

        public void Move(int id, int delta)
        {
            try
            {
                int oldIndex = ModConfig.Instance.Toggles.FindIndex(x => x.Id == id);

                if (oldIndex != -1)
                {
                    Toggle toggle = ModConfig.Instance.Toggles[oldIndex];

                    ModConfig.Instance.Toggles.RemoveAt(oldIndex);
                    ModConfig.Instance.Toggles.Insert(oldIndex + delta, toggle);

                    ModConfig.Instance.Save();
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Move -> Exception: " + e.Message);
            }
        }


        public void Apply(int id)
        {
            try
            {
                Toggle toggle = AllToggles.Where(x => x.Id == id).FirstOrDefault();

                Apply(toggle);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Apply -> Exception: " + e.Message);
            }
        }

        public void Apply(int id, bool on)
        {
            try
            {
                Toggle toggle = AllToggles.Where(x => x.Id == id).FirstOrDefault();

                toggle.On = on;

                Apply(toggle);
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Apply -> Exception: " + e.Message);
            }
        }

        public void Apply(Toggle toggle)
        {
            try
            {
                if (toggle != null & toggle.Enabled)
                {
                    switch (toggle.Id)
                    {
                        case 0:
                            break;
                        case 1:
                            ToggleHelper.UpdateNotificationIcons(toggle.On);
                            break;
                        case 2:
                            ToggleHelper.UpdateRoadNames(toggle.On);
                            break;
                        case 3:
                            ToggleHelper.UpdateBuildings(toggle.On);
                            break;
                        case 4:
                            ToggleHelper.UpdateBorderLines(toggle.On);
                            break;
                        case 5:
                            ToggleHelper.UpdateContourLines(toggle.On);
                            break;
                        case 6:
                            ToggleHelper.UpdateZoning(toggle.On);
                            break;
                        case 7:
                            ToggleHelper.UpdateZoningGrids(toggle.On, (Color)DefaultManager.Instance.Get("ZoneEdgeColor"), (Color)DefaultManager.Instance.Get("ZoneEdgeColorInfo"), (Color)DefaultManager.Instance.Get("ZoneEdgeColorOccupiedColor"), (Color)DefaultManager.Instance.Get("ZoneEdgeColorOccupiedInfo"));
                            break;
                        case 8:
                            ToggleHelper.UpdateZoningColors(toggle.On, (Color)DefaultManager.Instance.Get("ZoneFillColor"), (Color)DefaultManager.Instance.Get("ZoneFillColorInfo"));
                            break;
                        case 9:
                            ToggleHelper.UpdateDistrictZones(toggle.On);
                            break;
                        case 10:
                            ToggleHelper.UpdateDistrictNames(toggle.On);
                            break;
                        case 11:
                            ToggleHelper.UpdateDistrictIcons(toggle.On);
                            break;
                        case 12:
                            ToggleHelper.UpdateDefaultToolColors(toggle.On);
                            break;
                        case 13:
                            break;
                        case 14:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Apply -> Exception: " + e.Message);
            }
        }

        public void ApplyAll()
        {
            try
            {
                foreach (Toggle toggle in ModConfig.Instance.Toggles)
                {
                    Apply(toggle.Id, toggle.On);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ApplyAll -> Exception: " + e.Message);
            }
        }

        public void ResetAll()
        {
            try
            {
                foreach (Toggle toggle in ModConfig.Instance.Toggles)
                {
                    toggle.On = GetDefault(toggle.Id);
                    Apply(toggle.Id, toggle.On);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:ResetAll -> Exception: " + e.Message);
            }
        }

        public void Save()
        {
            try
            {
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:Save -> Exception: " + e.Message);
            }
        }

        private void AddMissingToggles()
        {
            try
            {
                int[] current = ModConfig.Instance.Toggles.Select(x => x.Id).ToArray();

                IEnumerable<int> missing = current != null ? ModInvariables.Toggles.Except(current) : ModInvariables.Toggles;

                foreach (int id in missing)
                {
                    Toggle toggle = new Toggle
                    {
                        Id = id,
                        KeymappingId = 0,
                        Glyph = ((char)(65 + id)).ToString(),
                        On = GetDefault(id)
                    };

                    if (current.Length < 1 && id < 6)
                    {
                        toggle.Enabled = true;
                    }

                    ModConfig.Instance.Toggles.Add(toggle);
                }

                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Toggle It!] ToggleManager:AddMissingToggles -> Exception: " + e.Message);
            }
        }
    }
}