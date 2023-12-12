using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day04
{
    public class Card
    {
        public int CardNumber { get; set; }
        public List<int> WinningNumbers { get; set; } = new List<int>();
        public List<int> MyNumbers { get; set; } = new List<int>();


        public Card(string inputLine)
        {
            var numberSets = inputLine.Split("|");

            var tmp1 = numberSets[0].Split(":");
            CardNumber = int.Parse(tmp1[0].Replace("Card ", ""));

            foreach (var n in tmp1[1].Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                WinningNumbers.Add(int.Parse(n));
            }
            WinningNumbers.Sort();
            Console.WriteLine($"Winning numbers are [{string.Join(", ", WinningNumbers)})");

            foreach (var n in numberSets[1].Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                MyNumbers.Add(int.Parse(n));
            }
            MyNumbers.Sort();
            Console.WriteLine($"My numbers are [{string.Join(", ", MyNumbers)})");
        }


        public int NumberOfMatches {
            get
            {
                return MyNumbers.Where(m => WinningNumbers.Contains(m)).Count();
            }
        }


        public int PointValue { 
            get
            {
                int pointValue = 0;
                if (NumberOfMatches > 0)
                {
                    pointValue = (int) Math.Pow(2, NumberOfMatches - 1);
                }
                Console.WriteLine($"Card {CardNumber} has {NumberOfMatches} winning numbers for {pointValue} points.");
                return pointValue;
            }
        }

    }
}
