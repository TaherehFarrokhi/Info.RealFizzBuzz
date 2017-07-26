using System;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests
{
    public class SequenceOccuranceCalculatorTests
    {
        [Theory]
        [InlineData("1|2|Lucky", "fizz: 0|buzz: 0|fizzbuzz: 0|lucky: 1|integer: 2")]               
        [InlineData("1", "fizz: 0|buzz: 0|fizzbuzz: 0|lucky: 0|integer: 1")]               
        [InlineData(
            "1|2|Lucky|4|Buzz|Fizz|7|8|Fizz|Buzz|11|Fizz|Lucky|14|FizzBuzz|16|17|Fizz|19|Buzz", 
            "fizz: 4|buzz: 3|fizzbuzz: 1|lucky: 2|integer: 10"
        )]
        public void ReturnTheRightSequenceOccuranceWhenTheDataIsCorrect(string input, string expected)
        {
            // Aquire
            var inputs = input.Split(new[] {"|"}, StringSplitOptions.None);
            var expectedOutputs = expected.Split(new[] {"|"}, StringSplitOptions.None);
            
            var sut = new SequenceOccuranceCalculator();

            // Act
            var actual = sut.CalculateOccurances(inputs);

            // Assert
            Assert.Equal(expectedOutputs, actual);
        }

        [Fact]
        public void ThrowArgumentNullExceptionWhenTheListIsNull()
        {
            // Aquire
            var sut = new SequenceOccuranceCalculator();
            
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => sut.CalculateOccurances(null));

            // Assert
            Assert.NotNull(exception);
        }
    }
}