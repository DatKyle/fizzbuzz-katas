namespace FizzBuzz
{
    public interface IFizzBuzzAction
    {
        public string Process();

        public bool ShouldReplace();
        public bool ShouldContinue();
    }
}
