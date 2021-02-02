using System.Collections.Generic;
using System.Text.Json.Serialization;
using QuizAPI.Model;

namespace QuizAPI.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string CorrectAnswer { get; set; }
        public ICollection<Answer> Answers {get;set;}
    }
}