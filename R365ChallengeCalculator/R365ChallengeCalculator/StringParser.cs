using System;

namespace R365ChallengeCalculator
{
    public class StringParser: IStringParser
    {
        public string[] Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[] { };
            
            (string customDelimeter, string strippedUserInput) = StripCustomDelimeter(input);
            strippedUserInput = NormalizeNewLines(strippedUserInput);
            string[] parsedUserInput = strippedUserInput.Split(new string[] { ",", "\n", "\\n", customDelimeter }, StringSplitOptions.RemoveEmptyEntries);

            return parsedUserInput;
        }

        private string NormalizeNewLines(string input)
        {
            return input.Replace("\r\n", "\n");
        }

        private static (string customDelimeter, string strippedUserInput) StripCustomDelimeter(string userInput)
        {
            string customDelimeter = string.Empty;
            string strippedUserInput = userInput;

            if (userInput.StartsWith("//") && userInput.Length > 2)
            {
                char customDelimeterStartingCharacter = userInput[2];
                if (customDelimeterStartingCharacter == '[')
                {
                    var endingBracketIndex = userInput.LastIndexOf(']');
                    if (endingBracketIndex == -1)
                    {
                        throw new ArgumentException("Invalid custom delimeter. No ending bracket found.");
                    }
                    customDelimeter = userInput.Substring(3, endingBracketIndex - 3);
                    strippedUserInput = userInput.Substring(endingBracketIndex + 1);
                }
                else
                {
                    customDelimeter = userInput[2].ToString();
                    strippedUserInput = userInput.Substring(3);
                }
            }

            return (customDelimeter, strippedUserInput);
        }
    }
}
