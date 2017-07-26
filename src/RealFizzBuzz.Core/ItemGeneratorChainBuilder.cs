using System;
using RealFizzBuzz.Core.ItemGenerators;

namespace RealFizzBuzz.Core
{
    public class ItemGeneratorChainBuilder : IItemGeneratorChainBuilder
    {
        private readonly Func<IItemGenerator, IItemGenerator>[] _builder = 
        {
            next => new FizzItemGenerator(next),
            next => new BuzzItemGenerator(next),
            next => new FizzBuzzItemGenerator(next),
            next => new LuckyItemGenerator(next)
        };
        
        public IItemGenerator BuildChain()
        {
            IItemGenerator current = new NumberItemGenerator();

            foreach (var builder in _builder)
            {
                current = builder(current);
            }

            return current;
        }
    }
}