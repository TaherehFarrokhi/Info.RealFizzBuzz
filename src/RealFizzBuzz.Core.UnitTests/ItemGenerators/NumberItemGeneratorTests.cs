using RealFizzBuzz.Core.ItemGenerators;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests.ItemGenerators
{
    public class NumberItemGeneratorTests
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(20, "20")]
        public void ReturnThePresentationOfNumberCorrectly(int number, string expected)
        {
            // Aquire
            var sut = new NumberItemGenerator();

            // Act
            var actual = sut.Generate(number);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}