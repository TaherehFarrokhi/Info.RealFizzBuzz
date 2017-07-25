using System;
using System.Linq;

namespace RealFizzBuzz.Core
{
    //TODO: Needs refactoring to multiple classes.
    public class SequenceGenerator
    {
        public SequenceResult Generate(int lower, int upper)
        {
            if (lower > upper)
                throw new InvalidRangeException(lower, upper);

            var sequences = Enumerable.Range(lower, upper).Select(GenerateSingle).ToArray();
            var sequenceOccurances = CalculateSequenceOccurance(sequences);
            
            return new SequenceResult(sequences, sequenceOccurances);
        }

        private static string[] CalculateSequenceOccurance(string[] sequences)
        {
            var sequenceGroups = new[]
            {
                "fizz",
                "buzz",
                "fizzbuzz",
                "lucky",
            };

            var integerCount = sequences.Count(s => int.TryParse(s, out int test));
            return sequenceGroups
                .Select(m => new
                {
                    Name = m,
                    Count = sequences.Count(s => s.Equals(m, StringComparison.CurrentCultureIgnoreCase))
                })
                .Union(new[] {new {Name = "integer", Count = integerCount}})
                .Select(m => $"{m.Name}: {m.Count}")
                .ToArray();
        }

        private static string GenerateSingle(int number)
        {
            if (number.ToString().Contains("3"))
                return "Lucky";
            
            if (number % 5 == 0 && number % 3 == 0) 
                return "FizzBuzz";

            if (number % 5 == 0)
                return "Buzz";

            return number % 3 == 0 ? "Fizz" : number.ToString();
        }
    }
}