using System.Collections.Generic;

namespace RealFizzBuzz.Core
{
    public interface ISequenceOccuranceCalculator
    {
        IEnumerable<string> CalculateOccurances(string[] inputs);
    }
}