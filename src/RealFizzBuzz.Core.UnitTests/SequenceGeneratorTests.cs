using System;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests
{
    public class SequenceGeneratorTests
    {
        [Theory]
        [InlineData(1, 2, "1 2")]
        [InlineData(1, 1, "1")]
        [InlineData(2, 1, "")]
        [InlineData(1, 3, "1 2 Fizz")]
        [InlineData(1, 5, "1 2 Fizz 4 Buzz")]
        [InlineData(1, 16, "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16")]
        public void ReturnTheSequenceCorrectlyWhenRangeIsCorrect(int lower, int upper, string expected)
        {
            // Aquire
            var sut = new SequenceGenerator();

            // Act
            var output = sut.Generate(lower, upper);

            // Assert
            Assert.Equal(expected, output.ToString());
        }
    }
}