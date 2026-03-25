using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Strategy
{
    public class NoDiscount : IDiscountStrategy
    {
        public string discountName => "No Discount";

        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice;
        }
    }
}
