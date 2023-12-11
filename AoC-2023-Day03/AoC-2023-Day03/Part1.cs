using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace AoC_2023_Day03
{
    public class Part1
    {
        private string _inputData = "";
        public int FinalSum { get; private set; }


        public Part1(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            // Replace periods with spaces & split into lines.
            var inputLines = _inputData.Replace(".", " ").Replace("\r", "").Split("\n").ToList();

            // Read characters from each line.  If it's a digit, track the first position, and keep reading until the last digit. 
            // When we reach the end of a number, check the surrounding positions for non-digit characters.
            int lineNumber = 0;
            foreach (var line in inputLines)
            {
                List<PartNumber> parts = SplitLineIntoPartNumbers(line, lineNumber);

                foreach (var partNumber in parts)
                {
                    Console.WriteLine(string.Format("Line {0}, part {1} at position {2}-{3}.",
                        lineNumber + 1, partNumber.Number, partNumber.StartPosition, partNumber.EndPosition));

                    if (ContainsSymbol(inputLines, lineNumber - 1, partNumber.StartPosition - 1, lineNumber + 1, partNumber.EndPosition + 1))
                    {
                        partNumber.IsValidPartNumber = true;
                        FinalSum += partNumber.Number;
                        Console.WriteLine("  VALID");
                    }
                }

                lineNumber++;
            }

            Console.WriteLine($"Part 1: Final sum is {FinalSum}.");
        }


        public static List<PartNumber> SplitLineIntoPartNumbers(string line, int lineNumber)
        {
            List<PartNumber> parts = new List<PartNumber>();

            bool inNumber = false;

            int startPosn = 0;
            int endPosn = 0;
            int number = 0;

            for (int i = 0; i < line.Length; i++) 
            { 
                if (char.IsDigit(line[i]))
                {
                    if (!inNumber)
                    {
                        inNumber = true;
                        startPosn = i;
                        endPosn = i;
                        number = int.Parse(line[i].ToString());
                    }
                    else
                    {
                        endPosn = i;
                        number = number * 10 + int.Parse(line[i].ToString());
                    }
                }
                else
                {
                    // Not a digit
                    if (inNumber)
                    {
                        parts.Add(new PartNumber { 
                            StartPosition = startPosn, 
                            EndPosition = endPosn,
                            LineNumber = lineNumber,
                            Number = number
                        });
                        inNumber = false;
                    }
                }
            }

            // Edge case when the number is at the end of a line.
            if (inNumber)
            {
                parts.Add(new PartNumber { 
                    StartPosition = startPosn, 
                    EndPosition = endPosn,
                    LineNumber = lineNumber,
                    Number = number
                });
            }

            return parts;
        }


        private bool ContainsSymbol(List<string> allLines, int firstRow, int firstCol, int lastRow, int lastCol)
        {
            if (firstRow < 0)
            {
                firstRow = 0;
            }
            if (firstCol < 0)
            {
                firstCol = 0;
            }
            if (lastRow >= allLines.Count)
            {
                lastRow = allLines.Count - 1;
            }
            if (lastCol > allLines[lastRow].Length - 1)
            {
                lastCol = allLines[lastRow].Length - 1;
            }

            for (int row = firstRow; row <= lastRow; row++)
            {
                for (int col = firstCol; col <= lastCol; col++)
                {
                    char c = allLines[row][col];
                    if (!char.IsWhiteSpace(c) && !char.IsDigit(c))
                    {
                        return true;  // short circuit on first symbol
                    }
                }
            }

            return false;  // no symbols found.
        }

    }
}
