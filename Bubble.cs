using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bubble
    {

        /*
         * Coordinates and letter values for blank space bubbles, used to split words. 
         * Obviously, the character between words is a space
         * Blank coordinates are special because the end of one word and the start of another do not have to be adjacent.
         */
        const int blank_coordinate = -1;
        public const char blank_char = ' ';

        public char Letter { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Bubble(char letter, int x, int y)
        {
            Letter = letter;
            X = x;
            Y = y;
        }

        public bool IsAdjacentTo(Bubble other)
        {
            if (other.X == blank_coordinate && other.Y == blank_coordinate)
            {
                return true;
            }

            return Math.Abs(X - other.X) <= 1 && Math.Abs(Y - other.Y) <= 1;
        }

        public static Bubble BlankBubble()
        {
            return new Bubble(blank_char, blank_coordinate, blank_coordinate);
        }
    }
}
