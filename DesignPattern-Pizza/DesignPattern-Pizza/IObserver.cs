using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    //Observer interface, alle klasser som skal 'lytte' til pizzaændringer implementerer dette
    public interface IObserver
    {

        void Update(IPizza ipizza) //Kaldes af Subject når pizzaen opdaters
        {

        }
    }
}
