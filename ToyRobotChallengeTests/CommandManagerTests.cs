namespace ToyRobotChallengeTests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using ToyRobotChallenge;

    public class CommandManagerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void StartRobot_ValidCommandList_ReturnsReportAsMessage()
        {
            List<string> commands = new List<string>()
            {
                "PLACE 1,2,EAST",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT"
            };

            ICommandManager commandManager = new CommandManager();

            var message = commandManager.StartRobot(commands);

            Assert.AreEqual("3,3,NORTH", message);
        }

        [Test]
        public void StartRobot_InvalidCommandList__NoPlaceCommand_ReturnsEmptyMessage()
        {
            List<string> commands = new List<string>()
            {
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT"
            };

            ICommandManager commandManager = new CommandManager();

            var message = commandManager.StartRobot(commands);

            Assert.AreEqual("", message);
        }

        [TestCase("PLACE 0,NORTH")]
        [TestCase("PLACE 0,0,INVALID")]
        [TestCase("PLACE 6,0,EAST")]
        public void StartRobot_InvalidCommandList_InvalidPlaceCommand_ReturnsEmptyMessage(string placeCommand)
        {
            List<string> commands = new List<string>()
            {
                placeCommand,
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT"
            };

            ICommandManager commandManager = new CommandManager();

            var message = commandManager.StartRobot(commands);

            Assert.AreEqual("", message);
        }

        [Test]
        public void StartRobot_InvalidCommandsInList_ValidPlaceCommand_ReturnsReportAsMessage()
        {
            List<string> commands = new List<string>()
            {
                "PLACE 2,1,NORTH",
                "MVE",
                "MOVE",
                "RGHT",
                "LEFT",
                "MOVE",
                "REPORT"
            };

            ICommandManager commandManager = new CommandManager();

            var message = commandManager.StartRobot(commands);

            Assert.AreEqual("1,2,WEST", message);
        }

        [Test]
        public void StartRobot_IgnoresInvalidSecondPlaceCommandInList_ValidFirstPlaceCommand_ReturnsReportAsMessage()
        {
            List<string> commands = new List<string>()
            {
                "PLACE 2,1,NORTH",
                "MOVE",
                "LEFT",
                "PLACE 6,0,RIGHT",
                "MOVE",
                "REPORT"
            };

            ICommandManager commandManager = new CommandManager();

            var message = commandManager.StartRobot(commands);

            Assert.AreEqual("1,2,WEST", message);
        }
    }
}
