namespace ToyRobotChallengeTests
{
    using NUnit.Framework;
    using ToyRobotChallenge;

    public class RobotTests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("EAST", 1, 0)]
        [TestCase("NORTH", 0, 1)]
        [TestCase("WEST", -1, 0)]
        [TestCase("SOUTH", 0, -1)]
        public void Move_OneTime(string direction, int expectedPositionX, int expectedPositionY)
        {
            Robot robot = new Robot(0, 0, direction);

            robot.Move();

            Assert.AreEqual(robot.PositionX, expectedPositionX);
            Assert.AreEqual(robot.PositionY, expectedPositionY);
        }

        [TestCase("EAST", 2, 0)]
        [TestCase("NORTH", 0, 2)]
        [TestCase("WEST", -2, 0)]
        [TestCase("SOUTH", 0, -2)]
        public void Move_TwoTimes(string direction, int expectedPositionX, int expectedPositionY)
        {
            Robot robot = new Robot(0, 0, direction);

            robot.Move();
            robot.Move();

            Assert.AreEqual(robot.PositionX, expectedPositionX);
            Assert.AreEqual(robot.PositionY, expectedPositionY);
        }

        [TestCase("EAST", "NORTH")]
        [TestCase("NORTH", "WEST")]
        [TestCase("WEST", "SOUTH")]
        [TestCase("SOUTH", "EAST")]
        public void TurnLeft_OneTime(string currentDirection, string expectedDirection)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.TurnLeft();

            Assert.AreEqual(robot.Direction, expectedDirection);
            Assert.AreEqual(robot.Direction, expectedDirection);
        }

        [TestCase("EAST", "WEST")]
        [TestCase("NORTH", "SOUTH")]
        [TestCase("WEST", "EAST")]
        [TestCase("SOUTH", "NORTH")]
        public void TurnLeft_TwoTimes(string currentDirection, string expectedDirection)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.TurnLeft();
            robot.TurnLeft();

            Assert.AreEqual(robot.Direction, expectedDirection);
            Assert.AreEqual(robot.Direction, expectedDirection);
        }

        [TestCase("EAST", "SOUTH")]
        [TestCase("NORTH", "EAST")]
        [TestCase("WEST", "NORTH")]
        [TestCase("SOUTH", "WEST")]
        public void TurnRight_OneTime(string currentDirection, string expectedDirection)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.TurnRight();

            Assert.AreEqual(robot.Direction, expectedDirection);
            Assert.AreEqual(robot.Direction, expectedDirection);
        }

        [TestCase("EAST", "WEST")]
        [TestCase("NORTH", "SOUTH")]
        [TestCase("WEST", "EAST")]
        [TestCase("SOUTH", "NORTH")]
        public void TurnRight_TwoTimes(string currentDirection, string expectedDirection)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.TurnRight();
            robot.TurnRight();

            Assert.AreEqual(robot.Direction, expectedDirection);
            Assert.AreEqual(robot.Direction, expectedDirection);
        }

        [TestCase("EAST", "NORTH", 1, 1)]
        [TestCase("NORTH", "WEST", -1, 1)]
        [TestCase("WEST", "SOUTH", -1, -1)]
        [TestCase("SOUTH", "EAST", 1, -1)]
        public void Move_TurnLeft_Move(string currentDirection, string expectedDirection, int expectedPositionX, int expectedPositionY)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.Move();
            robot.TurnLeft();
            robot.Move();

            Assert.AreEqual(robot.PositionX, expectedPositionX);
            Assert.AreEqual(robot.PositionY, expectedPositionY);
            Assert.AreEqual(robot.Direction, expectedDirection);
        }

        [TestCase("EAST", "SOUTH", 1, -1)]
        [TestCase("NORTH", "EAST", 1, 1)]
        [TestCase("WEST", "NORTH", -1, 1)]
        [TestCase("SOUTH", "WEST", -1, -1)]
        public void Move_TurnRight_Move(string currentDirection, string expectedDirection, int expectedPositionX, int expectedPositionY)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.Move();
            robot.TurnRight();
            robot.Move();

            Assert.AreEqual(robot.PositionX, expectedPositionX);
            Assert.AreEqual(robot.PositionY, expectedPositionY);
            Assert.AreEqual(robot.Direction, expectedDirection);
        }

        [TestCase("EAST", "1,1,EAST")]
        [TestCase("NORTH", "-1,1,NORTH")]
        [TestCase("WEST", "-1,-1,WEST")]
        [TestCase("SOUTH", "1,-1,SOUTH")]
        public void GetReportTest_MoveAndTurnOneTimeEach(string currentDirection, string expectedReport)
        {
            Robot robot = new Robot(0, 0, currentDirection);

            robot.Move();
            robot.TurnLeft();
            robot.Move();
            robot.TurnRight();

            var report = robot.GetReport();

            Assert.AreEqual(expectedReport, report);
        }
    }
}