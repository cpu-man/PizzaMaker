using System;
using System.Collections.Generic;

namespace DesignPattern_Pizza
{
    public class CustomerOrder
    {
        private static Random _random = new Random();

        public string RequiredBase { get; private set; }
        public List<string> RequiredToppings { get; private set; }

        public CustomerOrder()
        {
            GenerateOrder();
        }

        private void GenerateOrder()
        {
            // Pick a random base
            string[] bases = { "Margerita", "Bianca" };
            RequiredBase = bases[_random.Next(bases.Length)];

            // Pick 2 or 3 random toppings
            string[] allToppings = { "Kebab", "Mozzarella", "Parma ham", "Gorgonzola" };
            int toppingCount = _random.Next(2, 4); // 2 or 3

            var shuffled = new List<string>(allToppings);
            for (int i = shuffled.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                var temp = shuffled[i];
                shuffled[i] = shuffled[j];
                shuffled[j] = temp;
            }

            RequiredToppings = shuffled.GetRange(0, toppingCount);
        }

        public bool CheckOrder(IPizza pizza)
        {
            string description = pizza.GetDescription();

            if (!description.Contains(RequiredBase))
                return false;

            foreach (string topping in RequiredToppings)
                if (!description.Contains(topping))
                    return false;

            return true;
        }
    }
}