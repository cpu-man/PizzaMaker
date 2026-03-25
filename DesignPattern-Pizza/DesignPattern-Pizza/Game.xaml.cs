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

        private void ClickSound() //Metode der spiller en lydeffekt hvergang der bliver trykket på en knap
        {
            var sound = new MediaPlayer();
            sound.Open(new Uri("Sounds/balloon.mp3", UriKind.Relative));
            sound.Play();
        }

        private void LockBases() //Deaktiverer pizza base knapperne så man ikke kan tykke på dem flere gange
        {
            BtnMargherita.IsEnabled = false;
            BtnBianca.IsEnabled = false;
        }

        private void ResetPizza() //Metode der nulstiller pizzaen hver gang der skal laves en ny
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

        private void UpdateCustomerBubble() //Metode der viser kundens ordrer, den opretter nye TextBlocke
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
                Text = "Hello, i would like a pizza with:",
                FontSize = 18,
                Foreground = new SolidColorBrush(Color.FromRgb(52, 73, 94)),
                Margin = new Thickness(0, 5, 0, 10)
            };

            CustomerOrderPanel.Children.Add(header);
            CustomerOrderPanel.Children.Add(intro);

            var baseBlock = new TextBlock
            {
                Text = $"{_order.RequiredBase}",
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

        
        private void Margherita_Click(object sender, RoutedEventArgs e) //Knap der tilføjer Margherita
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

        private void Bianca_Click(object sender, RoutedEventArgs e) //Knap der tilføjer Bianca base
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
        private void Kebab_Click(object sender, RoutedEventArgs e) //Knap der tilføjer Kebab
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

        private void Mozza_Click(object sender, RoutedEventArgs e) //Knap der tilføjer Mozzarellla
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

        private void Parma_Click(object sender, RoutedEventArgs e) //Knap der tilføjer Parma ham
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

        private void Gorgon_Click(object sender, RoutedEventArgs e) //Knap der tilføjer Gorgonzolla
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
        private async void Bake_Click(object sender, RoutedEventArgs e) //Knap der sætter pizza i 'ovnen' og giver den til kunden. 
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; } //Fejl besked hvis man ikke har en base

            BakeButton.IsEnabled = false;
            KebabButton.IsEnabled = false;
            MozzaButton.IsEnabled = false;
            ParmaButton.IsEnabled = false;
            GorgonButton.IsEnabled = false;
            MenuButton.IsEnabled = false;

            PizzaCanvas.Visibility = Visibility.Hidden;
            PizzaStatusBlock.Visibility = Visibility.Hidden;
            PriceStatusBlock.Visibility = Visibility.Hidden;

            var sound = new MediaPlayer();
            sound.Open(new Uri("Sounds/Fire.mp3", UriKind.Relative));
            sound.Play();

            //Viser flammer og venter med at give den til kunden
            FlameLabel.Foreground = Brushes.OrangeRed;
            await Task.Delay(2000);
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            await Task.Delay(300);

            bool correct = _order.CheckOrder(_pizzaSubject.GetPizza());

            if (correct)
            {
                var money = new MediaPlayer();
                money.Open(new Uri("Sounds/Money.mp3", UriKind.Relative));
                money.Play();
                decimal earned = _pizzaSubject.GetPizza().GetPrice(); //Prisen på pizzaen
                decimal earnedWithStrategy = _order.DiscountStrategy.ApplyDiscount(earned); //Prisen med strategy (discount)
                _earnings += earnedWithStrategy;
                EarningsLabel.Text = $"DKK {_earnings:0.00}";
                MessageBox.Show($"✅ Perfect! The customer loved it!\n{_order.DiscountStrategy.discountName} used\n+DKK {earnedWithStrategy:0.00}", "Great job!");
            }
            else
            {
                var wrong = new MediaPlayer();
                wrong.Open(new Uri("Sounds/Wrong.mp3", UriKind.Relative));
                wrong.Play();
                MessageBox.Show("❌ Wrong pizza! That's not what the customer ordered.\n+DKK 0.00", "Oops!"); //Besked hvis man ikke laver den rigtige pizza
            }

            PizzaCanvas.Visibility = Visibility.Visible;
            PizzaStatusBlock.Visibility = Visibility.Visible;
            PriceStatusBlock.Visibility = Visibility.Visible;

            ResetPizza(); //Når pizzaen er givet kaldes der på metoden der nulstiller pizzaen

            _order = new CustomerOrder();
            UpdateCustomerBubble();

            BakeButton.IsEnabled = true;
            KebabButton.IsEnabled = true;
            MozzaButton.IsEnabled = true;
            ParmaButton.IsEnabled = true;
            GorgonButton.IsEnabled = true;
            MenuButton.IsEnabled = true;
        }

        private void Menu_Click(object sender, RoutedEventArgs e) //Knap der vender tilbage til hovedmenuen
        {
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}