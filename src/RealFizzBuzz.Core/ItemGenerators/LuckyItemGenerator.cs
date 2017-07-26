using System;

namespace RealFizzBuzz.Core.ItemGenerators
{
    public class LuckyItemGenerator : IItemGenerator
    {
        private readonly IItemGenerator _nextGenerator;

        public LuckyItemGenerator(IItemGenerator nextGenerator)
        {
            _nextGenerator = nextGenerator ?? throw new ArgumentNullException(nameof(nextGenerator));
        }
        
        public string Generate(int number)
        {
            return number.ToString().Contains("3") ? "Lucky" : _nextGenerator.Generate(number);
        }
        
        public IItemGenerator NextGenerator => _nextGenerator;    }
}