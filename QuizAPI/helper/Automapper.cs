using AutoMapper;
using QuizAPI.Dto;
using QuizAPI.Model;

namespace QuizAPI.helper
{
    public class Automapper : Profile
    {
       public Automapper()
       {
           CreateMap<QuestionDto,Question>();
           CreateMap<Question,QuestionDto>();
       }
    }
}