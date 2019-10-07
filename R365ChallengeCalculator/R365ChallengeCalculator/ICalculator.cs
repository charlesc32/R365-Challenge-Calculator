namespace R365ChallengeCalculator
{
    interface ICalculator
    {
        (int result, string formulaDisplay) Calculate(string[] inputs);
    }
}
