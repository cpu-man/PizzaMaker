using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    //Pizza interface, bruges af decorator pattern
    public interface IPizza
    {
        decimal GetPrice();

        string GetDescription();
       
    }
}
