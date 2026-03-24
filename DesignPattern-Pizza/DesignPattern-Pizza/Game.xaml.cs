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
        private PizzaSubject _pizzaSubject = new PizzaSubject();
        private decimal _earnings = 0;
        private bool _baseChosen = false;
        private CustomerOrder _order;

        public Game()
        {
            InitializeComponent();
            //_currentPizza = new Base();
            _pizzaSubject.NewObserver(new PriceObserver(PriceStatusBlock));
            _pizzaSubject.NewObserver(new DescriptionObserver(PizzaStatusBlock));
            _order = new CustomerOrder();
            UpdateCustomerBubble();
        }

        private void ClickSound()
        {
            var sound = new MediaPlayer();
            sound.Open(new Uri("Sounds/balloon.mp3", UriKind.Relative));
            sound.Play();
        }

        private void LockBases()
        {
            BtnMargherita.IsEnabled = false;
            BtnBianca.IsEnabled = false;
        }

        private void ResetPizza()
        {
            //_currentPizza = new Base();
            _pizzaSubject.SetPizza(new Base());
            _baseChosen = false;

            var toRemove = new List<UIElement>();
            foreach (UIElement child in PizzaCanvas.Children)
                if (child is Image) toRemove.Add(child);
            foreach (var child in toRemove)
                PizzaCanvas.Children.Remove(child);

            BtnMargherita.IsEnabled = true;
            BtnBianca.IsEnabled = true;
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            //PizzaStatusBlock.Text = "Your Pizza: Empty";
            //PriceStatusBlock.Text = "Current Price: ";
        }

        private void UpdateCustomerBubble()
        {
            CustomerOrderPanel.Children.Clear();

            var header = new TextBlock
            {
                Text = "🗣️ CUSTOMER:",
                FontSize = 22,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(41, 128, 185))
            };

            var intro = new TextBlock
            {
                Text = "I would like a pizza with:",
                FontSize = 18,
                Foreground = new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                Margin = new Thickness(0, 5, 0, 10)
            };

            CustomerOrderPanel.Children.Add(header);
            CustomerOrderPanel.Children.Add(intro);

            var baseBlock = new TextBlock
            {
                Text = $"🍕 {_order.RequiredBase}",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Crimson,
                Margin = new Thickness(0, 2, 0, 0)
            };
            CustomerOrderPanel.Children.Add(baseBlock);

            foreach (string topping in _order.RequiredToppings)
            {
                var t = new TextBlock
                {
                    Text = $"• {topping}",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                    Margin = new Thickness(0, 2, 0, 0)
                };
                CustomerOrderPanel.Children.Add(t);
            }

            var discountBlock = new TextBlock
            {
                Text = $"{_order.DiscountStrategy.discountName}",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                Margin = new Thickness(0, 2, 0, 0)
            };
            CustomerOrderPanel.Children.Add(discountBlock);

        }

        // Bases
        private void Margherita_Click(object sender, RoutedEventArgs e)
        {
            if (_baseChosen) return;
            _baseChosen = true;
            LockBases();

            _pizzaSubject.SetPizza(new MargheritaBase(_pizzaSubject.GetPizza()));
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Margarita base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ClickSound();
            PizzaCanvas.Children.Add(img);
            //PizzaStatusBlock.Text = _currentPizza.GetDescription();
            //PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Bianca_Click(object sender, RoutedEventArgs e)
        {
            if (_baseChosen) return;
            _baseChosen = true;
            LockBases();

            _pizzaSubject.SetPizza(new BiancaBase(_pizzaSubject.GetPizza()));
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Bianca base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ClickSound();
            PizzaCanvas.Children.Add(img);
            //PizzaStatusBlock.Text = _currentPizza.GetDescription();
            //PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        // Toppings
        private void Kebab_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _pizzaSubject.SetPizza(new KebabDecorator(_pizzaSubject.GetPizza()));
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Kebab_Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ClickSound();
            PizzaCanvas.Children.Add(img);
            //PizzaStatusBlock.Text = _currentPizza.GetDescription();
            //PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Mozza_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _pizzaSubject.SetPizza(new MozzarellaDecorator(_pizzaSubject.GetPizza()));
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Mozzarella Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ClickSound();
            PizzaCanvas.Children.Add(img);
            //PizzaStatusBlock.Text = _currentPizza.GetDescription();
            //PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Parma_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _pizzaSubject.SetPizza(new ParmaDecorator(_pizzaSubject.GetPizza()));
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Parma Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ClickSound();
            PizzaCanvas.Children.Add(img);
            //PizzaStatusBlock.Text = _currentPizza.GetDescription();
            //PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Gorgon_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _pizzaSubject.SetPizza(new GorgonzolaDecorator(_pizzaSubject.GetPizza()));
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Gorgonzola Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ClickSound();
            PizzaCanvas.Children.Add(img);
            //PizzaStatusBlock.Text = _currentPizza.GetDescription();
            //PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        // Bake
        private async void Bake_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }

            BakeButton.IsEnabled = false;
            KebabButton.IsEnabled = false;
            MozzaButton.IsEnabled = false;
            ParmaButton.IsEnabled = false;
            GorgonButton.IsEnabled = false;
            MenuButton.IsEnabled = false;

            PizzaCanvas.Visibility = Visibility.Hidden;
            PizzaStatusBlock.Visibility = Visibility.Hidden;
            PriceStatusBlock.Visibility = Visibility.Hidden;

            FlameLabel.Foreground = Brushes.OrangeRed;
            await Task.Delay(2000);
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            await Task.Delay(300);

            bool correct = _order.CheckOrder(_pizzaSubject.GetPizza());

            if (correct)
            {
                decimal earned = _pizzaSubject.GetPizza().GetPrice();
                decimal earnedWithStrategy = _order.DiscountStrategy.ApplyDiscount(earned);
                _earnings += earnedWithStrategy;
                EarningsLabel.Text = $"DKK {_earnings:0.00}";
                MessageBox.Show($"✅ Perfect! The customer loved it!\n{_order.DiscountStrategy.discountName} used\n+DKK {earnedWithStrategy:0.00}", "Great job!");
            }
            else
            {
                MessageBox.Show("❌ Wrong pizza! The customer is unhappy.\n+DKK 0.00", "Oops!");
            }

            PizzaCanvas.Visibility = Visibility.Visible;
            PizzaStatusBlock.Visibility = Visibility.Visible;
            PriceStatusBlock.Visibility = Visibility.Visible;

            ResetPizza();

            _order = new CustomerOrder();
            UpdateCustomerBubble();

            BakeButton.IsEnabled = true;
            KebabButton.IsEnabled = true;
            MozzaButton.IsEnabled = true;
            ParmaButton.IsEnabled = true;
            GorgonButton.IsEnabled = true;
            MenuButton.IsEnabled = true;
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