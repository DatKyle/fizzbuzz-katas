# Fizz Buzz reflection

This version of Fizz Buzz is done using reflection.

I'm using a custom attribute (`FizzBuzzAttribute`) to specify the trigger value (0, 3, or 5). \
The `FizzBuzzFactory`'s constructor uses reflection to get all the class types which have the custom attribute. When we have all the classes with the attribute we check if they are using the `IFizzBuzzAction` interface, if it does we create an instance of the class and store it in a dictionary, where they key is the trigger value and the value is the class action.

## Assumption
I've assumed that 0 is not Fizz or Buzz, as it is not divisable by the 3 or 5.

## drawback/impact of choices
As I have FizzBuzzAttribute which stores the trigger value, I've ellected to run the FizzBuzz algorithim in the Factory `Process` function as it makes use of the attribute value.

Alternative I could have done 1 of 2 things:
1. use the attribute with the trigger value, but have a `Check` function to determine whether we should apply the action or not.
2. use the attribute without the trigger value and instead add a new function to the interface and action classes to perform the check instead.

Because of the chosen architecture, to add more rules to FizzBuzz, is a simple case of adding new classes with the attribute. For example:
you could add the following:
```C#
    [FizzBuzz(10)]
    public class LizzAction : IFizzBuzzAction
    {
        public string Process() => "lizz";

        public bool ShouldContinue() => false;

        public bool ShouldReplace() => true;
    }
```
This would mean any multiple of 10 would only display "lizz".