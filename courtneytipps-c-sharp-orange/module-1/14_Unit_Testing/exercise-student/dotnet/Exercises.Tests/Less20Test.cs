using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Test
    {
        [TestMethod]
        public void IsLessThanMultipleOfTwentyWithThirty()
        {
            //Arrange
            Less20 exercise = new Less20();

            //Act
            bool result = exercise.IsLessThanMultipleOf20(30);

            //Assert
            Assert.AreEqual(false, result);

        }
        [TestMethod]
        public void IsLessThanMultipleOfTwentyWith19()
        {
            //Arrange
            Less20 exercise = new Less20();

            //Act
            bool result = exercise.IsLessThanMultipleOf20(19);

            //Assert
            Assert.AreEqual(true, result);

        }
        [TestMethod]
        public void IsLessThanMultipleOfTwentyWith38()
        {
            //Arrange
            Less20 exercise = new Less20();

            //Act
            bool result = exercise.IsLessThanMultipleOf20(38);

            //Assert
            Assert.AreEqual(true, result);

        }
    }
}
