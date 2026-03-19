using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    public class MargheritaBase : IPizza
    {
        public string GetDescription()
        {
            return "Margerita pizza";
        }

        public decimal GetPrice()
        {
            return 40;
        }
    }
}
