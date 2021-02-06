using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Model;
using QuizAPI.Repo;

namespace QuizAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuiz _repo;
        private readonly IMapper _mapper;
        private readonly MyContext _context;

        public QuizController(IQuiz repo, IMapper mapper, MyContext context)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetQuizes()
        {
            var questionRepo = await _repo.getQuestions();

            return Ok(questionRepo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var questionRepo = await _repo.GetQuestion(id);

            return Ok(questionRepo);
        }

        [HttpGet("score")]
        public async Task<IActionResult> GetAnswers()
        {
            var answeredrepo = await _repo.GetAnswered();

            return Ok(answeredrepo);
        }

        [HttpPost("answered/{id}")]
        public async Task<IActionResult> AnswerQuestion(Answered answered, int id)
        {
            var questionRepo = await _repo.GetQuestion(id);
            if(questionRepo == null){
                return BadRequest("There is no questions left,or there is no such a question");
            }
            answered.QuestionName = questionRepo.Name;
            answered.CorrectAnswer = questionRepo.CorrectAnswer;
            
            questionRepo.isAnswered = true;

            if(questionRepo.CorrectAnswer == answered.YourAnswer){
                  answered.PointEarned = questionRepo.Points;
            }


            await _context.Answereds.AddAsync(answered);

            await _context.SaveChangesAsync();

            return Ok(answered);
        }

        [HttpDelete("deleteData")]
        public async Task<IActionResult> DeleteData()
        {

            var answeredrepo = await _repo.GetAnswered();
            var qu = _context.Questions.Include(a => a.Answers).ToList();

            for (int i = 0; i < qu.Count; i++)
            {
                qu[i].isAnswered = false;
            }

            _context.Answereds.RemoveRange(answeredrepo);

            await _context.SaveChangesAsync();

            return Ok(qu);
        }

    }
}