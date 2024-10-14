using FizzBuzz.Actions;
using Newtonsoft.Json.Linq;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {

        [Fact]
        public void Zero_ShouldBe0()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(0);
            Assert.NotNull(result);
            Assert.Equal(typeof(ZeroAction), result.GetType());
            Assert.Equal("0", result.Process());
        }

        [Fact]
        public void One_ShouldBe1()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(1);
            Assert.Null(result);
        }
    }
}