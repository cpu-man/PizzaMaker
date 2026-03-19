using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    public class BiancaBase : IPizza
    {
        public decimal GetPrice()
        {
            return 45;
        }

        public string GetDescription()
        {
            return "Bianca pizza";
        }
    }
}
