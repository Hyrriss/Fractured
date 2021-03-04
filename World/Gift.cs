using System;
using System.Collections.Generic;
using System.Text;

namespace Fractured.World
{
    public class Gift
    {
        public int ID { get; set; }
        public int Collection { get; set; }
        public string Name { get; set; }
        public bool IsRollable { get; set; }
        public Character[] Loves { get; set; }
        public Character[] Likes { get; set; }
        public Character[] Dislikes { get; set; }
        public Character[] Hates { get; set; }
        public string Description { get; set; }

        public Gift(int id, int collection, string name, bool rollable, Character[] loves, Character[] likes, Character[] dislikes, Character[] hates, string description)
        {
            ID = id;
            Collection = collection;
            Name = name;
            IsRollable = rollable;
            Loves = loves;
            Likes = likes;
            Dislikes = dislikes;
            Hates = hates;
            Description = description;
        }
    }
}
