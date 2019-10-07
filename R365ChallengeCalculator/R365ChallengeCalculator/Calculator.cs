﻿using System;
using System.Collections.Generic;

namespace R365ChallengeCalculator
{
    public class Calculator : ICalculator
    {
        private static readonly int UPPERBOUND = 1000;
        private static readonly int LOWERBOUND = 0;

        public int Calculate(string[] inputs)
        {
            int sum = 0;
            var deniedNegativeNumbers = new List<int>();

            foreach (string inputItem in inputs)
            {
                if (!int.TryParse(inputItem, out int input))
                {
                    input = 0;
                }

                if (input < LOWERBOUND)
                {
                    deniedNegativeNumbers.Add(input);
                    continue;
                }

                if (input > UPPERBOUND)
                {
                    input = 0;
                }

                sum += input;
            }

            if (deniedNegativeNumbers.Count > 0)
            {
                throw new InvalidOperationException($"Negative numbers are not allowed. Negative numbers detected: {string.Join(',', deniedNegativeNumbers)}");
            }

            return sum;
        }
    }
}
