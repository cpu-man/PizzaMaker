using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Strategy
{
    public class NoDiscount : IDiscountStrategy
    {
        string discountName => "No Discount";

        string IDiscountStrategy.discountName => discountName;

        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice;
        }
    }
}
