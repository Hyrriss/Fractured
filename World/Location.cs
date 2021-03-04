using System;
using System.Collections.Generic;
using System.Text;

namespace Fractured.World
{ 
    public class Location
    {
        public int ID { get { return id; } }
        private readonly int id;
        public string Name { get { return name; } }
        private readonly string name;
        public string DisplayName { get { return display; } }
        private readonly string display;
        public int ChapterUnlock { get { return unlock; } }
        private readonly int unlock;
        public LocationType TypeOfLocation { get { return type; } }
        private readonly LocationType type;

        /// <summary>
        /// Creates a new location
        /// </summary>
        /// <param name="locationID">ID number of the location</param>
        /// <param name="locationName">Unique internal name for location</param>
        /// <param name="displayedName">Name to be displayed on the map</param>
        /// <param name="chapterUnlocked">Earliest chapter the location is unlocked</param>
        /// <param name="locationType">Describes the controls of the location. Static = Cursor, Moveable = Walking, Trial = No controls</param>
        public Location(int locationID, string locationName, string displayedName, int chapterUnlocked, LocationType locationType)
        {
            id = locationID;
            name = locationName;
            display = displayedName;
            unlock = chapterUnlocked;
            type = locationType;
        }

        public enum LocationType
        {
            Static_Room,
            Moveable_Room,
            Trial_Room
        }
    }
}
