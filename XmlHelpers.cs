namespace QuizMaker;

using System.Xml.Serialization;

public static class XmlHelpers
{
    /// <summary>
    /// Saves List of Questions and Answers to Xml File
    /// </summary>
    /// <param name="questionAnswerList">List to save</param>
    public static void SaveXml(List<QuestionAnswer> questionAnswerList)
    {
        var writer = new XmlSerializer(typeof(List<QuestionAnswer>));

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