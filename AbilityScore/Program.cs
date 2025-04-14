namespace AbilityScore;

internal class AbilityScoreCalculator
{
    // existing fields
    public int RollResult = 14;
    public double DivideBy = 1.75;
    public int AddAmount = 2;
    public int Minimum = 3;
    public int Score;

    public void CalculateAbilityScore()
    {
        // divide roll result by divideby field
        double divided = RollResult / DivideBy;

        // add amount to the result and round down
        int added = AddAmount + (int)divided;

        // if the result is too small, use minimum value
        if (added < Minimum)
        {
            Score = Minimum;
        }
        else
        {
            Score = added;
        }
    }

    
    ///<summary>
    /// Reads an integer value from the console with a prompt and a default value.
    /// </summary>
    /// <param name="prompt">The message displayed to the user to indicate the expected input.</param>
    /// <param name="defaultValue">The default value to return if the user provides invalid input or no input.</param>
    /// <returns>
    /// The integer value entered by the user, or the <paramref name="defaultValue"/> if the input is invalid or empty.
    /// </returns>
    public int ReadInt(string prompt, int defaultValue)
    {
        Console.Write($"{prompt} [{defaultValue}]: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int result))
        {
            return result;
        }

        return defaultValue;
    }

    ///<summary>
    /// Reads a double value from the console with a prompt and a default value.
    /// </summary>
    /// <param name="prompt">The message displayed to the user to indicate the expected input.</param>
    /// <param name="defaultValue">The default value to return if the user provides invalid input or no input.</param>
    /// <returns>
    /// The double value entered by the user, or the <paramref name="defaultValue"/> if the input is invalid or empty.
    /// </returns>
    public double ReadDouble(string prompt, double defaultValue)
    {
        Console.Write($"{prompt} [{defaultValue}]: ");
        string? input = Console.ReadLine();
        if (double.TryParse(input, out double result))
        {
            return result;
        }
        return defaultValue;
    }

    // gets key to see if input needs to continue or stop
    char keyChar = Console.ReadKey(true).KeyChar;

}
internal class Program
{
    private static void Main(string[] args)
    {
        AbilityScoreCalculator calculator = new AbilityScoreCalculator();

        // Establish loop for calculating values
        while (true)
        {
            calculator.RollResult = calculator.ReadInt("Starting 4d6 roll", calculator.RollResult);
            calculator.DivideBy = calculator.ReadDouble("Divide by", calculator.DivideBy);
            calculator.AddAmount = calculator.ReadInt("Add amount", calculator.AddAmount);
            calculator.Minimum = calculator.ReadInt("Minimum", calculator.Minimum);
            calculator.CalculateAbilityScore();
            Console.WriteLine("Calculated ability score: " + calculator.Score);
            Console.WriteLine("Press Q to quit, any other key to continue");
            char keyChar = Console.ReadKey(true).KeyChar;
            if ((keyChar == 'Q') || (keyChar == 'q')) return;
        }
    }
}