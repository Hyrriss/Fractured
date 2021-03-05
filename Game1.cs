using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fractured
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly UI.Menu _menu;
        private readonly UI.Interface _interface;
        private readonly UI.Main _main;
        private Keys[] heldKeys;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _menu = new UI.Menu(this, Content);
            _interface = new UI.Interface(Content);

            TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
            IsMouseVisible = false;
        }

        //First thing called when the game is instantiated
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            Window.IsBorderless = true;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        //Called once after the game is initialized
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _menu.SetMenuActive(MenuType.MainMenu);

            // TODO: use this.Content to load your game content here
        }

        //Called every frame
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Pause))
                Exit();
                        
            if (_menu.IsMenuActive)
            {
                if (IsKeyPressed(Config.Controls.MoveDown)) { _menu.ChangeButton(1); }
                else if (IsKeyPressed(Config.Controls.MoveUp)) { _menu.ChangeButton(-1); }
                else if (IsKeyPressed(Config.Controls.MoveRight)) { _menu.ChangeValue(1); }
                else if (IsKeyPressed(Config.Controls.MoveLeft)) { _menu.ChangeValue(-1); }

                if (IsKeyPressed(Config.Controls.Submit)) { _menu.Submit(); }
                if (IsKeyPressed(Config.Controls.Exit))
                    switch (_menu.CurrentType)
                    {
                        case MenuType.Pause:
                            _menu.Unload();
                            break;
                        case MenuType.Settings:
                            _menu.ReturnToPreviousMenu();
                            break;
                        default:
                            break;
                    }
            }

            /*This method must be the last one before base.Update*/ UpdateHeldKeys();
            base.Update(gameTime);
        }

        //Called at the end of every frame - handles all graphical updates
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _interface.Draw(_spriteBatch);
            _menu.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Returns true if the key was pressed this frame
        /// </summary>
        /// <param name="keys">The key to check if it has just been pressed</param>
        /// <returns></returns>
        private bool IsKeyPressed(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (heldKeys == null) { return true; }
                foreach (Keys k in heldKeys)
                    /*Returns false if key has been held down for more than 1 frame*/ if (k == keys) { return false; }
                return true;
            }
            //Returns false if the key isn't held down
            return false;
        }

        private void UpdateHeldKeys()
        {
            heldKeys = Keyboard.GetState().GetPressedKeys();
        }

        public void ActivateMenu(MenuType menuType) { _menu.SetMenuActive(menuType); }
        public void ActivateInterface(World.StoryMarker storyMarker) { _interface.SetActive(storyMarker); }
    }
}
