using System;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests
{
    public class SequenceResultTests
    {
        [Fact]
        public void ToStringReturnTheRightOutputIsTheInputsAreValid()
        {
            // Aquire
            var sut = new SequenceResult(new [] {"1"}, new [] {"Occurance"});

            // Act
            var actual = sut.ToSequenceOutput();

            // Assert
            Assert.Equal("1", actual);
        }
        
        [Theory]
        [InlineData("1|2", null)]
        [InlineData(null, "1|2")]
        [InlineData(null, null)]
        public void ToStringReturnTheRightOutputIsTheInputsAreInvalid(string input1, string input2)
        {
            // Aquire
            var sequences = input1?.Split(new []{"|"}, StringSplitOptions.RemoveEmptyEntries);
            var sequenceOccurances = input2?.Split(new []{"|"}, StringSplitOptions.RemoveEmptyEntries);
            
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new SequenceResult(sequences, sequenceOccurances));

            // Assert
            Assert.NotNull(exception);
        }
    }
}