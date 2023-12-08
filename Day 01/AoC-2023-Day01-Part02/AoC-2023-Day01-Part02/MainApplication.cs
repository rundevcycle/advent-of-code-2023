using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_2023_Day01_Part02
{
    public class MainApplication
    {
        private string _inputData = "";

        public int FinalSum { get; private set; } = 0;


        public MainApplication(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            var lines = _inputData.Split("\r\n").ToList();
            Console.WriteLine($"Input contains {lines.Count} lines of text.");
//            foreach (var line in lines)
//            {
//                Console.WriteLine($"     {line}");
//            }

            var firstDigits = GetFirstDigits(lines);
            var lastDigits = GetLastDigits(lines);
        
            for (int i = 0; i < firstDigits.Count; i++)
            {
                FinalSum += firstDigits[i] * 10 + lastDigits[i];
            }

            Console.WriteLine($"The final sum is {FinalSum}.");
        }



        private List<int> GetFirstDigits(List<string> inputLines)
        {
            List<int> digits = new List<int>();

            Dictionary<string, int> searchTerms = new Dictionary<string, int>() {
                { "1", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            foreach (var line in inputLines)
            {
                int minIndex = int.MaxValue;
                int firstDigit = 0;

                foreach (var term in searchTerms)
                {
                    int position = line.IndexOf(term.Key);
                    if (position > -1 && position < minIndex)
                    {
                        minIndex = position;
                        firstDigit= term.Value;
                    }
                }
                digits.Add(firstDigit);
            }

            return digits;
        }



        private List<int> GetLastDigits(List<string> inputLines)
        {
            List<int> digits = new List<int>();

            Dictionary<string, int> searchTerms = new Dictionary<string, int>() {
                { "1", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "eno", 1 },
                { "owt", 2 },
                { "eerht", 3 },
                { "ruof", 4 },
                { "evif", 5 },
                { "xis", 6 },
                { "neves", 7 },
                { "thgie", 8 },
                { "enin", 9 }
            };

            foreach (var line in inputLines)
            {
                char[] stringArray = line.ToCharArray();
                Array.Reverse(stringArray);
                var reversed = new string(stringArray);

                int minIndex = int.MaxValue;
                int firstDigit = 0;

                foreach (var term in searchTerms)
                {
                    int position = reversed.IndexOf(term.Key);
                    if (position > -1 && position < minIndex)
                    {
                        minIndex = position;
                        firstDigit= term.Value;
                    }
                }
                digits.Add(firstDigit);
            }

            return digits;
        }

    }
}
