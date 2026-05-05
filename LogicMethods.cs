namespace QuizMaker;

public class LogicMethods
{
    /// <summary>
    /// Creates List with Questions/Answers from user input
    /// </summary>
    /// <returns>List of Questions and Answers</returns>
    public static List<QuestionAnswer> CreateQuestionAnswerList()
    {
        var questionAnswerList = new List<QuestionAnswer>();

        while (true)
        {
            QuestionAnswer qa = new QuestionAnswer();
            qa.Question = UIMethods.GetUserInputString("Please enter a question and press Enter");

            qa.AnswerOptions = new List<string>();

            for (int i = 0; i < Constants.NUMBER_ANSWER_OPTIONS; i++)
            {
                string userInput = UIMethods.GetUserInputString($"Please enter answer option and press Enter {i + 1}");
                qa.AnswerOptions.Add(userInput);
            }

            qa.CorrectAnswer = UIMethods.GetUserInputInt("Please enter the number of the correct answer option and press Enter");

            questionAnswerList.Add(qa);

            string askAnotherQuestion = UIMethods.GetUserInputString("Another question? (y/n)?");
            if (askAnotherQuestion.ToLower() != "y")
            {
                break;
            }
        }
        return questionAnswerList;
    }
}