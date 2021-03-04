using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fractured.UI.Menus
{
    public static class Settings
    {
        /// <summary>
        /// Loads all static textures in the menu
        /// </summary>
        /// <param name="Content">The content manager for the menu UI layer</param>
        /// <param name="spriteSheet">The sprite sheet for the menu</param>
        /// <returns></returns>
        public static List<Sprite> InstantiateStaticTextures(Texture2D spriteSheet)
        {
            return new List<Sprite>
            {
                /*Background*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 84, 2560, 1440), ScreenPosition = Vector2.Zero }
            };
        }

        /// <summary>
        /// Loads all static textures in the menu
        /// </summary>
        /// <param name="Content">The content manager for the menu UI layer</param>
        /// <param name="spriteSheet">The sprite sheet for the menu</param>
        /// <returns></returns>
        public static List<Sprite> InstantiateButtonLabels(Texture2D spriteSheet)
        {
            return new List<Sprite>
            {
                /*Screen Resolution*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1586, 1820, 907, 62), ScreenPosition = new Vector2(205, 126) },
                /*Window Mode*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1848, 1964, 648, 62), ScreenPosition = new Vector2(331, 284) },
                /*Movement Bobbing*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1820, 897, 78), ScreenPosition = new Vector2(210, 441) },
                /*Music Volume*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(900, 1820, 684, 62), ScreenPosition = new Vector2(314, 606) },
                /*Sound Effect Volume*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(900, 1884, 1055, 62), ScreenPosition = new Vector2(128, 766) },
                /*Text Speed*/ new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1958, 1884, 532, 78), ScreenPosition = new Vector2(387, 921) }
            };
        }

        /// <summary>
        /// Loads all buttons in the menu
        /// </summary>
        /// <param name="spriteSheet">The sprite sheet for the menu</param>
        /// <returns></returns>
        public static List<Button> InstantiateButtons(Texture2D spriteSheet)
        {
            Vector2 inactiveBarSpriteSize = new Vector2(981, 81);
            Vector2 inactiveBarSpritePosition = new Vector2(1555, 1728);
            Vector2 activeBarSpriteSize = new Vector2(82, 81);
            Vector2 activeBarSpritePosition = new Vector2(1596, 1);
            int activeBarSpriteOffset = 100;

            return new List<Button>
            {
                /*Screen Resolution*/ new Button(0, new Sprite[] { new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1109, 1, 496, 46), ScreenPosition = new Vector2(1651, 139) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1, 532, 46), ScreenPosition = new Vector2(1589, 139) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(535, 1, 561, 46), ScreenPosition = new Vector2(1570, 139) } }, 3, 2),
                /*Window Mode */ new Button(1, new Sprite[] { new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1848, 2028, 485, 62), ScreenPosition = new Vector2(1609, 288) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1680, 1, 592, 62), ScreenPosition = new Vector2(1556, 288) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1848, 1654, 590, 62), ScreenPosition = new Vector2(1559, 288) } }, 3, 1),
                /*Movement Bobbing*/ new Button(2, new Sprite[] { new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1848, 1526, 439, 62), ScreenPosition = new Vector2(1632, 452) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1848, 1590, 418, 62), ScreenPosition = new Vector2(1642, 452) } }, 2, 1),
                /*Music Volume*/ new Button(3, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle((int)inactiveBarSpritePosition.X, (int)inactiveBarSpritePosition.Y, (int)inactiveBarSpriteSize.X, (int)inactiveBarSpriteSize.Y), ScreenPosition = new Vector2(1361, 597) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle((int)activeBarSpritePosition.X, (int)activeBarSpritePosition.Y, (int)activeBarSpriteSize.X, (int)activeBarSpriteSize.Y), ScreenPosition = new Vector2(1361, 597) }, 11, 0, activeBarSpriteOffset),
                /*Sound Effect Volume*/ new Button(3, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle((int)inactiveBarSpritePosition.X, (int)inactiveBarSpritePosition.Y, (int)inactiveBarSpriteSize.X, (int)inactiveBarSpriteSize.Y), ScreenPosition = new Vector2(1361, 757) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle((int)activeBarSpritePosition.X, (int)activeBarSpritePosition.Y, (int)activeBarSpriteSize.X, (int)activeBarSpriteSize.Y), ScreenPosition = new Vector2(1361, 757) }, 11, 0, activeBarSpriteOffset),
                /*Text Speed*/ new Button(3, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle((int)inactiveBarSpritePosition.X, (int)inactiveBarSpritePosition.Y, (int)inactiveBarSpriteSize.X, (int)inactiveBarSpriteSize.Y), ScreenPosition = new Vector2(1361, 917) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle((int)activeBarSpritePosition.X, (int)activeBarSpritePosition.Y, (int)activeBarSpriteSize.X, (int)activeBarSpriteSize.Y), ScreenPosition = new Vector2(1361, 917) }, 11, 0, activeBarSpriteOffset),
                /*Submit/Cancel*/ new Button(6, new Sprite[] { new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1948, 1845, 99), ScreenPosition = new Vector2(349, 1150) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1627, 1845, 99), ScreenPosition = new Vector2(349, 1150) }, new Sprite { BaseSpriteSheet = spriteSheet, SpriteLocation = new Rectangle(1, 1526, 1845, 99), ScreenPosition = new Vector2(349, 1150) } }, 3, 1, true, true),
            };


        }

        /// <summary>
        /// Sends settings values to the config class and saves to the settings config file
        /// </summary>
        public static void SubmitSettings()
        {
            Debug.Print("Settings Saved");
        }
    }
}
