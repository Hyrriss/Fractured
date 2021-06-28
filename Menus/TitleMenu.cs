using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fractured.Menus
{
    public class TitleMenu : IContextMenu
    {
        readonly Texture2D spriteSheet;

        public readonly SelectableTextureButton newGameButton;
        public readonly SelectableTextureButton loadGameButton;
        public readonly SelectableTextureButton optionsButton;

        readonly StaticTexture logoTexture;
        readonly StaticTexture newGameLabel;
        readonly StaticTexture loadGameLabel;
        readonly StaticTexture optionsLabel;

        public TitleMenu()
        {
            Game1.backgroundColor = new Color(35, 54, 77);

            currentMenu = activeMenuType = MenuType.TitleMenu;
            spriteSheet = Game1.Content.Load<Texture2D>("Sprites\\Menu\\TitleMenu");
            selectedButtonID = 0;

            logoTexture = new StaticTexture(spriteSheet, new Rectangle(568, 73, 1435, 381), new Rectangle(0, 192, 1435, 381));
            newGameLabel = new StaticTexture(spriteSheet, new Rectangle(1083, 609, 386, 96), new Rectangle(700, 96, 386, 96));
            loadGameLabel = new StaticTexture(spriteSheet, new Rectangle(1083, 906, 401, 96), new Rectangle(700, 0, 401, 96));
            optionsLabel = new StaticTexture(spriteSheet, new Rectangle(1140, 1204, 264, 96), new Rectangle(1101, 0, 264, 96));

            newGameButton = new SelectableTextureButton("New Game", new Rectangle(934, 553, 700, 181), spriteSheet, new Rectangle(0, 0, 700, 181))
            {
                ID = 0,
                bottomNeighborID = 1,
                topNeighborID = 2,
                onClick = () => Game1.StartNewGame()
            };
            loadGameButton = new SelectableTextureButton("Load Game", new Rectangle(934, 849, 700, 181), spriteSheet, new Rectangle(0, 0, 700, 181))
            {
                ID = 1,
                bottomNeighborID = 2,
                topNeighborID = 0
            };
            optionsButton = new SelectableTextureButton("Options", new Rectangle(934, 1151, 700, 181), spriteSheet, new Rectangle(0, 0, 700, 181))
            {
                ID = 2,
                bottomNeighborID = 0,
                topNeighborID = 1
            };

            base.PopulateClickableButtonsList();
        }

        public override void Draw(SpriteBatch batch)
        {
            DrawCRTOverlay(batch);

            newGameButton.Draw(batch, selectedButtonID == newGameButton.ID?Color.White:Color.White * 0.2f, 1f);
            loadGameButton.Draw(batch, selectedButtonID == loadGameButton.ID ? Color.White : Color.White * 0.2f, 1f);
            optionsButton.Draw(batch, selectedButtonID == optionsButton.ID ? Color.White : Color.White * 0.2f, 1f);

            logoTexture.Draw(batch);
            newGameLabel.Draw(batch);
            loadGameLabel.Draw(batch);
            optionsLabel.Draw(batch);
        }

        public override void KeyboardInput(Keys key)
        {
            ClickableButton selectedButton = FindButtonByID(selectedButtonID);

            if (selectedButton != null)
                switch (key)
                {
                    case Keys.W:
                    case Keys.Up:
                        if (selectedButton.topNeighborID >= 0)
                            selectedButtonID = selectedButton.topNeighborID;
                        break;
                    case Keys.S:
                    case Keys.Down:
                        if (selectedButton.bottomNeighborID >= 0)
                            selectedButtonID = selectedButton.bottomNeighborID;
                        break;
                    case Keys.A:
                    case Keys.Left:
                        if (selectedButton.leftNeighborID >= 0)
                            selectedButtonID = selectedButton.leftNeighborID;
                        break;
                    case Keys.D:
                    case Keys.Right:
                        if (selectedButton.rightNeighborID >= 0)
                            selectedButtonID = selectedButton.rightNeighborID;
                        break;
                    case Keys.Enter:
                    case Keys.Space:
                        selectedButton.onClick?.Invoke();
                        break;
                }

            base.KeyboardInput(key);
        }

        public override void OnExit()
        {
            previousMenu = MenuType.TitleMenu;
            base.OnExit();
        }

        public void DrawCRTOverlay(SpriteBatch batch)
        {
            for (int k = 0; k <= (Game1.Graphics.PreferredBackBufferHeight / 12) + 1; k++)
                batch.Draw(spriteSheet, new Rectangle(0, k * 12, Game1.Graphics.PreferredBackBufferWidth, 6), new Rectangle(51, 0, 1, 1), Color.Gray * 0.2f);
        }
    }
}
