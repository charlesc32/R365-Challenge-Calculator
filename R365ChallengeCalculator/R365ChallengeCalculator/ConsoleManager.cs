﻿using System.Text;

namespace R365ChallengeCalculator
{
    public class ConsoleManager: IConsoleManager
    {
        IConsoleWrapper _console;
        public ConsoleManager(IConsoleWrapper console)
        {
            _console = console;
        }

        public string ReadInput()
        {
            _console.WriteLine("Enter a comma and/or newline delimited string to calculate -- Enter ctrl-z on a new line when done inputing:");
            string line = string.Empty;
            var sb = new StringBuilder();

            do
            {
                line = _console.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    sb.Append(",");
                    sb.Append(line);
                }

            } while (line != null);

            return sb.ToString();
        }

        public void WriteOutput(string output)
        {
            _console.WriteLine($"Calculation result is: {output}");
        }
    }
}
