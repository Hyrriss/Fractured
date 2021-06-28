using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fractured.Menus
{
    public class StaticTexture
    {
        public Texture2D texture;
        public Rectangle bounds;
        public Rectangle source;

        public StaticTexture(Texture2D texture, Rectangle bounds, Rectangle source)
        {
            this.texture = texture;
            this.bounds = bounds;
            this.source = source;
        }

        public void Draw(SpriteBatch batch)
        {
            if (texture == null) return;
            Draw(batch, Color.White, 1f);
        }

        public void Draw(SpriteBatch batch, Color color, float layerDepth)
        {
            batch.Draw(texture, bounds, source, color, 0f, Vector2.Zero, SpriteEffects.None, layerDepth);
        }
    }
}
