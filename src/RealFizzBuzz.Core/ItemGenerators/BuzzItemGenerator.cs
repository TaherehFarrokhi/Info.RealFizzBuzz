using System;

namespace RealFizzBuzz.Core.ItemGenerators
{
    public class BuzzItemGenerator : IItemGenerator
    {
        private readonly IItemGenerator _nextGenerator;

        public BuzzItemGenerator(IItemGenerator nextGenerator)
        {
            _nextGenerator = nextGenerator ?? throw new ArgumentNullException(nameof(nextGenerator));
        }
        
        public string Generate(int number)
        {
            return number % 5 == 0 ? "Buzz" : _nextGenerator.Generate(number);
        }

        public IItemGenerator NextGenerator => _nextGenerator;
    }
}