using System;

namespace R365ChallengeCalculator
{
    public class StringParser: IStringParser
    {
        public string[] Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[] { };
            
            (char customDelimeter, string strippedUserInput) = StripCustomDelimeter(input);
            strippedUserInput = NormalizeNewLines(strippedUserInput);
            string[] parsedUserInput = strippedUserInput.Split(new char[] { ',', '\n', customDelimeter }, StringSplitOptions.RemoveEmptyEntries);

            return parsedUserInput;
        }

        private string NormalizeNewLines(string input)
        {
            return input.Replace("\r\n", "\n");
        }

        private static (char customDelimeter, string strippedUserInput) StripCustomDelimeter(string userInput)
        {
            char customDelimeter = Char.MinValue;
            string strippedUserInput = userInput;

            if (userInput.StartsWith("//") && userInput.Length > 2)
            {
                customDelimeter = userInput[2];
                strippedUserInput = userInput.TrimStart(new char[] { '/', customDelimeter });
            }

            return (customDelimeter, strippedUserInput);
        }
    }
}
