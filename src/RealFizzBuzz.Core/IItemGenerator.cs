namespace RealFizzBuzz.Core
{
    public interface IItemGenerator
    {
        string Generate(int number);
        
        IItemGenerator NextGenerator { get; }
    }
}