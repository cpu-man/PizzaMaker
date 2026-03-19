using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    public class BiancaBase : ToppingDecorator
    {
        public BiancaBase(IPizza pizza) : base(pizza)
        {
        }

        public override decimal GetPrice()
        {
            return 45;
        }

        public override string GetDescription()
        {
            return "Bianca pizza";
        }
    }
}
