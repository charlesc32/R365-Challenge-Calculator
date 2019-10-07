using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365ChallengeCalculator;

namespace R365ChallengeCalculatorTests
{
    class FakeConsole : IConsoleWrapper
    {
        public string ReadLine()
        {
            return "test string";
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
            Assert.AreEqual("test string", result);
        }
    }
}
