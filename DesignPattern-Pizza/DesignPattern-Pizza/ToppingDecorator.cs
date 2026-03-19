using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    public abstract class ToppingDecorator : IPizza
    {
        protected IPizza _pizza;

        public ToppingDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public abstract decimal GetPrice();

        public abstract string GetDescription();
        
    }
}
