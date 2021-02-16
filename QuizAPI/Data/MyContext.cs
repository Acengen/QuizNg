using Microsoft.EntityFrameworkCore;
using QuizAPI.Model;

namespace QuizAPI.Data
{
   public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
        
        }

       public DbSet<Question> Questions {get;set;}
       public DbSet<Answer> Answers {get;set;}
       public DbSet<Answered> Answereds {get;set;}
      
        public DbSet<Mathematic> Mathematic {get;set;}

        public DbSet<MixNumber> MixNumber {get;set;}
      
    }
}