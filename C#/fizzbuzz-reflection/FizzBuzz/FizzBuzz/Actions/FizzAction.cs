namespace FizzBuzz.Actions
{

    [FizzBuzz([3])]
    public class FizzAction : IFizzBuzzAction
    {
        public string Process() => "fizz";
    }
}