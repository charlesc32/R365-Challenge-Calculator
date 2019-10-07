namespace R365ChallengeCalculator
{
    interface ICalculator
    {
        (int result, string formulaDisplay) Calculate(string[] inputs, bool allowNegative = false, int upperBound = 1000);
    }
}
