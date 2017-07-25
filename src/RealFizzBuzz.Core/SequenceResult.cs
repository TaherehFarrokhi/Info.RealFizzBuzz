using System;

namespace RealFizzBuzz.Core
{
    public class SequenceResult
    {
        public SequenceResult(string[] sequences, string[] sequenceOccurances)
        {
            Sequences = sequences ?? throw new ArgumentNullException(nameof(sequences));
            SequenceOccurances = sequenceOccurances ?? throw new ArgumentNullException(nameof(sequenceOccurances));
        }

        public string[] Sequences { get; }
        public string[] SequenceOccurances { get; }

        public string ToSequenceOutput()
        {
            return string.Join(" ", Sequences);
        }
    }
}