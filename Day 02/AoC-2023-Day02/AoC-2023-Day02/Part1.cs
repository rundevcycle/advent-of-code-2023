using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day02
{
    public class Part1
    {
        private string _inputData = "";

        public int FinalSum { get; private set; }


        const int MAX_RED = 12;
        const int MAX_GREEN = 13;
        const int MAX_BLUE = 14;


        public Part1(string inputData)
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
                if (game.MaxNumRed <= MAX_RED
                    && game.MaxNumGreen <= MAX_GREEN
                    && game.MaxNumBlue <= MAX_BLUE)
                {
                    Console.WriteLine($"Game {game.GameId} is valid with a max of {game.MaxNumRed} red, {game.MaxNumGreen} green, and {game.MaxNumBlue} blue balls.");
                    FinalSum += game.GameId;
                }
                else
                {
                    Console.WriteLine($"Game {game.GameId} is NOT valid with {game.MaxNumRed} red, {game.MaxNumGreen} green, and {game.MaxNumBlue} blue balls.");
                }
            }

            Console.WriteLine($"Part 1: The sum of valid games is {FinalSum}.");

        }

    }
}
