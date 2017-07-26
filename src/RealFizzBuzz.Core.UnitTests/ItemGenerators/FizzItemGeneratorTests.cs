using System;
using NSubstitute;
using RealFizzBuzz.Core.ItemGenerators;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests.ItemGenerators
{
    public class FizzItemGeneratorTests
    {
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(9, "Fizz")]
        [InlineData(8, "8")]
        public void ReturnThePresentationOfNumberCorrectly(int number, string expected)
        {
            // Aquire
            var nextGenerator = Substitute.For<IItemGenerator>();
            nextGenerator.Generate(number).Returns(number.ToString());
            
            var sut = new FizzItemGenerator(nextGenerator);

            // Act
            var actual = sut.Generate(number);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReturnThrowArgumentExceptionWhenDependencyIsNull()
        {
            // Aquire

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new FizzItemGenerator(null));

            // Assert
            Assert.NotNull(exception);
        }        
    }
}