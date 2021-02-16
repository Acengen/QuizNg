using System;
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
    public class MathController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        private readonly IQuiz _repo;
        public MathController(MyContext context, IMapper mapper, IQuiz repo)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetBigNumber()
        {
            var bigNumber = await _context.Mathematic.ToListAsync();

            return Ok(bigNumber);
        }

        [HttpGet("numbersToSum")]
         public async Task<IActionResult> GetNumbers()
        {
            var numbers = await _context.MixNumber.ToListAsync();

            return Ok(numbers);
        }

        [HttpPost("result")]
        public async Task<IActionResult> PostFutureResult(Mathematic mathematic)
        {

            mathematic.BigNumber = mathematic.RandomNumber(100, 700);

            await _context.Mathematic.AddAsync(mathematic);

            var math = await _context.Mathematic.ToListAsync();

            if (math.Count >= 1)
            {
                return NoContent();
            }
            await _context.SaveChangesAsync();

            return Ok(mathematic);
        }

        [HttpPost("numberGen")]
        public async Task<IActionResult> PostRandomNumber(MixNumber mixNumber)
        {
            mixNumber.Number = mixNumber.GenerateRandom(1, 20);

            await _context.MixNumber.AddAsync(mixNumber);

            var mix = await _context.MixNumber.ToListAsync();

            if (mix.Count > 5)
            {
                return NoContent();
            }

            await _context.SaveChangesAsync();

            return Ok(mixNumber);
        }

       

    }
}