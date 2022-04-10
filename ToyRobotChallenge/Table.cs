namespace ToyRobotChallenge
{
    public class Table
    {
        private int width;
        private int length;

        public Table(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        /// <summary>
        /// Checks if the position is valid on the table
        /// </summary>
        /// <param name="positionX">X coordinate of the position</param>
        /// <param name="positionY">Y coordinate of the position</param>
        /// <returns>True or False</returns>
        public bool IsValidPosition(int positionX, int positionY) 
        {
            return positionX >= 0 && positionX <= width && positionY >= 0 && positionY <= length;
        }
    }
}
