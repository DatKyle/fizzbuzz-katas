using FizzBuzz;

namespace ReflectionFizzBuzz
{
    internal class Program
    {
        static void Main()
        {
            var factory = new FizzBuzzFactory();

            Enumerable.Range(0, 100)
                .Select(factory.Process)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
