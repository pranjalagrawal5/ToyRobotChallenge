namespace ToyRobotChallengeTests
{
    using NUnit.Framework;
    using System;
    using ToyRobotChallenge;

    public class CommandHandlerTests
    {
        ICommandHandler _commandHandler;

        [SetUp]
        public void Setup()
        {
            _commandHandler = new CommandHandler(new Table(5, 5));
        }

        [Test]
        public void PlaceRobot_NullTableThrowsException()
        {
            ICommandHandler commandHandler = new CommandHandler(null);

            Assert.Throws<NullReferenceException>(() => commandHandler.PlaceRobot(0, 0, "NORTH"));
        }

        [Test]
        public void PlaceRobot_ValidPositionAndDirection_ReturnsTrue()
        {
            bool isRobotPlaced = _commandHandler.PlaceRobot(3, 2, "WEST");

            Assert.IsTrue(isRobotPlaced);
            
        }

        [Test]
        public void PlaceRobot_InvalidPosition_ReturnsFalse()
        {
            bool isRobotPlaced = _commandHandler.PlaceRobot(-3, 2, "WEST");

            Assert.IsFalse(isRobotPlaced);
        }

        [Test]
        public void PlaceRobot_NullDirection_ReturnsFalse()
        {
            bool isRobotPlaced = _commandHandler.PlaceRobot(-3, 2, null);

            Assert.IsFalse(isRobotPlaced);
        }

        [Test]
        public void PlaceRobot_InvalidDirection_ReturnsFalse()
        {
            bool isRobotPlaced = _commandHandler.PlaceRobot(-3, 2, "invalid");

            Assert.IsFalse(isRobotPlaced);
        }

        [TestCase(1,2,"EAST","2,2,EAST")]
        [TestCase(1, 2, "WEST", "0,2,WEST")]
        [TestCase(1, 2, "NORTH", "1,3,NORTH")]
        [TestCase(1, 2, "SOUTH", "1,1,SOUTH")]
        public void PlaceRobot_ValidMoveRobot_GetRobotReport_ReturnsExpectedReport(int positionX, int positionY, string direction, string expectedReport)
        {
            _commandHandler.PlaceRobot(positionX, positionY, direction);
            _commandHandler.MoveRobot();

            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual(expectedReport, report);
        }

        [TestCase(5, 2, "EAST", "5,2,EAST")]
        [TestCase(0, 2, "WEST", "0,2,WEST")]
        [TestCase(1, 5, "NORTH", "1,5,NORTH")]
        [TestCase(1, 0, "SOUTH", "1,0,SOUTH")]
        public void PlaceRobot_InValidMoveRobot_GetRobotReport_ReturnsExpectedReport(int positionX, int positionY, string direction, string expectedReport)
        {
            _commandHandler.PlaceRobot(positionX, positionY, direction);
            _commandHandler.MoveRobot();

            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void MoveRobotWithoutPlacing_GetRobotReport_ReturnsEmptyReport()
        {
            _commandHandler.MoveRobot();
            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual("", report);
        }

        [TestCase(5, 2, "EAST", "right", "5,2,SOUTH")]
        [TestCase(0, 2, "WEST", "left", "0,2,SOUTH")]
        [TestCase(1, 5, "NORTH", "left", "1,5,WEST")]
        [TestCase(1, 0, "SOUTH", "right", "1,0,WEST")]
        public void PlaceRobot_TurnRobotValidCommand_GetRobotReport_ReturnsExpectedReport(int positionX, int positionY, string direction, string command, string expectedReport)
        {
            _commandHandler.PlaceRobot(positionX, positionY, direction);
            _commandHandler.TurnRobot(command);

            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual(expectedReport, report);
        }

        [TestCase("")]
        [TestCase("invalid")]
        [TestCase(null)]
        public void PlaceRobot_TurnRobotInvalidCommand_GetRobotReport_ReturnsExpectedReport(string command)
        {
            _commandHandler.PlaceRobot(1, 1, "NORTH");
            _commandHandler.TurnRobot(command);

            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual("1,1,NORTH", report);
        }

        [Test]
        public void TurnRobotWithoutPlacing_GetRobotReport_ReturnsEmptyReport()
        {
            _commandHandler.TurnRobot("right");
            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual("", report);
        }

        [TestCase(2, 2, "EAST", "right", "3,2,SOUTH")]
        [TestCase(1, 2, "WEST", "left", "0,2,SOUTH")]
        [TestCase(1, 3, "NORTH", "left", "1,4,WEST")]
        [TestCase(1, 1, "SOUTH", "right", "1,0,WEST")]
        public void PlaceRobot_MoveRobot_TurnRobot_GetRobotReport_ReturnsExpectedReport(int positionX, int positionY, string direction, string command, string expectedReport)
        {
            _commandHandler.PlaceRobot(positionX, positionY, direction);
            _commandHandler.MoveRobot();
            _commandHandler.TurnRobot(command);

            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual(expectedReport, report);
        }

        [TestCase(2, 2, "EAST", "right", "2,1,SOUTH")]
        [TestCase(1, 2, "WEST", "left", "1,1,SOUTH")]
        [TestCase(1, 3, "NORTH", "left", "0,3,WEST")]
        [TestCase(1, 1, "SOUTH", "right", "0,1,WEST")]
        public void PlaceRobot_TurnRobot_MoveRobot_GetRobotReport_ReturnsExpectedReport(int positionX, int positionY, string direction, string command, string expectedReport)
        {
            _commandHandler.PlaceRobot(positionX, positionY, direction);
            _commandHandler.TurnRobot(command);
            _commandHandler.MoveRobot();

            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void GetRobotReportWithoutPlacing_ReturnEmptyReport()
        {
            var report = _commandHandler.GetRobotReport();

            Assert.AreEqual("", report);
        }
    }
}
