using System;

namespace R365ChallengeCalculator
{
    public class Calculator: ICalculator
    {
        public int Calculate(string[] inputs)
        {
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
