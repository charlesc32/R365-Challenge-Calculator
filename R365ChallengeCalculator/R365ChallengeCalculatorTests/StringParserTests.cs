

using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365ChallengeCalculator;

namespace R365ChallengeCalculatorTests
{
    [TestClass]
    public class StringParserTests
    {
        [TestMethod]
        public void Parse_ShouldSucceed()
        {
            var parser = new StringParser();
            var result = parser.Parse("1,2");
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("2", result[1]);
        }

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow("", 0)]
        public void Parse_ShouldReturnEmptyArrayForNullInput(string input, int expectedCount)
        {
            var parser = new StringParser();
            var result = parser.Parse(input);
            Assert.AreEqual(expectedCount, result.Length);            
        }
    }
}
