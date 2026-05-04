namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayMessage("Hello, this is a litte Quiz Maker Program!");
        
        var questionAnswerList = new List<QuestionAnswer>();

        while (true)
        {
            QuestionAnswer qa = new QuestionAnswer();
            qa.Question = UIMethods.GetUserInputString("Please enter a question");
            qa.AnswerOption1 = UIMethods.GetUserInputString("Please enter answer option 1");
            qa.AnswerOption2 = UIMethods.GetUserInputString("Please enter answer option 2");
            qa.AnswerOption3 = UIMethods.GetUserInputString("Please enter answer option 3");
            qa.CorrectAnswer = UIMethods.GetUserInputInt("Please enter number of correct answer option 1, 2 or 3");

            questionAnswerList.Add(qa);

            string askAnotherQuestion = UIMethods.GetUserInputString("Another question? (y/n)?");
            if (askAnotherQuestion.ToLower() != "y")
            {
                break;
            }
        }

        System.Xml.Serialization.XmlSerializer
            writer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAnswer>));
        var path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "questionanswers.xml"
        );

        using (FileStream file = File.Create(path))
        {
            writer.Serialize(file, questionAnswerList);
        }
    }
}