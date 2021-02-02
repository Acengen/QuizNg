using System.Text.Json.Serialization;

namespace QuizAPI.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public string NameString { get; set; }
        public int QuestionId { get; set; }

        [JsonIgnore]
        public Question Question { get; set; }
    }
}