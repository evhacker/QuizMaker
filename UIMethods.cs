namespace QuizMaker;

public static class UIMethods
{
    /// <summary>
    /// Prints message to console
    /// </summary>
    /// <param name="message">Message to print</param>
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Get string from user
    /// </summary>
    /// <param name="question">Question to be printed to console</param>
    /// <returns>String from user</returns>
    public static string GetUserInputString(string question)
    {
        Console.WriteLine(question);
        string userInput = Console.ReadLine();
        return userInput;
    }

    /// <summary>
    /// Get int from user
    /// </summary>
    /// <param name="question"></param>
    /// <returns>Int from user</returns>
    public static int GetUserInputInt(string question)
    {
        Console.WriteLine(question);

        int userInput = 0;

        while (true)
        {
            bool success = int.TryParse(Console.ReadLine(), out userInput);
            if (success)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("This is not a number...");
            }
        }
    }
}