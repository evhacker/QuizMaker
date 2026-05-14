namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayMessage("Hello, this is a little Quiz Maker Program!");

        // initialize question answer list
        var questionAnswerList = new List<QuestionAnswer>();

        //Let user choose mode
        int numberModeUser =
            UIMethods.GetUserInputInt(
                "Please choose a mode (enter number of the mode and press enter):\n1 Create Quiz\n2 Play Quiz");

        if (Enum.IsDefined(typeof(Constants.PlayMode), numberModeUser))
        {
            Constants.PlayMode mode = (Constants.PlayMode)numberModeUser;

            switch (mode)
            {
                case Constants.PlayMode.CreateQuiz:

                    while (true)
                    {
                        QuestionAnswer qa = new QuestionAnswer();
                        qa.Question = UIMethods.GetUserInputString("Please enter a question and press Enter");

                        qa.AnswerOptions = new List<string>();

                        for (int i = 0; i < Constants.NUMBER_ANSWER_OPTIONS; i++)
                        {
                            string userInput =
                                UIMethods.GetUserInputString($"Please enter answer option and press Enter {i + 1}");
                            qa.AnswerOptions.Add(userInput);
                        }

                        qa.CorrectAnswer =
                            UIMethods.GetUserInputInt(
                                "Please enter the number of the correct answer option and press Enter");

                        questionAnswerList.Add(qa);

                        string askAnotherQuestion = UIMethods.GetUserInputString("Another question? (y/n)?");
                        if (askAnotherQuestion.ToLower() != "y")
                        {
                            break;
                        }
                    }

                    // print to Terminal
                    UIMethods.PrintQuestionAnswerList(questionAnswerList);

                    // Serialize
                    XmlHelpers.SaveXml(questionAnswerList);
                    break;

                case Constants.PlayMode.PlayQuiz:
                    // Load Questions
                    if (!File.Exists(Constants.FILENAME))
                    {
                        UIMethods.DisplayMessage("File does not exist - create quiz first!");
                        return;
                    }
                    questionAnswerList = XmlHelpers.LoadXml();

                    // Sort question/answer list randomly
                    questionAnswerList =
                        questionAnswerList.OrderBy(LogicMethods.GenerateRandomNumberForSorting).ToList();

                    int counter = 0;
                    int userAnswer = 0;

                    // Print Question to user, get user answer and evaluate it
                    foreach (QuestionAnswer qa in questionAnswerList)
                    {
                        userAnswer = UIMethods.GetUserInputInt(qa.PrintQuestion());

                        if (userAnswer == qa.CorrectAnswer)
                        {
                            counter++;
                        }
                    }

                    // get score
                    double score = 0;
                    score = LogicMethods.GetScore(counter, questionAnswerList);


                    // Display score to user
                    UIMethods.DisplayMessage($"Quiz finished! Your Score: {score:F1}%");

                    break;
            }
        }
    }
}