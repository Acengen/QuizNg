using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Data;
using QuizAPI.Dto;
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

            var questionToRetrun = _mapper.Map<IEnumerable<QuestionDto>>(questionRepo);
            return Ok(questionToRetrun);
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

            if(questionRepo.CorrectAnswer == answered.YourAnswer){
                  answered.PointEarned = questionRepo.Points;
            }


            await _context.Answereds.AddAsync(answered);

            await _context.SaveChangesAsync();

            return Ok(answered);
        }

    }
}