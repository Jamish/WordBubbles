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
        private HashSet<string> dictionary;

        // All bubbles that make up the puzzle
        public List<Bubble> Bubbles { get; set; }

        // The length of each word that we are solving for
        public List<int> Blanks { get; set; }

        public WordBubbles()
        {
            dictionary = new HashSet<string>(File.ReadAllText("words.txt").Split(new string[] { Environment.NewLine }, System.StringSplitOptions.None).Distinct());
        }

        public List<string> Solve()
        {
            var potentialSolutions = Recurse(new List<Bubble>(), Bubbles);
            var solutions = potentialSolutions.Where(phrase => GetString(phrase).Split(' ').All(word => dictionary.Contains(word))).ToList();

            return solutions.Select(phrase => GetString(phrase)).ToList();
        }

        private List<List<Bubble>> Recurse(List<Bubble> phrase, List<Bubble> remainingBubbles, int currentWordToSolve = 0)
        {
            var results = new List<List<Bubble>>();
            var currentWordLength = GetString(phrase).Split(' ').Last().Length;


            if (currentWordLength < Blanks[currentWordToSolve])
            {
                // If the word isn't finished, then find all potential bubbles that can form the next letter of the word.
                var remainingAdjacentBubbles = remainingBubbles;
                if (phrase.Count > 0)
                {
                    remainingAdjacentBubbles = remainingBubbles.Where(x => x.IsAdjacentTo(phrase.Last())).ToList();
                }

                foreach (Bubble bubble in remainingAdjacentBubbles)
                {
                    var nextPhrase = new List<Bubble>(phrase);
                    nextPhrase.Add(bubble);

                    var nextRemainingBubbles = new List<Bubble>(remainingBubbles);
                    nextRemainingBubbles.Remove(bubble);
                    results.AddRange(Recurse(nextPhrase, nextRemainingBubbles, currentWordToSolve));
                }
            }
            else if (currentWordLength == Blanks[currentWordToSolve])
            {
                // If the word finished and there are no more blanks to solve, return the full phrase.
                if (currentWordToSolve == Blanks.Count - 1)
                {
                    results.Add(phrase);
                }
                else
                {
                    // If the word is complete but there is another blank to solve, then insert a blank bubble to indicate a space and the start of a new word in the phrase.
                    var nextWord = new List<Bubble>(phrase);
                    nextWord.Add(Bubble.BlankBubble());

                    results.AddRange(Recurse(nextWord, remainingBubbles, currentWordToSolve+1));
                }
            }

            return results;
        }

        public string GetString(List<Bubble> phrase)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var bubble in phrase)
            {
                sb.Append(bubble.Letter);
            }
            return sb.ToString();
        }

    }
}
