namespace R365ChallengeCalculator
{
    interface IStringParser
    {
        string[] Parse(string input, string alternateDelimeter = "\n");
    }
}
