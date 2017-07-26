using System;
using NSubstitute;
using RealFizzBuzz.Core.ItemGenerators;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests.ItemGenerators
{
    public class LuckyItemGeneratorTests
    {
        [Theory]
        [InlineData(13, "Lucky")]
        [InlineData(3, "Lucky")]
        [InlineData(33, "Lucky")]
        [InlineData(300, "Lucky")]
        [InlineData(0, "0")]
        [InlineData(10, "10")]
        public void ReturnThePresentationOfNumberCorrectly(int number, string expected)
        {
            // Aquire
            var nextGenerator = Substitute.For<IItemGenerator>();
            nextGenerator.Generate(number).Returns(number.ToString());
            
            var sut = new LuckyItemGenerator(nextGenerator);

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
            var exception = Assert.Throws<ArgumentNullException>(() => new LuckyItemGenerator(null));

            // Assert
            Assert.NotNull(exception);
        }        
    }
}