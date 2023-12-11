using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day03
{
    public class Part2
    {
        private string _inputData = "";
        public int FinalSum { get; private set; }


        public Part2(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            // Replace periods with spaces & split into lines.
            var inputLines = _inputData.Replace(".", " ").Replace("\r", "").Split("\n").ToList();

            // Get all the part numbers and their positions.
            List<PartNumber> parts = new List<PartNumber>();
            int lineNumber = 0;
            foreach (var line in inputLines)
            {
                parts.AddRange(Part1.SplitLineIntoPartNumbers(line, lineNumber));
                lineNumber++;
            }

            List<Gear> gears = new List<Gear>();
            lineNumber = 0;
            foreach (var line in inputLines) 
            {
                gears.AddRange(SplitLineIntoGears(line, lineNumber));
                lineNumber++;
            }
            Console.WriteLine($"Found {gears.Count} gears.");

            foreach (var gear in gears)
            {
                var adjacentParts = parts.Where(p =>
                    (
                        (p.LineNumber == gear.LineNumber - 1 || p.LineNumber == gear.LineNumber + 1)
                        && p.StartPosition <= gear.Column + 1
                        && p.EndPosition >= gear.Column - 1
                    )
                    || (
                        p.LineNumber == gear.LineNumber
                        && (p.EndPosition == gear.Column - 1
                            || p.StartPosition == gear.Column + 1
                        )
                    )
                ).ToList();

                Console.WriteLine($"Parts adjacent to gear ({gear.LineNumber}, {gear.Column}):");
                foreach (var part in adjacentParts)
                {
                    Console.WriteLine($"  {part.Number} at ({part.LineNumber}, {part.StartPosition}-{part.EndPosition})");
                }

                if (adjacentParts.Count == 2)
                {
                    FinalSum += adjacentParts[0].Number * adjacentParts[1].Number;
                }
            }
            Console.WriteLine($"Part 2: Final sum is {FinalSum}.");

        }


        private List<Gear> SplitLineIntoGears(string line, int lineNumber)
        {
            var gears = new List<Gear>();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '*')
                {
                    gears.Add(new Gear {
                        LineNumber = lineNumber,
                        Column = i
                    });
                }
            }

            return gears;
        }

    }
}
