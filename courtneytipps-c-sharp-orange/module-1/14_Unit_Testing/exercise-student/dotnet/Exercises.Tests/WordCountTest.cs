using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        [TestMethod]
        public void GetCountWithABBA()
        {
            //Arrange
            WordCount exercise = new WordCount();
            string[] test = new string[] { "A", "B", "B", "A" };
            Dictionary<string, int> compare = new Dictionary<string, int>()
            {
                { "A", 2 },
                { "B", 2 }
            };
            //Act
            Dictionary<string, int> result = exercise.GetCount(test);

            //Assert
            CollectionAssert.AreEquivalent(compare, result);


        }
        [TestMethod]
        public void GetCountWithOneAndThree()
        {
            //Arrange
            WordCount exercise = new WordCount();
            string[] test = new string[] { "One", "Three", "One", "Three", "Three", "Three" };
            Dictionary<string, int> compare = new Dictionary<string, int>()
            {
                { "One", 2 },
                { "Three", 4 }
            };
            //Act
            Dictionary<string, int> result = exercise.GetCount(test);

            //Assert
            CollectionAssert.AreEquivalent(compare, result);


        }
        [TestMethod]
        public void GetCountWithBaaBaaBlackSheep()
        {
            //Arrange
            WordCount exercise = new WordCount();
            string[] test = new string[] { "Baa", "Baa", "Black", "Sheep" };
            Dictionary<string, int> compare = new Dictionary<string, int>()
            {
                { "Baa", 2 },
                { "Black", 1 },
                {"Sheep", 1 }
            };
            //Act
            Dictionary<string, int> result = exercise.GetCount(test);

            //Assert
            CollectionAssert.AreEquivalent(compare, result);


        }
    }
}

