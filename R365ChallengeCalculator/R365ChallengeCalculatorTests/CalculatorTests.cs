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
        [DataRow(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" }, 78)]         
        public void Calculate_ShouldSucceed(string[] input, int expectedSum)
        {
            var calculator = new Calculator();
            (int result, string formulaDisplay) = calculator.Calculate(input);
            Console.WriteLine(formulaDisplay);
            Assert.AreEqual(expectedSum, result);
        }

        [TestMethod]
        public void Calculate_ShouldThrowWithNegativeNumbers()
        {
            var calculator = new Calculator();
            var exception = Assert.ThrowsException<InvalidOperationException>(() => calculator.Calculate(new string[] { "-1", "-2"}));
            Console.WriteLine(exception.Message);
        }

        [DataTestMethod]
        [DataRow(new string[] { "1", "2", "2000" }, 3)]
        [DataRow(new string[] { "1", "xxx", "2000" }, 1)]
        [DataRow(new string[] { "20", "2000" }, 20)]
        [DataRow(new string[] { "1", "5000", "2000" }, 1)]
        [DataRow(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "2000" }, 78)]
        public void Calculate_ShouldUse0ForGreaterThan1000(string[] input, int expectedSum)
        {
            var calculator = new Calculator();
            (int result, string formulaDisplay) = calculator.Calculate(input);
            Console.WriteLine(formulaDisplay);
            Assert.AreEqual(expectedSum, result);
        }
    }
}
