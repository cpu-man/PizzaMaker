using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Strategy
{
    public interface IDiscountStrategy
    {
        string discountName { get; }
        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice;
        }
    }
}
