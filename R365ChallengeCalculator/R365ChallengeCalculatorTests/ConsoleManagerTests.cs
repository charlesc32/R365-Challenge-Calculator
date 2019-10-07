using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365ChallengeCalculator;
using System;

namespace R365ChallengeCalculatorTests
{
    class FakeConsole : IConsoleWrapper
    {
        int lineReadCount = 0;
        public string ReadLine()
        {
            lineReadCount++;
            if (lineReadCount < 2) return "test string";

            // Console.ReadLine returns null when user enters "Ctrl-Z"
            return null;
        }

        public void WriteLine(string stringToWrite)
        {
            return;
        }
    }

    [TestClass]
    public class ConsoleManagerTests
    {
        [TestMethod]
        public void ReadInput_ShouldSucceed()
        {
            var consoleInputManager = new ConsoleManager(new FakeConsole());
            string result = consoleInputManager.ReadInput();
            Assert.AreEqual("test string,", result);
        }
    }
}
