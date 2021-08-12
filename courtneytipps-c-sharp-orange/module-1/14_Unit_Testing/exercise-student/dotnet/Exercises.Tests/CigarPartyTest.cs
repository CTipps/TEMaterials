using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {
        [TestMethod]
        public void HavePartyWithMinimumCigarsWeekday()
        {
            //Arrange
            CigarParty exercise = new CigarParty();

            //Act
            bool result = exercise.HaveParty(40, false);

            //Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void HavePartyWithAboveMaxCigarsWeekday()
        {
            //Arrange
            CigarParty exercise = new CigarParty();

            //Act
            bool result = exercise.HaveParty(70, false);

            //Assert
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void HavePartyWithAboveMaxCigarsWeekend()
        {
            //Arrange
            CigarParty exercise = new CigarParty();

            //Act
            bool result = exercise.HaveParty(100, true);

            //Assert
            Assert.AreEqual(true, result);
        }
    }
    }
