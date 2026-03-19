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
            _currentPizza = new Base();
        }


        // Bases 
        private void Margherita_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new MargheritaBase(_currentPizza);
            var MargheritaImg = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Margarita base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            PizzaCanvas.Children.Add(MargheritaImg);
            MessageBox.Show($"Added: Margherita\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");
        }




        // Toppings
        private void Kebab_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new KebabDecorator(_currentPizza);
            var kebabImg = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Kebab_Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            PizzaCanvas.Children.Add(kebabImg);
            MessageBox.Show($"Added: Kebab\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");


        }

        private void Parma_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new ParmaDecorator(_currentPizza);
            var parmaImg = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Parma Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            PizzaCanvas.Children.Add(parmaImg);
            MessageBox.Show($"Added: Parma ham\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");
        }

        private void Gorgon_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new GorgonzolaDecorator(_currentPizza);
            var gorgonImg = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Gorgonzola Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            PizzaCanvas.Children.Add(gorgonImg);
            MessageBox.Show($"Added: Gorgonzola\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");

        }

        private void Mozza_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new MozzarellaDecorator(_currentPizza);
            var mozzaImg = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Mozzarella Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            PizzaCanvas.Children.Add(mozzaImg);
            MessageBox.Show($"Added: Mozzarella\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");

        }

        private void Bianca_Click(object sender, RoutedEventArgs e)
        {
            _currentPizza = new BiancaBase(_currentPizza);
            var biancaImg = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Bianca base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            PizzaCanvas.Children.Add(biancaImg);
            MessageBox.Show($"Added: Bianca\n{_currentPizza.GetDescription()}\nPris:{_currentPizza.GetPrice()} kr");
        }
    }
}
