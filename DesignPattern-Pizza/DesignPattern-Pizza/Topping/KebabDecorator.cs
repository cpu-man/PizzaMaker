using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Topping
{
    internal class KebabDecorator : ToppingDecorator
    {
        public KebabDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return _pizza.GetDescription() + " Kebab";
        }

        public override decimal GetPrice()
        {
            return _pizza.GetPrice() + 14;
        }
    }
}
