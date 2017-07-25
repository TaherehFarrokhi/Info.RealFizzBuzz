namespace RealFizzBuzz.Core.UnitTests
{
    public class SequenceResult
    {
        public SequenceResult(string[] sequence)
        {
            this.Sequence = sequence;
        }

        public string[] Sequence { get; } = new string[] { };

        public override string ToString()
        {
            return string.Join(" ", Sequence);
        }
    }
}