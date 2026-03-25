using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Strategy
{
    //Stretegy interface for spillets rabatsystem, alle nye rabatter tilføjes ved at implementere dette
    public interface IDiscountStrategy
    {
        string discountName { get; }
        public decimal ApplyDiscount(decimal totalPrice) //Standard, overrides i andre stretegy klasser
        {
            return totalPrice;
        }
    }
}
