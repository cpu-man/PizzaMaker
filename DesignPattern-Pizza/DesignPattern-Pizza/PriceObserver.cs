using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesignPattern_Pizza
{
    //Opdaterer pizzaens pris i UI'et når der laves ændringer
    public class PriceObserver : IObserver
    {
        TextBlock _label;

        public PriceObserver(TextBlock label)
        {
            _label = label;
        }

        public void Update(IPizza pizza) //Opdaterer TextBlock med pizzaens pris
        {
            _label.Text = $"Current Price: {pizza.GetPrice()} kr.";
        }
    }
}
