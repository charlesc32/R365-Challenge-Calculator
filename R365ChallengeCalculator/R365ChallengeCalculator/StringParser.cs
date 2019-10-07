using System;

namespace R365ChallengeCalculator
{
    public class StringParser: IStringParser
    {
        public string[] Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[] { };

            input = NormalizeNewLines(input);
            string[] parsedUserInput = input.Split(new char[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);            

            return parsedUserInput;
        }

        private string NormalizeNewLines(string input)
        {
            return input.Replace("\r\n", "\n");
        }
    }
}
