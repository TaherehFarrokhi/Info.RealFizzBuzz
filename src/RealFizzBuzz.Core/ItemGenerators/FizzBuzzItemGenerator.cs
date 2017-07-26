using System;

namespace RealFizzBuzz.Core.ItemGenerators
{
    public class FizzBuzzItemGenerator : IItemGenerator
    {
        private readonly IItemGenerator _nextGenerator;

        public FizzBuzzItemGenerator(IItemGenerator nextGenerator)
        {
            _nextGenerator = nextGenerator ?? throw new ArgumentNullException(nameof(nextGenerator));
        }
        
        public string Generate(int number)
        {
            if (number % 5 == 0 && number % 3 == 0) 
                return "FizzBuzz";
            
            return _nextGenerator.Generate(number);
        }
        
        public IItemGenerator NextGenerator => _nextGenerator;
    }
}