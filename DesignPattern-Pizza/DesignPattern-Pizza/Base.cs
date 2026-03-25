using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    //Tom pizza objekt, bruges før spilleren har valgt en base
    public class Base : IPizza
    {
        public string GetDescription()
        {
            return "";
        }

        public decimal GetPrice()
        {
            return 0;
        }
    }
}
