using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day04
{
    public class Part1
    {
        private string _inputData = "";

        public int FinalSum { get; set; }

        public Part1(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            var inputLines = _inputData.Replace("\r", "").Split('\n');

            foreach (var line in inputLines)
            {
                var card = new Card(line);
                FinalSum += card.PointValue;
            }

            Console.WriteLine($"Part 1: Final sum is {FinalSum}.");
        }

    }
}
