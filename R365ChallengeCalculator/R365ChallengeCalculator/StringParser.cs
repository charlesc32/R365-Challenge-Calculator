using System;
using System.Collections.Generic;

namespace R365ChallengeCalculator
{
    public class StringParser: IStringParser
    {
        private static readonly char CUSTOM_DELIMETER_START = '[';
        private static readonly char CUSTOM_DELIMETER_END = ']';

        public string[] Parse(string input, string alternateDelimeter = "\n")
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[] { };
            
            (List<string> customDelimeters, string strippedUserInput) = StripCustomDelimeter(input);
            strippedUserInput = NormalizeNewLines(strippedUserInput);

            customDelimeters.Add(",");
            customDelimeters.Add(alternateDelimeter);
            string[] parsedUserInput = strippedUserInput.Split(customDelimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            return parsedUserInput;
        }

        private string NormalizeNewLines(string input)
        {
            input = input.Replace("\r\n", "\n");
            input = input.Replace("\\n", "\n");
            return input;
        }

        private static (List<string> customDelimeters, string strippedUserInput) StripCustomDelimeter(string userInput)
        {
            var customDelimeters = new List<string>();
            string strippedUserInput = userInput;

            if (userInput.StartsWith("//") && userInput.Length > 2)
            {
                strippedUserInput = strippedUserInput.Substring(2);
                char customDelimeterStartingCharacter = strippedUserInput[0];
                if (customDelimeterStartingCharacter == CUSTOM_DELIMETER_START)
                {
                    var endingBracketIndex = userInput.LastIndexOf(CUSTOM_DELIMETER_END);
                    if (endingBracketIndex == -1)
                    {
                        throw new ArgumentException("Invalid custom delimeter. No ending bracket found.");
                    }

                    customDelimeters = ParseMultiCharacterDelimeters(strippedUserInput);
                    strippedUserInput = userInput.Substring(endingBracketIndex + 1);
                }
                else
                {
                    customDelimeters.Add(customDelimeterStartingCharacter.ToString());
                    strippedUserInput = strippedUserInput.Substring(1);
                }
            }

            return (customDelimeters, strippedUserInput);
        }

        private static List<string> ParseMultiCharacterDelimeters(string strippedUserInput)
        {
            var delimetersOnly = strippedUserInput.Substring(0, strippedUserInput.LastIndexOf(CUSTOM_DELIMETER_END));
            var delimeters = delimetersOnly.Split(CUSTOM_DELIMETER_END, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < delimeters.Length; i++)
            {
                delimeters[i] = delimeters[i].TrimStart(CUSTOM_DELIMETER_START);
            }

            return new List<string>(delimeters);
        }
    }
}
