using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizAPI.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public string CorrectAnswer { get; set; }

        public bool isAnswered { get; set; }

        public ICollection<Answer> Answers {get;set;}
    }
}