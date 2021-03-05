using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Fractured.World;

namespace Fractured.UI
{
    public class Interface
    {
        private readonly ContentManager Content;
        private Texture2D interfaceSpriteSheet;
        private List<Sprite> sprites;
        private Sprite textBoxSprite;
        private Sprite advanceTextSprite;
        private string textBoxText;
        private string characterName;

        public Interface(ContentManager primaryManager)
        {
            Content = new ContentManager(primaryManager.ServiceProvider, primaryManager.RootDirectory);
        }

        public void SetActive(StoryMarker currentMarker)
        {
            Sprite indicatorBkg;
            Sprite chapterIndicator;
            Sprite timeIndicator;
            Sprite celestialIndicator;

            Rectangle prologueSpriteLocation = new Rectangle(1591, 360, 545, 89);
            Rectangle chapter1SpriteLocation = new Rectangle(1373, 1, 522, 89);
            Rectangle chapter2SpriteLocation = new Rectangle(1897, 1, 546, 89);
            Rectangle chapter3SpriteLocation = new Rectangle(1373, 92, 548, 89);
            Rectangle chapter4SpriteLocation = new Rectangle(1923, 92, 548, 89);
            Rectangle chapter5SpriteLocation = new Rectangle(1, 183, 548, 89);
            Rectangle chapter6SpirteLocation = new Rectangle(551, 183, 548, 89);
            Rectangle epilogueSpriteLocation = new Rectangle(1447, 183, 501, 89);

            Rectangle morningSpriteLocation = new Rectangle(827, 360, 365, 56);
            Rectangle daytimeSpriteLocation = new Rectangle(1101, 183, 344, 70);
            Rectangle eveningSpriteLocation = new Rectangle(1950, 183, 344, 56);
            Rectangle nighttimeSpriteLocation = new Rectangle(1194, 360, 395, 70);

            Rectangle sunSpriteLocation = new Rectangle(2138, 360, 257, 249);
            Vector2 sunScreenLocation = new Vector2(61, 139);
            Rectangle moonSpriteLocation = new Rectangle(2296, 183, 176, 175);
            Vector2 moonScreenLocation = new Vector2(107, 182);

            interfaceSpriteSheet = Content.Load<Texture2D>("Sprites\\UI\\standardUI");
            indicatorBkg = new Sprite { BaseSpriteSheet = interfaceSpriteSheet, SpriteLocation = new Rectangle(1, 274, 824, 237), ScreenPosition = Vector2.Zero };
            chapterIndicator = new Sprite { BaseSpriteSheet = interfaceSpriteSheet, ScreenPosition = new Vector2(55, 49) };
            chapterIndicator.SpriteLocation = currentMarker.CurrentChapter switch
            {
                0 => prologueSpriteLocation,
                1 => chapter1SpriteLocation,
                2 => chapter2SpriteLocation,
                3 => chapter3SpriteLocation,
                4 => chapter4SpriteLocation,
                5 => chapter5SpriteLocation,
                6 => chapter6SpirteLocation,
                7 => epilogueSpriteLocation,
                _ => prologueSpriteLocation,
            };
            timeIndicator = new Sprite { BaseSpriteSheet = interfaceSpriteSheet, ScreenPosition = new Vector2(399, 205) };
            celestialIndicator = new Sprite { BaseSpriteSheet = interfaceSpriteSheet };
            switch (currentMarker.CurrentTime)
            {
                case StoryMarker.Time.Morning:
                    timeIndicator.SpriteLocation = morningSpriteLocation;
                    timeIndicator.ScreenPosition = new Vector2(399, 212);
                    celestialIndicator.SpriteLocation = sunSpriteLocation;
                    celestialIndicator.ScreenPosition = sunScreenLocation;
                    break;
                case StoryMarker.Time.Day:
                    timeIndicator.SpriteLocation = daytimeSpriteLocation;
                    celestialIndicator.SpriteLocation = sunSpriteLocation;
                    celestialIndicator.ScreenPosition = sunScreenLocation;
                    break;
                case StoryMarker.Time.Evening:
                    timeIndicator.SpriteLocation = eveningSpriteLocation;
                    timeIndicator.ScreenPosition = new Vector2(399, 212);
                    celestialIndicator.SpriteLocation = moonSpriteLocation;
                    celestialIndicator.ScreenPosition = moonScreenLocation;
                    break;
                case StoryMarker.Time.Nighttime:
                    timeIndicator.SpriteLocation = nighttimeSpriteLocation;
                    celestialIndicator.SpriteLocation = moonSpriteLocation;
                    celestialIndicator.ScreenPosition = moonScreenLocation;
                    break;
            }

            sprites = new List<Sprite>() { indicatorBkg, chapterIndicator, timeIndicator, celestialIndicator };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprites != null)
            {
                foreach (Sprite s in sprites) { spriteBatch.Draw(s.BaseSpriteSheet, s.ScreenPosition, s.SpriteLocation, Color.White); }
            }
        }
    }
}
