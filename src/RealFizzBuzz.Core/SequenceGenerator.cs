using System.Linq;

namespace RealFizzBuzz.Core
{
    public class SequenceGenerator
    {
        public SequenceResult Generate(int lower, int upper)
        {
            if (lower > upper)
                return new SequenceResult(new string[]{});

            var sequence = Enumerable.Range(lower, upper).Select(GenerateSingle).ToArray();
            return new SequenceResult(sequence);
        }

        private string GenerateSingle(int number)
        {
            if (number.ToString().Contains("3"))
                return "Lucky";
            
            if (number % 5 == 0 && number % 3 == 0) 
                return "FizzBuzz";

            if (number % 5 == 0)
                return "Buzz";

            if (number % 3 == 0)
                return "Fizz";

            return number.ToString();
        }
    }
}