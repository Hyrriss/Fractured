using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Fractured.World
{
    public class StoryLoc
    {
        public struct LocationPopulation
        {
            public StoryMarker StoryMarker;
            public Location Location;
            public Dictionary<Character, Vector3> Characters;
            public Dictionary<Item, Vector3> Items;
        }
    }
}
