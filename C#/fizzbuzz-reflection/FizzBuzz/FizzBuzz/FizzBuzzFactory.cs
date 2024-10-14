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
            var zeroAction = triggerActions.FirstOrDefault(trgAct => trgAct.Key.Any(trgVal => trgVal == 0)).Value;

            IFizzBuzzAction? action = triggerActions
                .Where(trgAct => trgAct.Key.All(trgVal => checkValueTrigger(value, trgVal, zeroAction != null)))
                .OrderByDescending(trgAct => trgAct.Key.Count())
                .FirstOrDefault().Value;

            if (action != null) return action;

            if (value != 0) return null;
            
            return zeroAction;
        }

        private bool checkValueTrigger(int value, int trigger, bool hasZeroAction)
        {
            if (hasZeroAction && value == 0) return false;
            if (trigger == 0) return false;
            return value % trigger == 0;
        }
    }
}