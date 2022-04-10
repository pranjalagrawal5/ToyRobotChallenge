namespace ToyRobotChallengeTests
{
    using NUnit.Framework;
    using ToyRobotChallenge;

    public class TableTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void IsValidPosition_ReturnsTrue()
        {
            Table table = new Table(5, 5);

            Assert.IsTrue(table.IsValidPosition(2, 3));
        }

        [TestCase(-1, 3)]
        [TestCase(2, 6)]
        [TestCase(6, -2)]
        public void IsValidPosition_ReturnsFalse(int positionX, int positionY)
        {
            Table table = new Table(5, 5);

            Assert.IsFalse(table.IsValidPosition(positionX, positionY));
        }
    }
}
