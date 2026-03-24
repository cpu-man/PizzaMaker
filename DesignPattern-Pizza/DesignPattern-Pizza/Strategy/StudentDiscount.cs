using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Strategy
{
    public class StudentDiscount : IDiscountStrategy
    {
        public string discountName => "Student Discount - 20%";

        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice * 0.80m;
        }
    }
}
