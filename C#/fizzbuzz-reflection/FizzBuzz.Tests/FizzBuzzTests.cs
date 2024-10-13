using Newtonsoft.Json.Linq;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {

        [Fact]
        public void FizzBuzz_Zero_IsNotFizzOrBuzz()
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            var result = fizzBuzzFactory.Process(0);
            Assert.NotEqual("fizz", result);
            Assert.NotEqual("buzz", result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void FizzBuzz_ValuesNotMultipleOf3Or5_areNumbers(int value)
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            var result = fizzBuzzFactory.Process(value);
            Assert.NotEqual("fizz", result);
            Assert.NotEqual("buzz", result);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        public void FizzBuzz_MultipleOf3Only_AreFizz(int value)
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            var result = fizzBuzzFactory.Process(value);
            Assert.Equal("fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void FizzBuzz_MultipleOf5Only_AreBuzz(int value)
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            var result = fizzBuzzFactory.Process(value);
            Assert.Equal("buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void FizzBuzz_MultipleOf3And5_AreFizBuzz(int value)
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            var result = fizzBuzzFactory.Process(value);
            Assert.Equal("fizzbuzz", result);
        }

        [Theory]
        [InlineData(-1, "-1")]
        [InlineData(-3, "fizz")]
        [InlineData(-5, "buzz")]
        [InlineData(-15, "fizzbuzz")]
        public void FizzBuzz_NegativeNumbers(int value, string expected)
        {
            FizzBuzzFactory fizzBuzzFactory = new();
            var result = fizzBuzzFactory.Process(value);
            Assert.Equal(expected, result);
        }
    }
}