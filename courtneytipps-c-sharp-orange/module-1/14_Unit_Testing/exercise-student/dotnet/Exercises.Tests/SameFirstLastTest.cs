using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {
        [TestMethod]
        public void IsItTheSameLength1()
        {
            //Arrange
            SameFirstLast exercise = new SameFirstLast();
            int[] test = new int[] { 1 };

            //Act
            bool result = exercise.IsItTheSame(test);

            //Assert
            Assert.AreEqual(true, result);


        }
        [TestMethod]
        public void IsItTheSameWithEqual()
        {
            //Arrange
            SameFirstLast exercise = new SameFirstLast();
            int[] test = new int[] { 1, 2, 1 };

            //Act
            bool result = exercise.IsItTheSame(test);

            //Assert
            Assert.AreEqual(true, result);


        }
        [TestMethod]
        public void IsItTheSameNotEqual()
        {
            //Arrange
            SameFirstLast exercise = new SameFirstLast();
            int[] test = new int[] { 1, 2, 2 };

            //Act
            bool result = exercise.IsItTheSame(test);

            //Assert
            Assert.AreEqual(false, result);


        }
    }
}
