using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTest
    {
        [TestMethod]
        public void GetHerdWithGiraffe()
        {
            //Arrange
            AnimalGroupName exercise = new AnimalGroupName();

            //Act
            string result = exercise.GetHerd("giraffe");

            //Assert
            Assert.AreEqual("Tower", result);
        }
        [TestMethod]
        public void GetHerdWithEmptyString()
        {
            //Arrange
            AnimalGroupName exercise = new AnimalGroupName();

            //Act
            string result = exercise.GetHerd("");

            //Assert
            Assert.AreEqual("unknown", result);
        }
        [TestMethod]
        public void GetHerdWithGiraffes()
        {
            //Arrange
            AnimalGroupName exercise = new AnimalGroupName();

            //Act
            string result = exercise.GetHerd("giraffes");

            //Assert
            Assert.AreEqual("unknown", result);
        }
    }
}