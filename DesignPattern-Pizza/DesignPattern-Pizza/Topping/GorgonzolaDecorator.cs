using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza.Topping
{
    //Tilføjer Gorgonzola som topping. Tager pris og beskrivelse fra den pizza objektet og lægger sin egen oveni (Samme med andre decorators)
    internal class GorgonzolaDecorator : ToppingDecorator
    {
        public GorgonzolaDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return _pizza.GetDescription() + " +  Gorgonzola"; //Sætter gorgonzola sammen med beskrivelsen
        }

        public override decimal GetPrice()
        {
            return _pizza.GetPrice() + 17; //Sætter prisen sammen med den tidligere pris
        }
    }
}
