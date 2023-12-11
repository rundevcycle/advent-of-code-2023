using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day02
{
    public class Game
    {
        public int GameId { get; set; }
        public int MaxNumRed { get; set; } = 0;
        public int MaxNumGreen { get; set; } = 0;
        public int MaxNumBlue { get; set; } = 0;


        public Game(string inputLine)
        {
            string[] tmp1 = inputLine.Split(":");
            if (tmp1 == null || tmp1.Length != 2)
            {
                throw new NullReferenceException("Input line is not valid.");
            }

            GameId = int.Parse(tmp1[0].Replace("Game ", ""));

            var revealedSets = tmp1[1].Split(";").ToList();

            foreach(var set in revealedSets)
            {
                var balls = set.Split(",");
                foreach(var ball in balls)
                {
                    if (ball.Contains("red"))
                    {
                        int qty = int.Parse(ball.Replace("red", ""));
                        if (qty > MaxNumRed) 
                        {
                            MaxNumRed = qty;
                        }
                    }
                    if (ball.Contains("green"))
                    {
                        int qty = int.Parse(ball.Replace("green", ""));
                        if (qty > MaxNumGreen) 
                        {
                            MaxNumGreen = qty;
                        }
                    }
                    if (ball.Contains("blue"))
                    {
                        int qty = int.Parse(ball.Replace("blue", ""));
                        if (qty > MaxNumBlue) 
                        {
                            MaxNumBlue = qty;
                        }
                    }
                }
            }

        }
    }
}
