using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    public class PizzaSubject
    {
        private IPizza _currentPizza = new Base();
        private List<IObserver> _observers = new List<IObserver>();

        public void NewObserver(IObserver observer) //Tilmelder en observer
        {
            _observers.Add(observer);
        }

        public void SetPizza(IPizza pizza) //Opdaterer pizzaen og notificerer alle observers
        {
            _currentPizza = pizza;
            NotifyAll();
        }

        public IPizza GetPizza()
        {
             return _currentPizza;
        }

        void NotifyAll() //Notificerer observers
        {
            foreach(var observer in _observers)
            {
                observer.Update(_currentPizza);
            }
        }
    }
}
