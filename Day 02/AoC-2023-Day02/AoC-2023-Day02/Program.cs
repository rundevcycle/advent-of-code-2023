using System.Net.Mail;

namespace AoC_2023_Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) 
            {
                throw new ArgumentException("Must provide a filename for the input file.");
            }

            string filename = args[0];
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"Unable to locate file: {filename}");
            }

            string inputData = File.ReadAllText(filename);

            var part1 = new Part1(inputData);
            part1.Run();

            var part2 = new Part2(inputData);
            part2.Run();
        }
    }
}
