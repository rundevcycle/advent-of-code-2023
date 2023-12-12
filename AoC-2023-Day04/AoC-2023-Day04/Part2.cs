using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day04
{
    public class Part2
    {
        private string _inputData = "";

        public int FinalSum { get; set; }


        public Part2(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            var inputLines = _inputData.Replace("\r", "").Split('\n');

            var originalCards = new List<Card>();
            foreach (var line in inputLines)
            {
                var card = new Card(line);
                originalCards.Add(card);
            }

            foreach (var card in originalCards)
            {
                FinalSum += CardsWon(card, originalCards);
            }

            Console.WriteLine($"Part 2: Final sum is {FinalSum}.");
        }



        private int CardsWon(Card card, List<Card> originalCards)
        {
            // Recursive works, but it's slow.  There might be another approach to make it faster.

            int count = 1;  // This card, at least.
            if (card.NumberOfMatches == 0)
            {
                return count;
            }
            var extraCards = originalCards.Where(c =>
                c.CardNumber > card.CardNumber
                && c.CardNumber <= card.CardNumber + card.NumberOfMatches);

            foreach (var extra in extraCards)
            {
//                Console.WriteLine($"Extra card: {extra.CardNumber} with {extra.NumberOfMatches} matches.");
                count += CardsWon(extra, originalCards);
            }

            return count;
        }
    }
}
