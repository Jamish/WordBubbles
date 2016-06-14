using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class WordBubbles
    {
        private List<string> dictionary;
        public List<Bubble> Bubbles { get; set; }
        public List<int> Blanks { get; set; }

        public WordBubbles()
        {
            dictionary = File.ReadAllText("words.txt").Split(new string[] { Environment.NewLine }, System.StringSplitOptions.None).ToList();
        }

        public List<string> Solve()
        {
            var potentialSolutions = RecurseForBlank(new List<Bubble>(), Bubbles, 0);


            // return potentialSolutions.Select(phrase => GetString(phrase)).Where(phrase => phrase.Split(' ').All(word => dictionary.Contains(word)))).toList();

            var solutions = potentialSolutions.Where(phrase => GetString(phrase).Split(' ').All(word => dictionary.Contains(word))).ToList();

            return solutions.Select(phrase => GetString(phrase)).ToList();
        }

        private List<List<Bubble>> RecurseForBlank(List<Bubble> word, List<Bubble> remainingBubbles, int i)
        {
            var results = new List<List<Bubble>>();
            var currentLength = GetString(word).Split(' ').Last().Length;
            if (currentLength < Blanks[i])
            {
                var remainingAdjacentBubbles = remainingBubbles;
                if (word.Count > 0)
                {
                    remainingAdjacentBubbles = remainingBubbles.Where(x => x.IsAdjacentTo(word.Last())).ToList();
                }

                foreach (Bubble bubble in remainingAdjacentBubbles)
                {
                    var nextWord = new List<Bubble>(word);
                    nextWord.Add(bubble);

                    var nextRemainingBubbles = new List<Bubble>(remainingBubbles);
                    nextRemainingBubbles.Remove(bubble);
                    results.AddRange(RecurseForBlank(nextWord, nextRemainingBubbles, i));
                }
            }
            else if (currentLength == Blanks[i])
            {
                if (i == Blanks.Count - 1)
                {
                    results.Add(word);
                }
                else
                {
                    var nextWord = new List<Bubble>(word);
                    nextWord.Add(Bubble.BlankBubble());

                    results.AddRange(RecurseForBlank(nextWord, remainingBubbles, i+1));
                }
            }

            return results;
        }

        public string GetString(List<Bubble> word)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var bubble in word)
            {
                sb.Append(bubble.Letter);
            }
            return sb.ToString();
        }

    }
}
