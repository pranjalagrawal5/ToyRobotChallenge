namespace ToyRobotChallenge
{
    using System.Collections.Generic;

    public interface ICommandManager
    {
        string StartRobot(List<string> commands);
    }
}
