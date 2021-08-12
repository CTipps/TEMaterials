using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        [TestMethod]
        public void GetATableWithAn8()
        {
            //Arrange
            DateFashion exercise = new DateFashion();

            //Act
            int result = exercise.GetATable(3, 8);
            //Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void GetATableWithBoth5()
        {
            //Arrange
            DateFashion exercise = new DateFashion();

            //Act
            int result = exercise.GetATable(5, 5);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GetATableWithA2()
        {
            //Arrange
            DateFashion exercise = new DateFashion();

            //Act
            int result = exercise.GetATable(2, 8);
            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
