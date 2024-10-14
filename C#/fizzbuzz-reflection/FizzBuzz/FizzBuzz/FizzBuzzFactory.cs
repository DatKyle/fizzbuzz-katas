using System.Reflection;
using FizzBuzz.Actions;

namespace FizzBuzz
{

    public class FizzBuzzAttribute(int[] value) : Attribute
    {
        public int[] trigger = value;
    }

    public class FizzBuzzFactory
    {

        private readonly Dictionary<int[], IFizzBuzzAction> triggerActions = new Dictionary<int[], IFizzBuzzAction>();

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

        public IFizzBuzzAction? Process(int value)
        {

            if(value != 0) return null;
            return triggerActions.FirstOrDefault(trgAct => trgAct.Key.Any(trgVal => trgVal == 0)).Value;
        }
    }
}