using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        [TestMethod]
        public void MakeAbbaReturnsSimpleString()
        {
            //Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.MakeAbba("Hi", "Bye");

            //Assert
            Assert.AreEqual("HiByeByeHi", result);
        }

        [TestMethod]
        public void MakeFirstTwoWithASimpleString()
        {
            //Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.FirstTwo("Hello");

            //Assert
            Assert.AreEqual("He", result);
        }
        [TestMethod]
        public void MakeFirstTwoWithAStringOfLengthOne()
        {
            //Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.FirstTwo("H");

            //Assert
            Assert.AreEqual("H", result);
        }
        [TestMethod]
        public void MakeFirstTwoWithAnEmptyString()
        {
            //Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.FirstTwo("");

            //Assert
            Assert.AreEqual("", result);
        }


        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()



    }
}