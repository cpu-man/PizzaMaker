using DesignPattern_Pizza.Strategy;
using System;
using System.Collections.Generic;

namespace DesignPattern_Pizza
{
    //Klasse der genererer en ordre for kunden, vælger tilfældig base, topping og rabat
    public class CustomerOrder
    {
        private static Random _random = new Random();

        public string RequiredBase { get; private set; }
        public List<string> RequiredToppings { get; private set; }
        public IDiscountStrategy DiscountStrategy { get; }
        public CustomerOrder()
        {
            GenerateOrder();

            var discount = new List<IDiscountStrategy>
            {
                new NoDiscount(),
                new StudentDiscount()
            };
            DiscountStrategy = discount[_random.Next(discount.Count)]; //Vælger tilfældig rabat
        }



        private void GenerateOrder()
        {
            // Vælger en tilfældig base
            string[] bases = { "Margerita", "Bianca" };
            RequiredBase = bases[_random.Next(bases.Length)];

            // Vælger 2-3 tilfældige toppings
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

        public bool CheckOrder(IPizza pizza) //Metode der tjekker om pizzaen stemmer overens med kundens ordrer
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