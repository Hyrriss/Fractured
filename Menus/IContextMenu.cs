using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fractured.Menus
{
    public abstract class IContextMenu
    {
        public MenuType activeMenuType;
        public MenuType currentMenu;
        public MenuType previousMenu;
        public Texture2D activeSpriteSheet;

        public List<ClickableButton> clickableButtons;

        public int selectedButtonID = -1;

        public IContextMenu() 
        {
        }

        public struct Cursor
        {
            public Vector2 defaultPosition;
            public int offset;
            public Sprite cursorSpite;
            public bool isDisplayed;
        }

        public virtual void ChangeFocus()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {

        }

        public virtual void MouseHover (int x, int y) 
        { 
        
        }

        public virtual void LeftMouseClick (int x, int y) 
        { 
        
        }

        public virtual void KeyboardInput (Keys key)
        {

        }

        public void PopulateClickableButtonsList()
        {
            clickableButtons = new List<ClickableButton>();
            FieldInfo[] fields = base.GetType().GetFields();

            foreach (FieldInfo f in fields)
            {
                if (f.DeclaringType == typeof(IContextMenu)) continue;
                if (f.FieldType.IsSubclassOf(typeof(ClickableButton)) || f.FieldType == typeof(ClickableButton))
                    if (f.GetValue(this) != null)
                        clickableButtons.Add((ClickableButton)f.GetValue(this));
            }
        }

        public ClickableButton FindButtonByID (int id)
        {
            if (clickableButtons != null)
                for (int i = 0; i < clickableButtons.Count; i++)
                    if (clickableButtons[i] != null && clickableButtons[i].ID == id && clickableButtons[i].isVisible)
                        return clickableButtons[i];
            return null;
        }

        public void Exit()
        {
            OnExit();
            if (currentMenu != activeMenuType)
                SwitchMenu(currentMenu);
            else Game1.currentActiveMenu = null;
        }

        public void SwitchMenu(MenuType type)
        {
            switch (type)
            {
                case MenuType.TitleMenu:
                    Game1.currentActiveMenu = new TitleMenu();
                    return;
                default:
                    break;
            }
        }
    }
}
