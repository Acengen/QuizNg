using System;

namespace QuizAPI.Model
{
    public class Mathematic
    {
        public int Id { get; set; }
        public int BigNumber {get;set;}

        public int RandomNumber(int min,int max)
        {
            var random = new Random();
            return random.Next(min,max);
        }

    }
}