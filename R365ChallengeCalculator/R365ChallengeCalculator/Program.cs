﻿using Microsoft.Extensions.DependencyInjection;
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

            string input = consoleManager.ReadInput();

            string[] parsedInput = stringParser.Parse(input);
                        
            int result = calculator.Calculate(parsedInput);

            consoleManager.WriteOutput(result.ToString());
        }
    }
}