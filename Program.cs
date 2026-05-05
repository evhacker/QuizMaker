namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayMessage("Hello, this is a little Quiz Maker Program!");

        List<QuestionAnswer> questionAnswerList = LogicMethods.CreateQuestionAnswerList();
        
        // print to Terminal
        UIMethods.PrintQuestionAnswerList(questionAnswerList);
        
        // Serialize
        XmlHelpers.SaveXml(questionAnswerList);
    }
}