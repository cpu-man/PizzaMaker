using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using DesignPattern_Pizza.Topping;

namespace DesignPattern_Pizza
{
    public partial class Game : Window
    {
        IPizza _currentPizza;
        private decimal _earnings = 0;
        private bool _baseChosen = false;

        public Game()
        {
            InitializeComponent();
            _currentPizza = new Base();
        }

        // Locks both base buttons after one is picked
        private void LockBases()
        {
            BtnMargherita.IsEnabled = false;
            BtnBianca.IsEnabled = false;
        }

        // Resets everything for the next order
        private void ResetPizza()
        {
            _currentPizza = new Base();
            _baseChosen = false;

            // Remove all images from canvas
            var toRemove = new List<UIElement>();
            foreach (UIElement child in PizzaCanvas.Children)
                if (child is Image) toRemove.Add(child);
            foreach (var child in toRemove)
                PizzaCanvas.Children.Remove(child);

            // Re-enable base buttons
            BtnMargherita.IsEnabled = true;
            BtnBianca.IsEnabled = true;

            // Reset flame colour
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));

            PizzaStatusLabel.Text = "Your Pizza: Empty";
        }

        // Bases
        private void Margherita_Click(object sender, RoutedEventArgs e)
        {
            if (_baseChosen) return;
            _baseChosen = true;
            LockBases();

            _currentPizza = new MargheritaBase(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Margarita base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PizzaCanvas.Children.Add(img);
            PizzaStatusLabel.Text = _currentPizza.GetDescription();
        }

        private void Bianca_Click(object sender, RoutedEventArgs e)
        {
            if (_baseChosen) return;
            _baseChosen = true;
            LockBases();

            _currentPizza = new BiancaBase(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Bianca base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PizzaCanvas.Children.Add(img);
            PizzaStatusLabel.Text = _currentPizza.GetDescription();
        }

        // Toppings
        private void Kebab_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new KebabDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Kebab_Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PizzaCanvas.Children.Add(img);
            PizzaStatusLabel.Text = _currentPizza.GetDescription();
        }

        private void Mozza_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new MozzarellaDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Mozzarella Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PizzaCanvas.Children.Add(img);
            PizzaStatusLabel.Text = _currentPizza.GetDescription();
        }

        private void Parma_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new ParmaDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Parma Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PizzaCanvas.Children.Add(img);
            PizzaStatusLabel.Text = _currentPizza.GetDescription();
        }

        private void Gorgon_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new GorgonzolaDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Gorgonzola Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PizzaCanvas.Children.Add(img);
            PizzaStatusLabel.Text = _currentPizza.GetDescription();
        }

        // Bake animation + order check
        private async void Bake_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }

            // Disable all buttons during baking
            BakeButton.IsEnabled = false;
            KebabButton.IsEnabled = false;
            MozzaButton.IsEnabled = false;
            ParmaButton.IsEnabled = false;
            GorgonButton.IsEnabled = false;

            // Step 1 — pizza goes into oven, disappears
            PizzaCanvas.Visibility = Visibility.Hidden;
            PizzaStatusLabel.Visibility = Visibility.Hidden;

            // Step 2 — flames light up red
            FlameLabel.Foreground = Brushes.OrangeRed;
            await Task.Delay(2000);

            // Step 3 — flames go dark again
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            await Task.Delay(300);

            // Step 4 — check order (replace this condition with your CustomerOrder logic)
            bool correct = _currentPizza.GetDescription().Contains("Margherita")
                        && _currentPizza.GetDescription().Contains("Mozzarella")
                        && _currentPizza.GetDescription().Contains("Kebab");

            if (correct)
            {
                decimal earned = _currentPizza.GetPrice();
                _earnings += earned;
                EarningsLabel.Text = $"DKK {_earnings:0.00}";
                MessageBox.Show($"✅ Perfect! The customer loved it!\n+DKK {earned:0.00}", "Great job!");
            }
            else
            {
                MessageBox.Show("❌ Wrong pizza! The customer is unhappy.\n+DKK 0.00", "Oops!");
            }

            // Step 5 — reset for next order
            ResetPizza();

            // Re-enable topping buttons
            BakeButton.IsEnabled = true;
            KebabButton.IsEnabled = true;
            MozzaButton.IsEnabled = true;
            ParmaButton.IsEnabled = true;
            GorgonButton.IsEnabled = true;
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ResetPizza();
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}