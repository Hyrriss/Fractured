using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fractured.Menus
{
    public class SelectableTextureButton : ClickableButton
    {
        public Texture2D texture;
        public Rectangle source;

        public string selectionText = "";

        public SelectableTextureButton(string name, Rectangle bounds, Texture2D texture, Rectangle source, float scale = 1f)
            :base(name, bounds)
        {
            this.texture = texture;
            this.source = source;

            base.scale = scale;
        }

        public void Draw(SpriteBatch batch)
        {
            if (!isVisible) return;
            if (this.texture != null)
                Draw(batch, Color.White, 1f);
        }

        public void Draw(SpriteBatch batch, Color color, float layerDepth)
        {
            if (!isVisible) return;
            if (this.texture != null)
                batch.Draw(this.texture, bounds, source, color, 0f, Vector2.Zero, SpriteEffects.None, layerDepth);
        }
    }
}
