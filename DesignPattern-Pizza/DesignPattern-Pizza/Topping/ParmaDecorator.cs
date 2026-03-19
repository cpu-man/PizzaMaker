using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern_Pizza;

namespace DesignPattern_Pizza.Topping
{
    internal class ParmaDecorator : ToppingDecorator
    {
        public ParmaDecorator(IPizza pizza) : base(pizza)
        {

        }

        public override decimal GetPrice()
        {
            return _pizza.GetPrice() + 15;
        }

        public override string GetDescription()
        {
            return _pizza.GetDescription() + " Parma ham";
        }
    }
}
