using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Dto;
using QuizAPI.Repo;

namespace QuizAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuiz _repo;
        private readonly IMapper _mapper;

        public QuizController(IQuiz repo, IMapper mapper)
        {
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

    }
}