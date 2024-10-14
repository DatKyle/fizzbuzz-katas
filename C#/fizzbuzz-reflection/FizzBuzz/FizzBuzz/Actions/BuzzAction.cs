namespace FizzBuzz.Actions
{
    [FizzBuzz([5])]
    public class BuzzAction : IFizzBuzzAction
    {
        public string Process() => "buzz";
    }
}
