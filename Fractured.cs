using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fractured
{
    public enum MenuType
    {
        MainMenu,
        Settings,
        Pause
    }
    public enum ButtonType
    {
        NewGame,
        LoadGame,
        Settings,
        ScreenResolution,
        WindowMode,
        MovementBobbing,
        MusicVolume,
        SFXVolume,
        TextSpeed
    }
    public struct Sprite
    {
        public Texture2D BaseSpriteSheet;
        public Rectangle SpriteLocation;
        public Vector2 ScreenPosition;
    }

}
