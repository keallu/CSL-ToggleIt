using ColossalFramework.UI;
using UnityEngine;

namespace ToggleIt
{
    public class UIUtils
    {
        public static UIPanel CreatePanel(string name)
        {
            UIPanel panel = UIView.GetAView().AddUIComponent(typeof(UIPanel)) as UIPanel;
            panel.name = name;

            return panel;
        }

        public static UIPanel CreatePanel(UIComponent parent, string name)
        {
            UIPanel panel = parent.AddUIComponent<UIPanel>();
            panel.name = name;

            return panel;
        }

        public static UIDragHandle CreateDragHandle(UIComponent parent, string name)
        {
            UIDragHandle dragHandle = parent.AddUIComponent<UIDragHandle>();
            dragHandle.name = name;
            dragHandle.target = parent;

            return dragHandle;
        }

        public static UICheckBox CreateButtonCheckBox(UIComponent parent, string name, string text, bool state)
        {
            UICheckBox checkBox = parent.AddUIComponent<UICheckBox>();
            checkBox.name = name + "CheckBox";
            checkBox.size = new Vector3(36f, 36f);

            UIButton button = checkBox.AddUIComponent<UIButton>();
            button.name = name + "Button";
            button.text = text;
            button.textHorizontalAlignment = UIHorizontalAlignment.Center;
            button.textVerticalAlignment = UIVerticalAlignment.Middle;
            button.relativePosition = new Vector3(0f, 0f);

            button.normalBgSprite = "OptionBase";
            button.hoveredBgSprite = "OptionBaseHovered";
            button.pressedBgSprite = "OptionBasePressed";
            button.disabledBgSprite = "OptionBaseDisabled";

            checkBox.isChecked = state;
            if (state)
            {
                button.normalBgSprite = "OptionBaseFocused";
                //button.normalFgSprite = spriteName + "Focused";
            }

            checkBox.eventCheckChanged += (component, value) =>
            {
                if (value)
                {
                    button.normalBgSprite = "OptionBaseFocused";
                    //button.normalFgSprite = spriteName + "Focused";
                }
                else
                {
                    button.normalBgSprite = "OptionBase";
                    //button.normalFgSprite = spriteName;
                }
            };

            return checkBox;
        }
    }
}
