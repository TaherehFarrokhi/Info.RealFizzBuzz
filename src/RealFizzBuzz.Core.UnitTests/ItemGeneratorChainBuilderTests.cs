using RealFizzBuzz.Core.ItemGenerators;
using Xunit;

namespace RealFizzBuzz.Core.UnitTests
{
    public class ItemGeneratorChainBuilderTests
    {
        [Fact]
        public void ReturnCorrectChainOfItemGenerators()
        {
            // Aquire
            var sut = new ItemGeneratorChainBuilder();

            // Act
            var actual = sut.BuildChain();

            // Assert
            Assert.Equal(typeof(LuckyItemGenerator), actual.GetType());
            
            actual = actual.NextGenerator;
            Assert.Equal(typeof(FizzBuzzItemGenerator), actual.GetType());

            actual = actual.NextGenerator;
            Assert.Equal(typeof(BuzzItemGenerator), actual.GetType());
            
            actual = actual.NextGenerator;
            Assert.Equal(typeof(FizzItemGenerator), actual.GetType());

            actual = actual.NextGenerator;
            Assert.Equal(typeof(NumberItemGenerator), actual.GetType());
            
            Assert.Equal(null, actual.NextGenerator);
        }
    }
}