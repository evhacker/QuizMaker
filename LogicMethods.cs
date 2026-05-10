namespace QuizMaker;

public class LogicMethods
{
    //Declare random
    private static readonly Random rng = new Random();
    
    /// <summary>
    /// Generates random number for sorting
    /// </summary>
    /// <param name="question">Question for which random number is generated</param>
    /// <returns>Random number</returns>
    public static int GenerateRandomNumberForSorting(QuestionAnswer question)
    {
        return rng.Next();
    }

    /// <summary>
    /// Get Score
    /// </summary>
    /// <param name="counter">correct user Answers</param>
    /// <param name="questionAnswerList">List with questions and answers</param>
    /// <returns>user score</returns>
    public static double GetScore(int counter, List<QuestionAnswer> questionAnswerList)
    {
        double score = 0;
        score = counter * 100.0 / questionAnswerList.Count;
        return score;
    }
}