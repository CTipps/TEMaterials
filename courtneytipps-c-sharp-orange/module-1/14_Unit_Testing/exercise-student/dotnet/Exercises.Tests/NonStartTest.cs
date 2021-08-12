using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        [TestMethod]
        public void GetPartialStringAvocado()
        {
            //Arrange
            NonStart exercise = new NonStart();

            //Act
            string result = exercise.GetPartialString("Mavo", "Scado");

            //Assert
            Assert.AreEqual("avocado", result);


        }
        [TestMethod]
        public void GetPartialStringFlip()
        {
            //Arrange
            NonStart exercise = new NonStart();

            //Act
            string result = exercise.GetPartialString("If", "Slip");

            //Assert
            Assert.AreEqual("flip", result);


        }
        [TestMethod]
        public void GetPartialStringPotater()
        {
            //Arrange
            NonStart exercise = new NonStart();

            //Act
            string result = exercise.GetPartialString("Spot", "Hater");

            //Assert
            Assert.AreEqual("potater", result);


        }
    }
}
