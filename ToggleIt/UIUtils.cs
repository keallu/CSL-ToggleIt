using ColossalFramework.UI;
using UnityEngine;

namespace ToggleIt
{
    public class UIUtils
    {
        public static UIFont GetUIFont(string name)
        {
            UIFont[] fonts = Resources.FindObjectsOfTypeAll<UIFont>();

            foreach (UIFont font in fonts)
            {
                if (font.name.CompareTo(name) == 0)
                {
                    return font;
                }
            }

            return null;
        }

        public static UIPanel CreatePanel(UIComponent parent, string name)
        {
            UIPanel panel = parent.AddUIComponent<UIPanel>();
            panel.name = name;

            return panel;
        }
        public static UIScrollablePanel CreateScrollablePanel(UIComponent parent, string name)
        {
            UIScrollablePanel scrollablePanel = parent.AddUIComponent<UIScrollablePanel>();
            scrollablePanel.name = name;

            return scrollablePanel;
        }

        public static UIScrollbar CreateScrollbar(UIComponent parent, string name)
        {
            UIScrollbar scrollbar = parent.AddUIComponent<UIScrollbar>();
            scrollbar.name = name;

            return scrollbar;
        }
        public static UISlicedSprite CreateSlicedSprite(UIComponent parent, string name)
        {
            UISlicedSprite slicedSprite = parent.AddUIComponent<UISlicedSprite>();
            slicedSprite.name = name;

            return slicedSprite;
        }

        public static UIDragHandle CreateDragHandle(UIComponent parent, string name)
        {
            UIDragHandle dragHandle = parent.AddUIComponent<UIDragHandle>();
            dragHandle.name = name;
            dragHandle.target = parent;

            return dragHandle;
        }

        public static UICheckBox CreateButtonCheckBox(UIComponent parent, string name, UITextureAtlas atlas, string text, bool state)
        {
            UICheckBox checkBox = parent.AddUIComponent<UICheckBox>();
            checkBox.name = name;
            checkBox.size = new Vector3(36f, 36f);

            UIButton button = checkBox.AddUIComponent<UIButton>();
            button.atlas = atlas;
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
            }

            checkBox.eventCheckChanged += (component, value) =>
            {
                if (value)
                {
                    button.normalBgSprite = "OptionBaseFocused";
                }
                else
                {
                    button.normalBgSprite = "OptionBase";
                }
            };

            return checkBox;
        }

        public static UIButton CreateSpriteButton(UIComponent parent, string name, UITextureAtlas atlas, string spriteName)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = name;
            button.atlas = atlas;

            button.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;
            button.normalFgSprite = spriteName;
            button.hoveredFgSprite = spriteName + "Hovered";
            button.pressedFgSprite = spriteName + "Pressed";
            button.disabledFgSprite = spriteName + "Disabled";

            return button;
        }

        public static UIButton CreateButton(UIComponent parent, string name, UITextureAtlas atlas, string spriteName)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = name;
            button.atlas = atlas;

            button.normalBgSprite = "OptionBase";
            button.hoveredBgSprite = "OptionBaseHovered";
            button.pressedBgSprite = "OptionBasePressed";
            button.disabledBgSprite = "OptionBaseDisabled";

            button.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;
            button.normalFgSprite = spriteName;
            button.hoveredFgSprite = spriteName;
            button.pressedFgSprite = spriteName;
            button.disabledFgSprite = spriteName;

            return button;
        }

        public static UILabel CreateTitle(UIComponent parent, string name, string text)
        {
            UILabel label = parent.AddUIComponent<UILabel>();
            label.font = GetUIFont("OpenSans-Bold");
            label.name = name;
            label.text = text;
            label.autoSize = false;
            label.height = 20f;
            label.verticalAlignment = UIVerticalAlignment.Middle;
            label.relativePosition = new Vector3(0f, 0f);

            return label;
        }

        public static UILabel CreateLabel(UIComponent parent, string name, string text)
        {
            UILabel label = parent.AddUIComponent<UILabel>();
            label.name = name;
            label.font = GetUIFont("OpenSans-Regular");
            label.textScale = 0.875f;
            label.text = text;
            label.autoSize = false;
            label.height = 20f;
            label.verticalAlignment = UIVerticalAlignment.Middle;
            label.relativePosition = new Vector3(0f, 0f);

            return label;
        }

        public static UITextField CreateTextField(UIComponent parent, string name, UITextureAtlas atlas, string text)
        {
            UITextField textField = parent.AddUIComponent<UITextField>();
            textField.name = name;
            textField.atlas = atlas;
            textField.font = GetUIFont("OpenSans-Regular");
            textField.textScale = 0.875f;
            textField.height = 32f;
            textField.width = parent.width - 10f;
            textField.relativePosition = new Vector3(0f, 0f);

            textField.normalBgSprite = "OptionsDropboxListbox";
            textField.hoveredBgSprite = "OptionsDropboxListboxHovered";
            textField.focusedBgSprite = "OptionsDropboxListboxFocused";
            textField.disabledBgSprite = "OptionsDropboxListboxDisabled";
            textField.selectionSprite = "EmptySprite";

            textField.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;
            textField.horizontalAlignment = UIHorizontalAlignment.Left;
            textField.verticalAlignment = UIVerticalAlignment.Middle;

            textField.padding = new RectOffset(10, 5, 10, 5);

            textField.builtinKeyNavigation = true;
            textField.text = text;

            return textField;
        }

        public static UIDropDown CreateDropDown(UIComponent parent, string name, UITextureAtlas atlas)
        {
            UIDropDown dropDown = parent.AddUIComponent<UIDropDown>();
            dropDown.name = name;
            dropDown.atlas = atlas;
            dropDown.font = GetUIFont("OpenSans-Regular");
            dropDown.textScale = 0.875f;
            dropDown.height = 32f;
            dropDown.width = parent.width - 10f;
            dropDown.relativePosition = new Vector3(0f, 0f);

            dropDown.listBackground = "OptionsDropboxListbox";
            dropDown.listHeight = 200;

            dropDown.itemHeight = 24;
            dropDown.itemHover = "ListItemHover";
            dropDown.itemHighlight = "ListItemHighlight";

            dropDown.normalBgSprite = "OptionsDropbox";
            dropDown.hoveredBgSprite = "OptionsDropboxHovered";
            dropDown.focusedBgSprite = "OptionsDropboxFocused";
            dropDown.disabledBgSprite = "OptionsDropboxDisabled";

            dropDown.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;
            dropDown.horizontalAlignment = UIHorizontalAlignment.Center;
            dropDown.verticalAlignment = UIVerticalAlignment.Middle;

            dropDown.itemPadding = new RectOffset(5, 5, 5, 5);
            dropDown.listPadding = new RectOffset(5, 5, 5, 5);
            dropDown.textFieldPadding = new RectOffset(10, 5, 10, 5);

            dropDown.popupColor = new Color32(255, 255, 255, 255);
            dropDown.popupTextColor = new Color32(170, 170, 170, 255);

            UIButton button = dropDown.AddUIComponent<UIButton>();
            button.height = dropDown.height;
            button.width = dropDown.width;
            button.relativePosition = new Vector3(0f, 0f);

            dropDown.triggerButton = button;

            dropDown.eventSizeChanged += (component, value) =>
            {
                dropDown.listWidth = (int)value.x;
                button.size = value;
            };

            return dropDown;
        }

        public static UICheckBox CreateCheckBox(UIComponent parent, string name, UITextureAtlas atlas, string text, bool state)
        {
            UICheckBox checkBox = parent.AddUIComponent<UICheckBox>();
            checkBox.name = name;
            checkBox.height = 16f;
            checkBox.width = parent.width - 10f;

            UISprite uncheckedSprite = checkBox.AddUIComponent<UISprite>();
            uncheckedSprite.atlas = atlas;
            uncheckedSprite.spriteName = "check-unchecked";
            uncheckedSprite.size = new Vector2(16f, 16f);
            uncheckedSprite.relativePosition = Vector3.zero;

            UISprite checkedSprite = checkBox.AddUIComponent<UISprite>();
            checkedSprite.atlas = atlas;
            checkedSprite.spriteName = "check-checked";
            checkedSprite.size = new Vector2(16f, 16f);
            checkedSprite.relativePosition = Vector3.zero;

            checkBox.label = checkBox.AddUIComponent<UILabel>();
            checkBox.label.font = GetUIFont("OpenSans-Regular");
            checkBox.label.textScale = 0.875f;
            checkBox.label.verticalAlignment = UIVerticalAlignment.Middle;
            checkBox.label.height = 30f;
            checkBox.label.relativePosition = new Vector3(25f, 2f);
            checkBox.label.text = text;

            checkBox.checkedBoxObject = checkedSprite;
            checkBox.isChecked = state;

            return checkBox;
        }

        public static UISprite CreateDivider(UIComponent parent, string name, UITextureAtlas atlas)
        {
            UISprite sprite = parent.AddUIComponent<UISprite>();
            sprite.name = name;
            sprite.atlas = atlas;
            sprite.spriteName = "ContentManagerItemBackground";
            sprite.height = 15f;
            sprite.width = parent.width;
            sprite.relativePosition = new Vector3(0f, 0f);

            return sprite;
        }

        public static UILabel CreateMenuPanelTitle(UIComponent parent, UITextureAtlas atlas, string title)
        {
            UILabel label = parent.AddUIComponent<UILabel>();
            label.name = "Title";
            label.atlas = atlas;
            label.text = title;
            label.textAlignment = UIHorizontalAlignment.Center;
            label.relativePosition = new Vector3(parent.width / 2f - label.width / 2f, 11f);

            return label;
        }

        public static UIButton CreateMenuPanelCloseButton(UIComponent parent, UITextureAtlas atlas)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = "CloseButton";
            button.atlas = atlas;
            button.relativePosition = new Vector3(parent.width - 37f, 2f);

            button.normalBgSprite = "buttonclose";
            button.hoveredBgSprite = "buttonclosehover";
            button.pressedBgSprite = "buttonclosepressed";

            button.eventClicked += (component, eventParam) =>
            {
                if (!eventParam.used)
                {
                    parent.Hide();

                    eventParam.Use();
                }
            };

            return button;
        }

        public static UIDragHandle CreateMenuPanelDragHandle(UIComponent parent)
        {
            UIDragHandle dragHandle = parent.AddUIComponent<UIDragHandle>();
            dragHandle.name = "DragHandle";
            dragHandle.width = parent.width - 40f;
            dragHandle.height = 40f;
            dragHandle.relativePosition = Vector3.zero;
            dragHandle.target = parent;

            return dragHandle;
        }
    }
}
