namespace RealFizzBuzz.Core
{
    public class SequenceResult
    {
        public SequenceResult(string[] sequence)
        {
            Sequence = sequence;
        }

        public string[] Sequence { get; }

        public override string ToString()
        {
            return string.Join(" ", Sequence);
        }
    }
}