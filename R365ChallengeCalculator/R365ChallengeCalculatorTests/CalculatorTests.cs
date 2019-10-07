using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365ChallengeCalculator;
using System;

namespace R365ChallengeCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [DataTestMethod]
        [DataRow(new string[] { "1", "2" }, 3)]
        [DataRow(new string[] { "1", "xxx" }, 1)]
        [DataRow(new string[] { "20" }, 20)]
        [DataRow(new string[] { "1", "5000" }, 5001)]
        [DataRow(new string[] { "4", "-3" }, 1)]
        public void Calculate_ShouldSucceed(string[] input, int expectedSum)
        {
            var calculator = new Calculator();
            int result = calculator.Calculate(input);
            Assert.AreEqual(expectedSum, result);
        }

        [TestMethod]
        public void Calculate_ShouldThrowIfMoreThan2Inputs()
        {
            var calculator = new Calculator();
            Assert.ThrowsException<ArgumentException>(() => calculator.Calculate(new string[] { "1","2","3"}));         
        }
    }
}
