namespace QuizMaker;

public class QuestionAnswer
{
    public string Question;
    public string AnswerOption1;
    public string AnswerOption2;
    public string AnswerOption3;
    public int CorrectAnswer;

    public override string ToString()
    {
        return
            $"{Question} \n AnswerOption1: {AnswerOption1} \n AnswerOption2: {AnswerOption2} \n AnswerOption3: " +
            $"{AnswerOption3} \n Correct Answer: {CorrectAnswer}";
    }
}