using FizzBuzz.Actions;
using Newtonsoft.Json.Linq;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        private const int Zero = 0;
        private const int Number = 1;
        private const int Fizz = 3;
        private const int Buzz = 5;
        private const int FizzBuzz = 15;

        [Fact]
        public void Zero_ShouldBe0()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(Zero);
            Assert.NotNull(result);
            Assert.Equal(typeof(ZeroAction), result.GetType());
            Assert.Equal("0", result.Process());
        }

        [Fact]
        public void One_ShouldBe1()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(Number);
            Assert.Null(result);
        }

        [Fact]
        public void Three_ShouldBeFizz()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(Fizz);
            Assert.NotNull(result);
            Assert.Equal(typeof(FizzAction), result.GetType());
            Assert.Equal("fizz", result.Process());
        }

        [Fact]
        public void Five_ShouldBeBuzz()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(Buzz);
            Assert.NotNull(result);
            Assert.Equal(typeof(BuzzAction), result.GetType());
            Assert.Equal("buzz", result.Process());
        }

        [Fact]
        public void MultipleOf_3_and_5_ShouldBeFizzBuzz()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            IFizzBuzzAction? result = fizzBuzzFactory.Process(FizzBuzz);
            Assert.NotNull(result);
            Assert.Equal(typeof(FizzBuzzAction), result.GetType());
            Assert.Equal("fizzbuzz", result.Process());
        }
    }
}