using System;
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
        private Keys[] heldKeys;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _menu = new UI.Menu(this, Content);

            IsMouseVisible = true;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                        
            if (_menu.IsMenuActive)
            {
                if (IsKeyPressed(Config.Controls.MoveDown)) { _menu.ChangeButton(1); }
                else if (IsKeyPressed(Config.Controls.MoveUp)) { _menu.ChangeButton(-1); }
                else if (IsKeyPressed(Config.Controls.MoveRight)) { _menu.ChangeValue(1); }
                else if (IsKeyPressed(Config.Controls.MoveLeft)) { _menu.ChangeValue(-1); }

                if (IsKeyPressed(Config.Controls.Submit)) { _menu.Submit(); }
            }

            /*This method must be the last one before base.Update*/ UpdateHeldKeys();
            base.Update(gameTime);
        }

        //Called at the end of every frame - handles all graphical updates
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _menu.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Returns true if the key was pressed this frame
        /// </summary>
        /// <param name="keys">The key to check if it has just been pressed</param>
        /// <returns></returns>
        public bool IsKeyPressed(Keys keys)
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
    }
}
