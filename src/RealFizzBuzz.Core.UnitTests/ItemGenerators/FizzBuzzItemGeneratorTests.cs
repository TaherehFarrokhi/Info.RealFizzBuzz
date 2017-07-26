using System;
using NSubstitute;
using RealFizzBuzz.Core.ItemGenerators;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests.ItemGenerators
{
    public class FizzBuzzItemGeneratorTests
    {
        [Theory]
        [InlineData(3, "3")]
        [InlineData(5, "5")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        public void ReturnThePresentationOfNumberCorrectly(int number, string expected)
        {
            // Aquire
            var nextGenerator = Substitute.For<IItemGenerator>();
            nextGenerator.Generate(number).Returns(number.ToString());
            
            var sut = new FizzBuzzItemGenerator(nextGenerator);

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
            var exception = Assert.Throws<ArgumentNullException>(() => new FizzBuzzItemGenerator(null));

            // Assert
            Assert.NotNull(exception);
        }        
    }
}