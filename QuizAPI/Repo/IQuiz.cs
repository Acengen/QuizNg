using System.Collections.Generic;
using System.Threading.Tasks;
using QuizAPI.Model;

namespace QuizAPI.Repo
{
    public interface IQuiz
    {
        Task<IEnumerable<Question>> getQuestions();
        Task<Question> GetQuestion(int id);
    }
}