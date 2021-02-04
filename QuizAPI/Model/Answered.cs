namespace QuizAPI.Model
{
    public class Answered
    {
        public int id {get;set;}
        public int PointEarned { get; set; }
        public string QuestionName { get; set; }
        public string CorrectAnswer { get; set; }
        public string YourAnswer { get; set; }
    }
}