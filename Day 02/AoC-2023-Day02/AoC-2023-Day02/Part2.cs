using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day02
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
            List<string> inputLines = _inputData.Split("\r\n").ToList();
            List<Game> games = new List<Game>();
            foreach (string line in inputLines) 
            { 
                games.Add(new Game(line));
            }

            foreach (Game game in games)
            {
                Console.WriteLine($"Game {game.GameId} is valid with a minimum of {game.MaxNumRed} red, {game.MaxNumGreen} green, and {game.MaxNumBlue} blue balls.");
                FinalSum += game.MaxNumRed * game.MaxNumGreen * game.MaxNumBlue;
            }

            Console.WriteLine($"Part 2: The sum of the powers is {FinalSum}.");

        }

    }
}
