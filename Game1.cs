using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Fractured.Menus;

namespace Fractured
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static new ContentManager Content;

        public static IContextMenu currentActiveMenu;
        public static IContextMenu previousActiveMenu;

        public static Color backgroundColor;

        private Keys[] heldKeys;
        private List<Keys> pressedKeys = new List<Keys>();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreparingDeviceSettings += delegate (object sender, PreparingDeviceSettingsEventArgs args)
            {
                args.GraphicsDeviceInformation.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
            };
            Content = base.Content;
            Content.RootDirectory = "Content";

            TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
            IsMouseVisible = false;
        }

        //First thing called when the game is instantiated
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            Window.IsBorderless = true;
            Graphics.ApplyChanges();

            base.Initialize();
        }

        //Called once after the game is initialized
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            currentActiveMenu = new TitleMenu();
        }

        //Called every frame
        protected override void Update(GameTime gameTime)
        {
            //This method must be the first one called in Update
            UpdatePressedKeys();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Pause))
                Exit();

            if (currentActiveMenu != null)
            {
                currentActiveMenu.MouseHover(Mouse.GetState().X, Mouse.GetState().Y);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    currentActiveMenu.LeftMouseClick(Mouse.GetState().X, Mouse.GetState().Y);
                foreach (Keys k in pressedKeys)
                    currentActiveMenu.KeyboardInput(k);
            }

            //This method must be the last one before base.Update
            UpdateHeldKeys();
            base.Update(gameTime);
        }

        /// <summary>
        /// Called at the end of every frame - handles all graphical updates
        /// </summary>
        /// <param name="gameTime">Time since game started</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // TODO: Add your drawing code here
            SpriteBatch.Begin();

            if (currentActiveMenu != null)
                currentActiveMenu.Draw(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Checks if key was pressed this frame
        /// </summary>
        /// <param name="keys">The key to check if it has just been pressed</param>
        /// <returns>True if the key was pressed this frame</returns>
        private bool IsKeyPressed(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (heldKeys == null) { return true; }
                foreach (Keys k in heldKeys)
                    //Returns false if key has been held down for more than 1 frame
                    if (k == keys) { return false; }
                return true;
            }
            //Returns false if the key isn't held down
            return false;
        }

        private void UpdateHeldKeys()
        {
            heldKeys = Keyboard.GetState().GetPressedKeys();
        }

        private void UpdatePressedKeys()
        {
            pressedKeys.Clear();
            foreach (Keys k in Keyboard.GetState().GetPressedKeys())
                if (IsKeyPressed(k)) pressedKeys.Add(k);
        }

        public static void StartNewGame()
        {
            currentActiveMenu.Exit();
            backgroundColor = Color.Black;
            return;
        }
    }
}
