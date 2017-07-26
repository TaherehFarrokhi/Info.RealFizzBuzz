using System;
using System.Collections.Generic;
using System.Linq;

namespace RealFizzBuzz.Core
{
    public class SequenceGenerator
    {
        private readonly IItemGeneratorChainBuilder _itemGeneratorChainBuilder;
        private readonly ISequenceOccuranceCalculator _sequenceOccurancecalculator;

        public SequenceGenerator(IItemGeneratorChainBuilder itemGeneratorChainBuilder, 
            ISequenceOccuranceCalculator sequenceOccurancecalculator)
        {
            _itemGeneratorChainBuilder = itemGeneratorChainBuilder ?? throw new ArgumentNullException(nameof(itemGeneratorChainBuilder));
            _sequenceOccurancecalculator = sequenceOccurancecalculator ?? throw new ArgumentNullException(nameof(sequenceOccurancecalculator));
        }
        
        public SequenceResult Generate(int lower, int upper)
        {
            if (lower > upper)
                throw new InvalidRangeException(lower, upper);

            var sequences = Enumerable.Range(lower, upper).Select(GenerateSingle).ToArray();
            var sequenceOccurances = CalculateSequenceOccurance(sequences);
            
            return new SequenceResult(sequences, sequenceOccurances.ToArray());
        }

        private IEnumerable<string> CalculateSequenceOccurance(string[] sequences)
        {
            return _sequenceOccurancecalculator.CalculateOccurances(sequences);
        }

        private string GenerateSingle(int number)
        {
            var itemGenerator = _itemGeneratorChainBuilder.BuildChain();
            
            return itemGenerator.Generate(number);
        }
    }
}