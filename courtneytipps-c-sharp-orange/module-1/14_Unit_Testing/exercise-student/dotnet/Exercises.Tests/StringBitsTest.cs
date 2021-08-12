using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTest
    {
        [TestMethod]
        public void GetBitsWithAbracadabra()
        {
            //Arrange
            StringBits exercise = new StringBits();

            //Act
            string result = exercise.GetBits("Abracadabra");

            //Assert
            Assert.AreEqual("Arcdba", result);
        }
        [TestMethod]
        public void GetBitsWithGarbonzo()
        {
            //Arrange
            StringBits exercise = new StringBits();

            //Act
            string result = exercise.GetBits("Garbonzo");

            //Assert
            Assert.AreEqual("Groz", result);
        }
        [TestMethod]
        public void GetBitsWithPink()
        {
            //Arrange
            StringBits exercise = new StringBits();

            //Act
            string result = exercise.GetBits("Pink");

            //Assert
            Assert.AreEqual("Pn", result);
        }

    }
}

