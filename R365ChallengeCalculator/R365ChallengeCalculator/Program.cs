using Microsoft.Extensions.DependencyInjection;
using System;

namespace R365ChallengeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsoleWrapper, ConsoleWrapper>()
                .AddSingleton<IConsoleManager, ConsoleManager>()
                .AddSingleton<IStringParser, StringParser>()
                .AddSingleton<ICalculator, Calculator>()
                .BuildServiceProvider();

            var consoleManager = serviceProvider.GetService<IConsoleManager>();
            var stringParser = serviceProvider.GetService<IStringParser>();
            var calculator = serviceProvider.GetService<ICalculator>();

            string alternateDelimeter = null;
            bool allowNegative = false;
            int upperBound = 1000;

            for (int i = 0; i < args.Length; i++)
            {
                // alternate delimeter
                if (args[i] == "-ad")
                {
                    alternateDelimeter = args[i + 1];
                }

                if (args[i] == "-allowNegative")
                {
                    allowNegative = true;
                }

                if (args[i] == "-ub")
                {
                    int.TryParse(args[i + 1], out upperBound);                    
                }
            }

            do
            {
                string input = consoleManager.ReadInput();

                string[] parsedInput = stringParser.Parse(input, alternateDelimeter);

                (int result, string formulaDisplay) = calculator.Calculate(parsedInput, allowNegative, upperBound);

                consoleManager.WriteOutput($"{formulaDisplay} = {result.ToString()}");
            } while (true);
        }
    }
}
