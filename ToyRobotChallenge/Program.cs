namespace ToyRobotChallenge
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            if(args == null || args.Length == 0)
            {
                Console.WriteLine("Please specify the commands file path");
                return;
            }

            if(!File.Exists(args[0]) || Path.GetExtension(args[0])!= ".txt")
            {
                Console.WriteLine("File does not exist or it's incorrect format");
                return;
            }

            try
            {
                List<string> commands = File.ReadAllLines(args[0]).ToList();

                ICommandManager commandManager = new CommandManager();
                var message = commandManager.StartRobot(commands);

                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message);
                }
                else
                    Console.WriteLine("Robot could not be placed on table because of invalid or no PLACE command");
            }
            catch
            {
                Console.WriteLine("File is incorrect format");
            }
        }
    }
}
