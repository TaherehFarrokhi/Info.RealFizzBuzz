using System;

namespace RealFizzBuzz.Core.ItemGenerators
{
    public class FizzItemGenerator : IItemGenerator
    {
        private readonly IItemGenerator _nextGenerator;

        public FizzItemGenerator(IItemGenerator nextGenerator)
        {
            _nextGenerator = nextGenerator ?? throw new ArgumentNullException(nameof(nextGenerator));
        }
        
        public string Generate(int number)
        {
            return number % 3 == 0 ? "Fizz" : _nextGenerator.Generate(number);
        }
        
        public IItemGenerator NextGenerator => _nextGenerator;
    }
}