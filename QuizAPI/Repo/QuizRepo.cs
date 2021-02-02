using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Dto;
using QuizAPI.Model;

namespace QuizAPI.Repo
{
    public class QuizRepo : IQuiz
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public QuizRepo(MyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<Question> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(a => a.Answers).FirstOrDefaultAsync(q => q.Id == id);

            return question;
        }

        public async Task<IEnumerable<Question>> getQuestions()
        {
           
            var questions = await _context.Questions.Include(a => a.Answers).ToListAsync();

            return questions;
        }
    }
}