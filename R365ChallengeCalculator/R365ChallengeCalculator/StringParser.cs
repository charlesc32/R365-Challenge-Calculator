namespace R365ChallengeCalculator
{
    public class StringParser: IStringParser
    {
        public string[] Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[] { };

            string[] parsedUserInput = input.Split(",");

            return parsedUserInput;
        }
    }
}
