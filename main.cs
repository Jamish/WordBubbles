using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class main
    {
        static void Main(string[] args)
        {
            WordBubbles wb = new WordBubbles();

            Console.WriteLine("Enter each row of bubbles using a space as a blank bubble (hit 'return' between each one). When finished, hit return (with a blank line) to continue.\n");


            var rows = new List<string>();
            string input = null;
            while (input != "")
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (input.Length > 0)
                { 
                    if (rows.Count == 0 || input.Length == rows.Last().Length)
                    {
                        rows.Add(input);
                    }
                    else
                    {
                        Console.WriteLine("Each row must be the same length!");
                    }
                }
            }

            var bubbles = new List<Bubble>();
            for (int y = 0; y < rows.Count; y++)
            {
                for (int x = 0; x < rows[0].Length; x++)
                {
                    bubbles.Add(new Bubble(rows[y][x], x, y));

                }
            }
            wb.Bubbles = bubbles;

            Console.WriteLine("Enter the lengths of the blanks, separated by spaces (e.g., 4 4)\n");
            while (true)
            {
                Console.Write("> ");
                List<int> blanks = Console.ReadLine().Split(' ').ToList().Select(x => Int32.Parse(x)).ToList();
                if (blanks.Sum() != bubbles.Where(x => x.Letter != ' ').Count())
                {
                    Console.WriteLine("All bubbles should be used, but your blanks don't match your number of bubbles given");
                } else
                {
                    wb.Blanks = blanks;
                    break;
                }
            }
            
            Console.Clear();

            List<string> solutions = wb.Solve();

            solutions.ForEach(solution => Console.WriteLine(solution));


            Console.ReadLine();
        }
    }
}
