namespace FizzBuzz.Actions
{
    [FizzBuzz([3,5])]
    public class FizzBuzzAction : IFizzBuzzAction
    {
        public string Process() => "fizzbuzz";
    }
}
