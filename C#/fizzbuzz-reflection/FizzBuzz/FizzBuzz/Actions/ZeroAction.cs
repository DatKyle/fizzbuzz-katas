namespace FizzBuzz.Actions
{

    [FizzBuzz(0)]
    public class ZeroAction : IFizzBuzzAction
    {
        public string Process() => "0";

        public bool ShouldContinue() => false;

        public bool ShouldReplace() => true;
    }
}