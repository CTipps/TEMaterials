using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [TestMethod]
    public void GenerateStringWith5Repeats()
        {
            //Arrange
            FrontTimes exercise = new FrontTimes();
            //Act
            string result = exercise.GenerateString("Chocolate", 5);
            //Assert
            Assert.AreEqual("ChoChoChoChoCho", result);
        }
        [TestMethod]
        public void GenerateStringWithStringLength2()
        {
            //Arrange
            FrontTimes exercise = new FrontTimes();
            //Act
            string result = exercise.GenerateString("So", 5);
            //Assert
            Assert.AreEqual("SoSoSoSoSo", result);
        }
        [TestMethod]
        public void GenerateStringWith1Repeat()
        {
            //Arrange
            FrontTimes exercise = new FrontTimes();
            //Act
            string result = exercise.GenerateString("Chocolate", 1);
            //Assert
            Assert.AreEqual("Cho", result);
        }
    }
}
