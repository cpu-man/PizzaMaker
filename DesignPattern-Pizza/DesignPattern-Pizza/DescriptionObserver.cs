using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesignPattern_Pizza
{
    //Opdaterer pizzaens beskrivelse i UI'et når der laves ændringer
    public class DescriptionObserver : IObserver
    {
        TextBlock _label;

        public DescriptionObserver(TextBlock label)
        {
            _label = label;
        }

        public void Update(IPizza pizza) //Opdaterer textblock med pizzaens toppings
        {
            _label.Text = pizza.GetDescription();
        }
    }
}
