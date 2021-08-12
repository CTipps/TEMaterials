using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Test
    {
        [TestMethod]
        public void MakeArrayOfAll12()
        {
            //Arrange
            MaxEnd3 exercise = new MaxEnd3();
            int[] test = new int[] {12, 25, 11 };

            //Act
            int[] result = exercise.MakeArray(test);

            //Assert
            int[] compare = new int[] { 12, 12, 12 };
            CollectionAssert.AreEqual(compare,result);

        }
        [TestMethod]
        public void MakeArrayOfAll2()
        {
            //Arrange
            MaxEnd3 exercise = new MaxEnd3();
            int[] test = new int[] {1,7,2 };

            //Act
            int[] result = exercise.MakeArray(test);

            //Assert
            int[] compare = new int[] { 2, 2, 2 };
            CollectionAssert.AreEqual(compare,result);

        }
        [TestMethod]
        public void MakeArrayOfAll3()
        {
            //Arrange
            MaxEnd3 exercise = new MaxEnd3();
            int[] test = new int[] {3, 2, 2 };

            //Act
            int[] result = exercise.MakeArray(test);

            //Assert
            int[] compare = new int[] { 3, 3, 3 };
            CollectionAssert.AreEqual(compare,result);

        }
    }
}
