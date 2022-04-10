namespace ToyRobotChallenge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// CommandHandler class - Validates commands and sends them to Robot
    /// </summary>
    public class CommandHandler : ICommandHandler
    {
        private Table _table;
        private Robot _robot;

        private readonly List<string> validDirections = new List<string>() { "EAST", "WEST", "NORTH", "SOUTH" };

        public CommandHandler(Table table)
        {
            _table = table;
        }

        /// <summary>
        /// Place Robot on the table
        /// </summary>
        /// <param name="positionX">Initial X coordinate of Robot</param>
        /// <param name="positionY">Initial Y coordinate of Robot</param>
        /// <param name="direction">Initial direction of Robot</param>
        /// <returns></returns>
        public bool PlaceRobot(int positionX, int positionY, string direction)
        {
            if (_table == null)
            {
                throw new NullReferenceException("Table not setup");
            }

            if (_table.IsValidPosition(positionX, positionY))
            {
                if (!string.IsNullOrEmpty(direction) && validDirections.Any(x => x == direction.ToUpper()))
                {
                    _robot = new Robot(positionX, positionY, direction);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Move the robot by 1 point if it's a valid move
        /// </summary>
        public void MoveRobot()
        {
            if (_robot != null)
            {
                switch (_robot.Direction.ToUpper())
                {
                    case "EAST":
                        if (_table.IsValidPosition(_robot.PositionX + 1, _robot.PositionY))
                            _robot.Move();
                        break;
                    case "WEST":
                        if (_table.IsValidPosition(_robot.PositionX - 1, _robot.PositionY))
                            _robot.Move();
                        break;
                    case "NORTH":
                        if (_table.IsValidPosition(_robot.PositionX, _robot.PositionY + 1))
                            _robot.Move();
                        break;
                    case "SOUTH":
                        if (_table.IsValidPosition(_robot.PositionX, _robot.PositionY - 1))
                            _robot.Move();
                        break;
                }
            }
        }

        /// <summary>
        /// Turn the robot right or left based on command
        /// </summary>
        /// <param name="command">RIGHT or LEFT</param>
        public void TurnRobot(string command)
        {
            if (!string.IsNullOrEmpty(command) && _robot != null)
            {
                switch (command.ToUpper())
                {
                    case "RIGHT":
                        _robot.TurnRight();
                        break;
                    case "LEFT":
                        _robot.TurnLeft();
                        break;
                }
            }
        }

        /// <summary>
        /// Get the current report of the report
        /// </summary>
        /// <returns>Current Position and direction of Robot</returns>
        public string GetRobotReport()
        {
            if (_robot != null)
                return _robot.GetReport();

            return "";
        }
    }
}
