using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Fractured.World;

namespace Fractured.UI
{
    public class Interface
    {
        private readonly ContentManager Content;
        private readonly Game1 Game1;
        private Texture2D interfaceSpriteSheet;
        private readonly Texture2D textBoxSprite;
        private readonly Texture2D portraitSprite;
        private readonly bool isIndicatorActive;
        private readonly bool isTextBoxActive;
        private readonly bool isPortraitActive;

        public Interface(Game1 game, ContentManager primaryManager)
        {
            Game1 = game;
            Content = new ContentManager(primaryManager.ServiceProvider, primaryManager.RootDirectory);
        }

        public void SetActive(StoryMarker currentMarker)
        {
            interfaceSpriteSheet = Content.Load<Texture2D>("Sprites\\UI\\standardUI");
        }
    }
}
