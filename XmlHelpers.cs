namespace QuizMaker;

using System.Xml.Serialization;

public static class XmlHelpers
{
    /// <summary>
    /// Saves List of Questions and Answers to XML File
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

    /// <summary>
    /// Loads List of Questions and Answers from XML File
    /// </summary>
    /// <returns>Loaded List</returns>
    public static List<QuestionAnswer> LoadXml()
    {
        var questionAnswerList = new List<QuestionAnswer>();
        var reader = new XmlSerializer(typeof(List<QuestionAnswer>));
        var path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "questionanswers.xml");
        using (FileStream file = File.Open(path, FileMode.Open))
        {
            questionAnswerList = (List<QuestionAnswer>)reader.Deserialize(file);
        }

        return questionAnswerList;
    }
}