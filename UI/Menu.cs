using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using Fractured.UI.Menus;

namespace Fractured.UI
{
    public class Menu
    {

        #region variables
        private readonly ContentManager Content;
        private readonly Game1 Game1;

        /// <summary>
        /// Returns true if a menu is active
        /// </summary>
        public bool IsMenuActive { get { return isMenuActive; } }
        private bool isMenuActive;

        private MenuType currentMenu = MenuType.MainMenu;
        private MenuType previousMenu;
        private Texture2D activeSpriteSheet;
        private List<Sprite> sprites = new List<Sprite>();
        private List<Sprite> buttonLabels = new List<Sprite>();
        private List<Button> buttons = new List<Button>();
        private Cursor activeCursor;
        private int selectedButton = 0;
        private SoundEffect selection;
        #endregion

        public Menu(Game1 game1, ContentManager content)
        {
            Game1 = game1;
            Content = new ContentManager(content.ServiceProvider, content.RootDirectory);
        }

        /// <summary>
        /// Sets the specified menu type to be active and loads in the required assets
        /// </summary>
        /// <param name="menuType"></param>
        public void SetMenuActive(MenuType menuType)
        {
            isMenuActive = true;
            previousMenu = currentMenu;
            currentMenu = menuType;
            selection = Content.Load<SoundEffect>("Audio\\Sfx\\0");

            switch (menuType)
            {
                case MenuType.MainMenu:
                    #region Initialize Main Menu
                    selectedButton = -1;
                    activeSpriteSheet = Content.Load<Texture2D>("Sprites\\Menu\\MainMenu");

                    sprites = MainMenu.InstantiateStaticTextures(Content, activeSpriteSheet);
                    buttons = MainMenu.InstantiateButtons(activeSpriteSheet);
                    #endregion
                    break;

                case MenuType.Settings:
                    #region Initialize Settings Menu
                    selectedButton = 0;
                    activeSpriteSheet = Content.Load<Texture2D>("Sprites\\Menu\\Options");

                    activeCursor = new Cursor(new Sprite { BaseSpriteSheet = activeSpriteSheet, SpriteLocation = new Rectangle(1, 1728, 1552, 90), ScreenPosition = new Vector2(80, 114)}, 160);
                    sprites = Settings.InstantiateStaticTextures(activeSpriteSheet);
                    buttonLabels = Settings.InstantiateButtonLabels(activeSpriteSheet);
                    buttons = Settings.InstantiateButtons(activeSpriteSheet);
                    #endregion
                    break;

                case MenuType.Pause:
                    break;

                default: return;
            }
        }

        /// <summary>
        /// Deactivates menu layer
        /// </summary>
        public void Unload()
        {
            Content.Unload();

            sprites.Clear();
            buttons.Clear();
            buttonLabels.Clear();
            activeCursor = null;
        }

        /// <summary>
        /// Draws the objects for the active menu
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (isMenuActive)
            {
                foreach (Sprite s in sprites) { _spriteBatch.Draw(s.BaseSpriteSheet, s.ScreenPosition, s.SpriteLocation, Color.White); }
                if (activeCursor != null && !buttons[selectedButton].DoesButtonIgnoreCursor) { _spriteBatch.Draw(activeCursor.cursorSprite.BaseSpriteSheet, activeCursor.cursorSprite.ScreenPosition, activeCursor.cursorSprite.SpriteLocation, Color.White); }
                if (buttonLabels != null) { foreach (Sprite s in buttonLabels) { _spriteBatch.Draw(s.BaseSpriteSheet, s.ScreenPosition, s.SpriteLocation, Color.White); } }
                if (buttons != null) { foreach (Button b in buttons) { b.Draw(_spriteBatch, selectedButton == b.ID); } }
            }
        }

        /// <summary>
        /// Changes the current selected button
        /// </summary>
        /// <param name="value"></param>
        public void ChangeButton(int value)
        {
            if (buttons != null)
            {
                selection.Play(0.5f, 0, 0);
                if (selectedButton == -1) { selectedButton = 0; return; }
                selectedButton = ((selectedButton + buttons.Count) + value) % buttons.Count;
                if (activeCursor != null) { activeCursor.MoveCursor(selectedButton); }
            }
        }

        /// <summary>
        /// Changes the current value of the selected button
        /// </summary>
        /// <param name="value"></param>
        public void ChangeValue(int value)
        {
            if (buttons != null && selectedButton >= 0)
                buttons[selectedButton].ChangeValue(value, selection);
        }

        /// <summary>
        /// Submits the method for the selected button
        /// </summary>
        public void Submit()
        {
            switch (currentMenu)
            {
                case MenuType.MainMenu:
                    switch (selectedButton)
                    {
                        case 0:
                            MainMenu.NewGame();
                            break;
                        case 1:
                            LoadGame();
                            break;
                        case 2:
                            Unload();
                            SetMenuActive(MenuType.Settings);
                            break;
                    }
                    break;
                case MenuType.Settings:
                    switch (selectedButton)
                    {
                        case 6:
                            if (buttons[selectedButton].Value == 1) { Settings.SubmitSettings(); }
                            Unload();
                            SetMenuActive(previousMenu);
                            break;
                        default: break;
                    }
                    break;
            }
        }

        private void LoadGame()
        {
            Debug.Print("Load Game");
        } 
    }

    public class Button
    {
        public int ID;
        /// <summary>
        /// Returns the current selected value of the button
        /// </summary>
        public int Value
        {
            get { return currentValue; }
        }

        private readonly Sprite unselected;
        private readonly Sprite selected;
        private readonly Sprite value;
        private readonly Sprite[] valueList;
        private readonly int maxValue;
        private int currentValue;
        private readonly bool canLoop;
        private readonly int valueOffset;
        private readonly ButtonType type;
        private enum ButtonType
        {
            SingleValue,
            NumberValue,
            ObjectValue,
            SelectableValue
        }

        public bool DoesButtonIgnoreCursor { get { return type == ButtonType.SelectableValue; } }

        /// <summary>
        /// Creates new selectable button with no changeable values
        /// </summary>
        /// <param name="_content"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Button(int id, Sprite unselectedSprite, Sprite selectedSprite)
        {
            ID = id;
            unselected = unselectedSprite;
            selected = selectedSprite;
            maxValue = 0;
            currentValue = 0;
            canLoop = false;
            type = ButtonType.SingleValue;
        }

        /// <summary>
        /// Creates a button with a numeric value
        /// </summary>
        /// <param name="id">ID number of the button</param>
        /// <param name="blankValue">Sprite to use when value = 0</param>
        /// <param name="filledValue">Sprite to use to fill in values</param>
        /// <param name="maximumValue">Highest value the button can get to</param>
        /// <param name="defaultValue">The value the button should generate with</param>
        /// <param name="spriteOffset">The spacing between one value sprite and the next</param>
        public Button(int id, Sprite blankValue, Sprite filledValue, int maximumValue, int defaultValue, int spriteOffset)
        {
            ID = id;
            selected = blankValue;
            value = filledValue;
            maxValue = maximumValue;
            currentValue = defaultValue;
            valueOffset = spriteOffset;
            canLoop = false;
            type = ButtonType.NumberValue;
        }

        /// <summary>
        /// Creates a button with a switch value
        /// </summary>
        /// <param name="id">ID number of the button</param>
        /// <param name="values">Textures of each switch</param>
        /// <param name="maximumValue">The total number of switches</param>
        /// <param name="defaultValue">The default value to be displayed on load</param>
        /// <param name="loopable">Will the switches loop when they reach the ends</param>
        /// <param name="selectable">Is there a separate texture for when the button is unselected</param>
        public Button(int id, Sprite[] values, int maximumValue, int defaultValue, bool loopable = false, bool selectable = false)
        {
            ID = id;
            valueList = values;
            maxValue = maximumValue;
            currentValue = defaultValue;
            canLoop = loopable;
            type = selectable ? ButtonType.SelectableValue : ButtonType.ObjectValue;
        }

        public void Draw(SpriteBatch _spriteBatch, bool isSelected)
        {
            switch (type)
            {
                case ButtonType.SingleValue:
                    if (isSelected) { _spriteBatch.Draw(selected.BaseSpriteSheet, selected.ScreenPosition, selected.SpriteLocation, Color.White); }
                    else { _spriteBatch.Draw(unselected.BaseSpriteSheet, unselected.ScreenPosition, unselected.SpriteLocation, Color.White); }
                    break;
                case ButtonType.NumberValue:
                    _spriteBatch.Draw(selected.BaseSpriteSheet, selected.ScreenPosition, selected.SpriteLocation, Color.White);
                    if (currentValue > 0) { for (int v = 0; v < currentValue; v++) { _spriteBatch.Draw(value.BaseSpriteSheet, new Vector2(value.ScreenPosition.X + (v * valueOffset), value.ScreenPosition.Y), value.SpriteLocation, Color.White); } }
                    break;
                case ButtonType.ObjectValue:
                    _spriteBatch.Draw(valueList[currentValue].BaseSpriteSheet, valueList[currentValue].ScreenPosition, valueList[currentValue].SpriteLocation, Color.White);
                    break;
                case ButtonType.SelectableValue:
                    if (isSelected) { _spriteBatch.Draw(valueList[currentValue].BaseSpriteSheet, valueList[currentValue].ScreenPosition, valueList[currentValue].SpriteLocation, Color.White); }
                    else { _spriteBatch.Draw(valueList[0].BaseSpriteSheet, valueList[0].ScreenPosition, valueList[0].SpriteLocation, Color.White); }
                    break;
            }
        }

        public void ChangeValue(int amount, SoundEffect effect)
        {
            if (maxValue == 0) { return; }

            if (canLoop) currentValue = (currentValue + maxValue + amount) % maxValue;
            else { currentValue += amount; currentValue = Math.Max(0, currentValue); currentValue = Math.Min(maxValue - 1, currentValue); }
            if (type == ButtonType.SelectableValue && currentValue == 0) { currentValue = Math.Abs(Math.Min(amount, amount * (maxValue - 1))); }
            effect.Play(0.5f, 0, 0);
        }
    }

    public class Cursor
    {
        private Vector2 defaultPosition;
        private readonly int offset;
        public Sprite cursorSprite;

        public Cursor(Sprite sprite, int movementOffset)
        {
            cursorSprite = sprite;
            defaultPosition = sprite.ScreenPosition;
            offset = movementOffset;
        }

        public void MoveCursor (int selectedValue)
        {
            cursorSprite.ScreenPosition.Y = defaultPosition.Y + (offset * selectedValue);
        }
    }
}
