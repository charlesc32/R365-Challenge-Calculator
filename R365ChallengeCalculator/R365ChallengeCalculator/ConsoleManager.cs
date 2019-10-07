namespace R365ChallengeCalculator
{
    public class ConsoleManager: IConsoleManager
    {
        IConsoleWrapper _console;
        public ConsoleManager(IConsoleWrapper console)
        {
            _console = console;
        }

        public string ReadInput()
        {
            _console.WriteLine("Please enter the comma seperated string to calculate:");
            return _console.ReadLine();
        }

        public void WriteOutput(string output)
        {
            _console.WriteLine($"Calculation result is: {output}");
        }
    }
}
