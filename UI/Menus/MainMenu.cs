using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Fractured.World;

namespace Fractured.UI.Menus
{
    public static class MainMenu
    {
        /// <summary>
        /// Loads all static textures in the menu
        /// </summary>
        /// <param name="Content">The content manager for the menu UI layer</param>
        /// <param name="spriteSheet">The sprite sheet for the menu</param>
        /// <returns></returns>
        public static List<Sprite> InstantiateStaticTextures(ContentManager Content, Texture2D spriteSheet)
        {
            List<Sprite> sprites = new List<Sprite>();
            int[] charactersThatCanAppearOnTheTitle = { 3, 4, 7, 8, 9, 12, 14, 15, 16 };
            Random portaitRNG = new Random();
            int titlePortrait = portaitRNG.Next(0, charactersThatCanAppearOnTheTitle.Length);

            /*Background*/ sprites.Add(new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1, 2560, 1440), ScreenPosition = Vector2.Zero });
            /*Protagonist*/ sprites.Add(new Sprite { BaseSpriteSheet = Content.Load<Texture2D>("Sprites\\Char\\1"), SpriteLocation = Global.RectangleFromCharacterSpriteID(0), ScreenPosition = new Vector2(0, 340) });
            /*Secondary Character*/ sprites.Add(new Sprite { BaseSpriteSheet = Content.Load<Texture2D>($"Sprites\\Char\\{charactersThatCanAppearOnTheTitle[titlePortrait]}"), SpriteLocation = Global.RectangleFromCharacterSpriteID(0), ScreenPosition = new Vector2(1500, 390) });
            /*Overlay*/ sprites.Add(new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(2563, 1, 2560, 1440), ScreenPosition = Vector2.Zero });
            /*Logo*/ sprites.Add(new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1397, 1441, 1435, 381), ScreenPosition = new Vector2(545, 59) });

            return sprites;
        }

        /// <summary>
        /// Loads all buttons in the menu
        /// </summary>
        /// <param name="spriteSheet">The sprite sheet for the menu</param>
        /// <returns></returns>
        public static List<Button> InstantiateButtons(Texture2D spriteSheet)
        {
            List<Button> buttons = new List<Button>
            {
                new Button(0, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1826, 689, 197), ScreenPosition = new Vector2(937, 546) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(691, 1826, 689, 197), ScreenPosition = new Vector2(937, 546) }),
                new Button(1, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1443, 697, 199), ScreenPosition = new Vector2(935, 842) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(700, 1443, 697, 199), ScreenPosition = new Vector2(935, 842) }),
                new Button(2, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1386, 1826, 685, 196), ScreenPosition = new Vector2(938, 1143) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(2073, 1826, 685, 196), ScreenPosition = new Vector2(938, 1143) })
            };

            return buttons;
        }

        public static void NewGame()
        {
            Config.SaveFile.currentMarker = Global.GetMarkerFromID(0);
            Config.SaveFile.currentLocation = Global.GetLocFromID(Global.Loc_ID_Null);
        }
    }
}
