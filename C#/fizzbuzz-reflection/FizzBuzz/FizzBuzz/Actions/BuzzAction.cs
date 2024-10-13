namespace FizzBuzz.Actions
{
    [FizzBuzz(5)]
    public class BuzzAction : IFizzBuzzAction
    {
        public string Process() => "buzz";

        public bool ShouldContinue() => true;

        public bool ShouldReplace() => false;
    }
}
