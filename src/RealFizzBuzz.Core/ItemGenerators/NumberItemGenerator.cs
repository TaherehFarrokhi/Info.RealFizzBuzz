namespace RealFizzBuzz.Core.ItemGenerators
{
    public class NumberItemGenerator : IItemGenerator
    {
        public string Generate(int number)
        {
            return number.ToString();
        }

        public IItemGenerator NextGenerator => null;
    }
}