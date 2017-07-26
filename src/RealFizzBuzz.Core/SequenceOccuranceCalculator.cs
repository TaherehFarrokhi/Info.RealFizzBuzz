using System;
using System.Collections.Generic;
using System.Linq;

namespace RealFizzBuzz.Core
{
    public class SequenceOccuranceCalculator : ISequenceOccuranceCalculator
    {
        public IEnumerable<string> CalculateOccurances(string[] inputs)
        {
            var sequenceGroups = new[]
            {
                "fizz",
                "buzz",
                "fizzbuzz",
                "lucky",
            };

            var integerCount = inputs.Count(s => int.TryParse(s, out int test));
            return sequenceGroups
                .Select(m => new
                {
                    Name = m,
                    Count = inputs.Count(s => s.Equals(m, StringComparison.CurrentCultureIgnoreCase))
                })
                .Union(new[] {new {Name = "integer", Count = integerCount}})
                .Select(m => $"{m.Name}: {m.Count}")
                .ToArray();
        }
    }
}