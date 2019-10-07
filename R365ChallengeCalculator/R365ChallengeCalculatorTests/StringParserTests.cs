

using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365ChallengeCalculator;
using System;

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

        [DataTestMethod]
        [DataRow(new string[] { "1", "2", "3" }, "1\n2,3")]
        [DataRow(new string[] { "1", "2" }, "1,2\n")]
        [DataRow(new string[] { "2", "1" }, "\n2\n1\n")]
        public void Parse_ShouldSucceedWithNewLine(string[] expected, string input)
        {
            var parser = new StringParser();
            var result = parser.Parse(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new string[] { "4", "3" }, "//#4#3")]
        [DataRow(new string[] { "44", "3", "3" }, "//^44,3^3")]
        [DataRow(new string[] { "4", "2", "3" }, "//-4-2-3")]
        [DataRow(new string[] { "2", "5" }, "//#\n2#5")]
        [DataRow(new string[] { "2", "ff", "100" }, "//,\n2,ff,100")]
        public void Parse_CustomDelimetersShouldSucceed(string[] expected, string input)
        {
            var parser = new StringParser();
            var result = parser.Parse(input);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
