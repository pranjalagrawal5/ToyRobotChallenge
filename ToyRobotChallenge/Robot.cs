namespace ToyRobotChallenge
{
    public class Robot
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Direction { get; set; }

        public Robot(int positionX, int positionY, string direction)
        {
            PositionX = positionX;
            PositionY = positionY;
            Direction = direction;
        }

        /// <summary>
        /// Move robot in current direction
        /// </summary>
        public void Move()
        {
            switch (Direction.ToUpper())
            {
                case "EAST":
                    PositionX += 1;
                    break;
                case "WEST":
                    PositionX -= 1;
                    break;
                case "NORTH":
                    PositionY += 1;
                    break;
                case "SOUTH":
                    PositionY -= 1;
                    break;
            }
        }

        /// <summary>
        /// Turn robot left based on current direction
        /// </summary>
        public void TurnLeft()
        {
            switch (Direction.ToUpper())
            {
                case "EAST":
                    Direction = "NORTH";
                    break;
                case "WEST":
                    Direction = "SOUTH";
                    break;
                case "NORTH":
                    Direction = "WEST";
                    break;
                case "SOUTH":
                    Direction = "EAST";
                    break;
            }
        }
        
        /// <summary>
        /// Turn robot right based on current direction
        /// </summary>
        public void TurnRight()
        {
            switch (Direction.ToUpper())
            {
                case "EAST":
                    Direction = "SOUTH";
                    break;
                case "WEST":
                    Direction = "NORTH";
                    break;
                case "NORTH":
                    Direction = "EAST";
                    break;
                case "SOUTH":
                    Direction = "WEST";
                    break;
            }
        }

        /// <summary>
        /// Get the current report of the Robot
        /// </summary>
        /// <returns>Current position and Direction of the robot</returns>
        public string GetReport()
        {
            return $"{PositionX},{PositionY},{Direction}";
        }
    }
}
