namespace ToyRobotChallenge
{
    public interface ICommandHandler
    {
        bool PlaceRobot(int positionX, int positionY, string direction);
        void MoveRobot();
        void TurnRobot(string command);
        string GetRobotReport();
    }
}
