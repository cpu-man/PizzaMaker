using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesignPattern_Pizza.Topping;

namespace DesignPattern_Pizza
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        IPizza _currentPizza;
        public Game()
        {
            InitializeComponent();
            _currentPizza = new MargheritaBase();
        }

        private void Kebab_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new KebabDecorator(_currentPizza);
            MessageBox.Show($"Added: Kebab\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");
        }

        private void Parma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gorgon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mozza_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
