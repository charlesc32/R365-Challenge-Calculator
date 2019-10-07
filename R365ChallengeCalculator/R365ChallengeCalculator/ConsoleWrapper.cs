
using System;

namespace R365ChallengeCalculator
{
    class ConsoleWrapper: IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string stringToWrite)
        {
            Console.WriteLine(stringToWrite);
        }
    }
}
