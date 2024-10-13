using System.Reflection;

namespace FizzBuzz
{

    public class FizzBuzzAttribute(int value) : Attribute
    {
        public int trigger = value;
    }

    public class FizzBuzzFactory
    {

        private Dictionary<int, IFizzBuzzAction> triggerActions = new Dictionary<int, IFizzBuzzAction>();

        public FizzBuzzFactory()
        {
            IEnumerable<Type> fizzBuzzReflection = typeof(FizzBuzzFactory).Assembly.GetTypes().Where(t => t.GetCustomAttribute<FizzBuzzAttribute>() != null);

            foreach (var action in fizzBuzzReflection)
            {
                if (action.GetCustomAttribute<FizzBuzzAttribute>() is FizzBuzzAttribute triggerAttribute &&
                    action.GetInterface(typeof(IFizzBuzzAction).Name) != null &&
                    Activator.CreateInstance(action) is IFizzBuzzAction instance)
                {
                    triggerActions.Add(triggerAttribute.trigger, instance);
                }
            }      
        }

        public string Process(int value)
        {
            string returnValue = "";
            foreach (var triggerValue in triggerActions.Keys.Order())
            {
                // If triggerValue is 0 then skip the modulus check
                if (triggerValue == 0 && (value < 0 || value > 0))
                    continue;

                if (triggerValue == 0 || value % triggerValue == 0)
                {
                    IFizzBuzzAction action = triggerActions[triggerValue];
                    returnValue = action.ShouldReplace() ? action.Process() : returnValue + action.Process();
                    if (!action.ShouldContinue())
                        break;
                }
            }
            return returnValue.Length > 0 ? returnValue : value.ToString();
        }
    }
}
