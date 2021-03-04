using System.Collections;
using System.Collections.Generic;

namespace Fractured.World
{
    public class StoryMarker
    {
        public int ID { get { return id; } }
        private readonly int id;
        public int CurrentChapter { get { return chapter; } }
        private readonly int chapter;
        public Time CurrentTime { get { return time; } }
        private readonly Time time;
        public Mode StoryMode { get { return mode; } }
        private readonly Mode mode;
        public string Inaccessible { get { return inaccessible; } }
        private readonly string inaccessible;
        public Location StartLocation { get { return start; } }
        private readonly Location start;
        private readonly Location[] available;
        private readonly Location[] requiredLoc;
        private readonly List<Location> locationsVisited = new List<Location>();
        private readonly Character[] requiredChar;
        private readonly List<Character> charactersTalked = new List<Character>();
        private readonly Item[] requiredItem;
        private readonly List<Item> itemsLooked = new List<Item>();

        public StoryMarker(int markerID, int currentChapter, Time timeOfDay, Mode storyMode, string cantTravelText, Location startLocation, Location[] availableLocations, Location[] requiredLocations, Character[] requiredCharacters, Item[] requiredInspection)
        {
            id = markerID;
            chapter = currentChapter;
            time = timeOfDay;
            mode = storyMode;
            inaccessible = cantTravelText;
            start = startLocation;
            available = availableLocations;
            requiredLoc = requiredLocations;
            requiredChar = requiredCharacters;
            requiredItem = requiredInspection;
        }

        public enum Time
        {
            Morning,
            Day,
            Evening,
            Nighttime
        }

        public enum Mode
        {
            Story,
            Freetime,
            Investigation,
            Trial
        }

        /// <summary>
        /// Returns true if the warp location can be visited during this marker
        /// </summary>
        /// <param name="warp">Location to warp to</param>
        /// <returns></returns>
        public bool CanLocationBeVisited(Location warp)
        {
            if (warp.ChapterUnlock < chapter) { return false; }
            else if (available == null) { return true; }
            else
            {
                foreach (Location l in available){if (l == warp) { return true; }}
                return false; 
            }
        }

        public void SubmitAction(Location visit)
        {
            if (requiredLoc == null) { return; }
            foreach(Location l in requiredLoc) { if(l == visit && !locationsVisited.Contains(visit)) { locationsVisited.Add(visit); }}
        }
        public void SubmitAction(Character talk)
        {
            if (requiredChar == null) { return; }
            foreach(Character c in requiredChar) { if(c == talk && !charactersTalked.Contains(talk)) { charactersTalked.Add(talk); } }
        }
        public void SubmitAction(Item inspect)
        {
            if (requiredItem == null) { return; }
            foreach(Item i in requiredItem) { if(i == inspect && !itemsLooked.Contains(inspect)) { itemsLooked.Add(inspect); } }
        }

        public bool IsMarkerFinished()
        {
            int requirementsMet = 0;
            if (requiredLoc == null) { requirementsMet++; } else if (requiredLoc.Length == locationsVisited.Count) { requirementsMet++; }
            if (requiredChar == null) { requirementsMet++; } else if (requiredChar.Length == charactersTalked.Count) { requirementsMet++; }
            if (requiredItem == null) { requirementsMet++; } else if (requiredItem.Length == itemsLooked.Count) { requirementsMet++; }

            return requirementsMet == 3;
        }
        public void AdvanceToNextMarker()
        {
            Config.SaveFile.currentMarker = Global.GetMarkerFromID(id + 1);
        }
    }
}