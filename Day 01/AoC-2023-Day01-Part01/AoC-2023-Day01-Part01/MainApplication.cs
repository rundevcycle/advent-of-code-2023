using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_2023_Day01_Part01
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
            int numLines = _inputData.Split("\n").Length;
            Console.WriteLine($"Input contains {numLines} lines of text.");
            var numbers = ExtractNumbers();
            FinalSum = numbers.Sum();
            Console.WriteLine($"The final sum is {FinalSum}.");
        }


        private List<int> ExtractNumbers()
        {
            List<int> numbers = new List<int>();

            foreach (var line in _inputData.Split("\n"))
            {
                int firstDigit = 0;
                int lastDigit = 0;
                foreach (var c in line)
                {
                    if (char.IsDigit(c))
                    {
                        firstDigit = int.Parse(c.ToString());
                        break;
                    }
                }

                foreach (var c in line.Reverse())
                {
                    if (char.IsDigit(c))
                    {
                        lastDigit = int.Parse(c.ToString());
                        break;
                    }
                }
                numbers.Add(firstDigit * 10 + lastDigit);
            }
            return numbers;
        }
    }
}
