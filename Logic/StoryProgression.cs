using System;
using System.Collections.Generic;
using System.Text;
using Fractured.World;

namespace Fractured.Logic
{
    public static class StoryProgression
    {
        private static List<Location> visitedLocations;
        private static Character[] talkedCharacters;

        public static void ResetStoryProgression()
        {
            visitedLocations = new List<Location>();
        }

        public static bool HasLocationBeenVisited(Location location)
        {
            foreach (Location l in visitedLocations) { if (location == l) return true; }
            visitedLocations.Add(location);
            return false;
        }
    }
}
