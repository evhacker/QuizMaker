namespace QuizMaker;

public class QuestionAnswer
{
    public string Question;
    public List<string> AnswerOptions;
    public int CorrectAnswer;

    public override string ToString()
    {
        string text = PrintQuestion();
        text += $"Correct Answer: {CorrectAnswer}";
        return text;
    }

    public string PrintQuestion()
    {
        string text = Question + "\n";

        for (int i = 0; i < AnswerOptions.Count; i++)
        {
            text += $"{i + 1}: {AnswerOptions[i]}\n";
        }

        return text;
    }
}