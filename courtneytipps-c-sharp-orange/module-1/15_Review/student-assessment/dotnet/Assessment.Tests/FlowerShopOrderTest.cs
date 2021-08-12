using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Models.Tests
{
    [TestClass]
    public class FlowerShopOrderTest
    {
        [TestMethod]
        public void DeliveryTotalWithSameDayAndOver30000()
        { //Arrange
            FlowerShopOrder exercise = new FlowerShopOrder("Standard", "5");

            //Act
           decimal result = exercise.DeliveryTotal(true, "35469");

            //Assert
            Assert.AreEqual(12.98M, result);
        }

        public void DeliveryWithinZipcode19999()
        { //Arrange
            FlowerShopOrder exercise = new FlowerShopOrder("Standard", "5");

            //Act
            decimal result = exercise.DeliveryTotal(true, "17653");

            //Assert
            Assert.AreEqual(0.00M, result);

        }

        [TestMethod]
        public void CalculateSubtotalWithADozenRoses()
        {
            FlowerShopOrder exercise = new FlowerShopOrder("Standard", "12");

            Assert.AreEqual(55.87M, exercise.Subtotal);
        }

        [TestMethod]
        public void CalculateSubtotalWithZeroRoses()
        {
            FlowerShopOrder exercise = new FlowerShopOrder("Standard", "0");

            Assert.AreEqual(19.99M, exercise.Subtotal);
        }




    }
}