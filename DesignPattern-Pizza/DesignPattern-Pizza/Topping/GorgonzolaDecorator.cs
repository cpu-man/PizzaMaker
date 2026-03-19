using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Topping
{
    internal class GorgonzolaDecorator : ToppingDecorator
    {
        public GorgonzolaDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return _pizza.GetDescription() + " Gorgonzola";
        }

        public override decimal GetPrice()
        {
            return _pizza.GetPrice() + 17;
        }
    }
}
