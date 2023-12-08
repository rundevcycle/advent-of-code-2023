namespace AoC_2023_Day01_Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO Read input from a text file.
            if (args.Length < 1)
            {
                throw new ArgumentException("Must provide a filename argument.");
            }

            string filename = args[0];
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"Unable to locate file: {filename}");
            }

            string inputData = File.ReadAllText(filename);

            var mainApp = new MainApplication(inputData);
            mainApp.Run();
        }
    }
}
