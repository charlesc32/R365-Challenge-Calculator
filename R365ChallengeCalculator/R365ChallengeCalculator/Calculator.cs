using System;

namespace R365ChallengeCalculator
{
    public class Calculator: ICalculator
    {
        public int Calculate(string[] inputs)
        {
            if (inputs.Length > 2) throw new ArgumentException("More than 2 inputs to calculation not supported.");

            int sum = 0;

            foreach (string inputItem in inputs)
            {
                if (!int.TryParse(inputItem, out int input))
                {
                    input = 0;
                }

                sum += input;
            }

            return sum;
        }
    }
}
