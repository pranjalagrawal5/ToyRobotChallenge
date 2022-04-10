namespace ToyRobotChallenge
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// CommandManager class - Sends commands to handler to execute them
    /// </summary>
    public class CommandManager : ICommandManager
    {
        private ICommandHandler _commandHandler;
        private Table _table = new Table(5, 5);

        private bool isRobotPlaced = false;
        private string returnMessage = string.Empty;

        /// <summary>
        /// Process the valid commands for the Robot
        /// </summary>
        /// <param name="commands">List of Commands</param>
        /// <returns></returns>
        public string StartRobot(List<string> commands)
        {
            _commandHandler = new CommandHandler(_table);

            foreach (var command in commands)
            {
                ProcessCommand(command);
            }

            return returnMessage;

        }

        private void ProcessCommand(string command)
        {
            string[] commandOptions = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (commandOptions == null || string.IsNullOrEmpty(commandOptions[0]))
                return;

            switch (commandOptions[0].ToUpper())
            {
                case "PLACE":
                    if (commandOptions.Length == 4)
                    {
                        int positionX;
                        int positionY;

                        bool isPositionX = Int32.TryParse(commandOptions[1], out positionX);
                        bool isPositionY = Int32.TryParse(commandOptions[2], out positionY);

                        string direction = commandOptions[3];

                        if (isPositionX && isPositionY)
                        {
                            bool result = _commandHandler.PlaceRobot(positionX, positionY, direction);
                            if (!isRobotPlaced)
                                isRobotPlaced = result;
                        }
                    }

                    break;

                case "MOVE":
                    if (isRobotPlaced)
                        _commandHandler.MoveRobot();

                    break;

                case "LEFT":
                case "RIGHT":
                    if (isRobotPlaced)
                        _commandHandler.TurnRobot(commandOptions[0].ToUpper());

                    break;

                case "REPORT":
                    if (isRobotPlaced)
                        returnMessage = _commandHandler.GetRobotReport();

                    break;
            }
        }

    }
}
