using System;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests
{
    public class SequenceGeneratorAcceptanceTests
    {
        [Theory]
        [InlineData(1, 2, "1 2")]
        [InlineData(1, 1, "1")]
        [InlineData(1, 3, "1 2 Lucky")]
        [InlineData(1, 5, "1 2 Lucky 4 Buzz")]
        [InlineData(1, 16, "1 2 Lucky 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz Lucky 14 FizzBuzz 16")]
        public void ReturnTheSequenceCorrectlyWhenRangeIsCorrect(int lower, int upper, string expected)
        {
            // Aquire
            var itemGeneratorChainBuilder = new ItemGeneratorChainBuilder();
            var sequenceOccurancecalculator = new SequenceOccuranceCalculator();
            var sut = new SequenceGenerator(itemGeneratorChainBuilder, sequenceOccurancecalculator);

            // Act
            var actual = sut.Generate(lower, upper);

            // Assert
            Assert.Equal(expected, actual.ToSequenceOutput());
        }

        [Theory]
        [InlineData(1, 3, "1 2 Lucky", "fizz: 0|buzz: 0|fizzbuzz: 0|lucky: 1|integer: 2")]               
        [InlineData(1, 1, "1", "fizz: 0|buzz: 0|fizzbuzz: 0|lucky: 0|integer: 1")]               
        [InlineData(1, 20, 
            "1 2 Lucky 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz Lucky 14 FizzBuzz 16 17 Fizz 19 Buzz", 
            "fizz: 4|buzz: 3|fizzbuzz: 1|lucky: 2|integer: 10"
         )]
        public void ReturnTheOccuranceOfSequenceResults(int lower, int upper, 
            string expectedSequence, 
            string expectedSequenceOccurance)
        {
            // Aquire
            var itemGeneratorChainBuilder = new ItemGeneratorChainBuilder();
            var sequenceOccurancecalculator = new SequenceOccuranceCalculator();
            var sut = new SequenceGenerator(itemGeneratorChainBuilder, sequenceOccurancecalculator);
            var expectedOccurance =
                expectedSequenceOccurance.Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries);

            // Act
            var actual = sut.Generate(lower, upper);

            // Assert
            Assert.Equal(expectedSequence, actual.ToSequenceOutput());
            Assert.Equal(expectedOccurance, actual.SequenceOccurances);
        }

        [Theory]
        [InlineData(2, 1)]
        public void ThrowInvalidRangeExceptionWhenTheLowerIsBiggerThanUpper(int lower, int upper)
        {
            // Aquire
            var itemGeneratorChainBuilder = new ItemGeneratorChainBuilder();
            var sequenceOccurancecalculator = new SequenceOccuranceCalculator();
            var sut = new SequenceGenerator(itemGeneratorChainBuilder, sequenceOccurancecalculator);

            // Act
            var exception = Assert.Throws<InvalidRangeException>(() => sut.Generate(lower, upper));

            // Assert
            Assert.Equal($"Invalid range error. {lower} is bigger then {upper}", exception.Message);
        }
    }
}