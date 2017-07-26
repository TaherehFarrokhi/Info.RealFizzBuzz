namespace RealFizzBuzz.Core
{
    public interface IItemGeneratorChainBuilder
    {
        IItemGenerator BuildChain();
    }
}