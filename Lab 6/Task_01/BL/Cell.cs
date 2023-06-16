using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Task_01.BL
{
    public class Cell
    {
        public char value;
        private int X;
        private int Y;

        public Cell(char value, int X, int Y)
        {
            this.value = value;
            this.X = X;
            this.Y = Y;
        }

        public char getValue()
        {
            return this.value;
        }

        public void setValue(char value)
        {
            this.value = value;
        }

        public int getX()
        {
            return this.X;
        }

        public int getY()
        {
            return this.Y;
        }

        // public bool isPacmanPresent()
        // {

        // }
    }
}
