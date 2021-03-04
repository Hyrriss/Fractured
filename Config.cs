using Microsoft.Xna.Framework.Input;
using Fractured.World;

namespace Fractured.Config
{
    public static class Controls
    {
        public static Keys MoveUp { get { return Keys.W; } }
        public static Keys MoveDown { get { return Keys.S; } }
        public static Keys MoveLeft { get { return Keys.A; } }
        public static Keys MoveRight { get { return Keys.D; } }
        public static Keys Submit { get { return Keys.Enter; } }
        public static Keys Exit { get { return Keys.Escape; } }
    }

    public static class SaveFile
    {
        public static StoryMarker currentMarker;
    }
}
