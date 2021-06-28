using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fractured.Menus
{
    public class ClickableButton
    {
        public int ID;
        public int rightNeighborID = -1;
        public int leftNeighborID = -1;
        public int topNeighborID = -1;
        public int bottomNeighborID = -1;
        public Dictionary<Keys, int> keyboardInputAccessID;

        public string name;
        public string label;

        public bool isVisible = true;

        public Rectangle bounds;
        public float scale = 1f;

        public Action onClick;


        public ClickableButton(string name, string label, Rectangle bounds)
        {
            this.name = name;
            this.label = label;
            this.bounds = bounds;
        }
        public ClickableButton(string name, Rectangle bounds)
        {
            this.name = name;
            this.bounds = bounds;
        }


    }
}
