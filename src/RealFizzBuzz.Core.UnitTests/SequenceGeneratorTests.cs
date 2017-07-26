using System;
using NSubstitute;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests
{
    public class SequenceGeneratorTests
    {
        [Fact]
        public void ReturnTheRightResultWhenTheInputsAreCorrect()
        {
            // Aquire
            var itemGenerator = Substitute.For<IItemGenerator>();
            itemGenerator.Generate(Arg.Is(3)).Returns("Lucky");
            itemGenerator.Generate(Arg.Is(2)).Returns("2");
            itemGenerator.Generate(Arg.Is(1)).Returns("1");
            
            var itemGeneratorChainBuilder = Substitute.For<IItemGeneratorChainBuilder>();
            itemGeneratorChainBuilder.BuildChain().Returns(itemGenerator);
            
            var sequenceOccurancecalculator = Substitute.For<ISequenceOccuranceCalculator>();
            var expectedOccurances = new[]
            {
                "fizz: 0",
                "buzz: 0",
                "fizzbuzz: 0",
                "lucky: 1",
                "integer: 2"
            };
            sequenceOccurancecalculator.CalculateOccurances(Arg.Any<string[]>())
                .Returns(expectedOccurances);
            
            var sut = new SequenceGenerator(itemGeneratorChainBuilder, sequenceOccurancecalculator);

            // Act
            var actual = sut.Generate(1, 3);

            // Assert
            Assert.Equal("1 2 Lucky", actual.ToSequenceOutput());
            Assert.Equal(expectedOccurances, actual.SequenceOccurances);
        }
        
        [Fact]
        public void ThrowArgumentNullExceptionIfFirstArgumentIsNull()
        {
            // Aquire

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new SequenceGenerator(null, new SequenceOccuranceCalculator()));

            // Assert
            Assert.NotNull(exception);
        }        
        
        [Fact]
        public void ThrowArgumentNullExceptionIfSecondArgumentIsNull()
        {
            // Aquire

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new SequenceGenerator(null, new SequenceOccuranceCalculator()));

            // Assert
            Assert.NotNull(exception);
        }
    }
}