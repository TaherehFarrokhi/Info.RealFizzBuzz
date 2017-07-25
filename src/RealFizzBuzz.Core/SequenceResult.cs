using System.Collections.Generic;

namespace RealFizzBuzz.Core
{
    public class SequenceResult
    {
        public SequenceResult(string[] sequence, string[] sequenceOccurances)
        {
            Sequence = sequence;
            SequenceOccurances = sequenceOccurances;
        }

        public string[] Sequence { get; }
        public string[] SequenceOccurances { get; }

        public override string ToString()
        {
            return string.Join(" ", Sequence);
        }
    }
}