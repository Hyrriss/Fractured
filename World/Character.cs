using System;
using System.Collections.Generic;
using System.Text;

namespace Fractured.World
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }
        public double Height { get; set; }

        public Character(int id, string name, string display, double height)
        {
            ID = id;
            Name = name;
            Display = display;
            Height = height;
        }
    }
}
