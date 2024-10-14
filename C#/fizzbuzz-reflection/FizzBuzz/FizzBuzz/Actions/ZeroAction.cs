namespace FizzBuzz.Actions
{

    [FizzBuzz([0])]
    public class ZeroAction : IFizzBuzzAction
    {
        public string Process() => "0";
    }
}