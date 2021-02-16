using System;

namespace QuizAPI.Model
{
    public class MixNumber
    {
        public int Id { get; set; }
        public int Number { get; set; }


        public int GenerateRandom(int min,int number)
        {
            var random = new Random();

            return random.Next(min,number);
        }
    }
}