using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Test
    {
        [TestMethod]
        public void GetLuckyWith1()
        {
            //Arrange
            Lucky13 exercise = new Lucky13();
            int[] test = new int[3] { 1, 5, 7 };

            //Act
            bool result = exercise.GetLucky(test);

            //Assert
            Assert.AreEqual(false, result);

        }
        [TestMethod]
        public void GetLuckyWith3()
        {
            //Arrange
            Lucky13 exercise = new Lucky13();
            int[] test = new int[3] { 2, 5, 3 };

            //Act
            bool result = exercise.GetLucky(test);

            //Assert
            Assert.AreEqual(false, result) ;

        }
        [TestMethod]
        public void GetLuckyWithNeither()
        {
            //Arrange
            Lucky13 exercise = new Lucky13();
            int[] test = new int[3] { 6, 5, 7 };

            //Act
            bool result = exercise.GetLucky(test);

            //Assert
            Assert.AreEqual(true, result);

        }
    }
}
