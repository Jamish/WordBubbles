using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bubble
    {
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
            // -1, -1 is for blank space bubbles, used to split words
            if (other.X == -1 && other.Y == -1)
            {
                return true;
            }

            return Math.Abs(X - other.X) <= 1 && Math.Abs(Y - other.Y) <= 1;
        }



        public static Bubble BlankBubble()
        {
            return new Bubble(' ', -1, -1);
        }
    }
}
