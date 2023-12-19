namespace RoboToyTable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            foreach (var path in args)
            {
                Console.WriteLine("Processing commands from file : " + path);

                ProcessCommandsFromFile(path);

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void ProcessCommandsFromFile(string path)
        {
            var toyRobot = new RoboToy();
            var gameTable = new GameTable(toyRobot);

            IEnumerable<string> commandLines = File.ReadLines(path);
            foreach(var commandLine in commandLines)
            {
                Console.WriteLine("Processing command: " + commandLine);
                gameTable.ProcessCommand(commandLine);
            }  
        }
    }
}
