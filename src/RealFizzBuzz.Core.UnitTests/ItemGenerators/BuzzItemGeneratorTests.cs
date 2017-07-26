using System;
using NSubstitute;
using RealFizzBuzz.Core.ItemGenerators;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests.ItemGenerators
{
    public class BuzzItemGeneratorTests
    {
        [Theory]
        [InlineData(5, "Buzz")]
        [InlineData(10, "Buzz")]
        [InlineData(15, "Buzz")]
        [InlineData(8, "8")]
        public void ReturnThePresentationOfNumberCorrectly(int number, string expected)
        {
            // Aquire
            var nextGenerator = Substitute.For<IItemGenerator>();
            nextGenerator.Generate(number).Returns(number.ToString());
            
            var sut = new BuzzItemGenerator(nextGenerator);

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
            var exception = Assert.Throws<ArgumentNullException>(() => new BuzzItemGenerator(null));

            // Assert
            Assert.NotNull(exception);
        }        
    }
}