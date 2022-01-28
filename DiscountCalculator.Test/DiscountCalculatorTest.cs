using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace DiscountCalculator.Test
{
    [TestClass]
    public class DiscountCalculatorTest
    {
        [TestMethod]
        public void Test_DiscountCalc()
        {
            int expected = 9000;
            int actualPrice = 10000;
            int discountPercent = 10;

            int actual = DiscountCalculator.BusinessLogicLayer.DiscountCalculation(actualPrice, discountPercent);
            Assert.AreEqual(expected, actual);
        }
    }
}
