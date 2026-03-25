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

namespace DesignPattern_Pizza
{
    /// <summary>
    /// Interaction logic for Instructions.xaml
    /// </summary>
    public partial class Instructions : Window
    {
        private string[] _text = new string[] //array af strings men instruktioner
           {
               "Hello, welcome to Pizza Maker,\nthe game where you make pizzas and earn money!\nIn this window, i'll teach you how to play the game",
                "When you press play you'll be presented with a new window.\nThat window is the main game where you'll be making pizzas",
                "You'll be given an order for a pizza.\nYour job is to make the pizza with the correct ingredients.\ne.g. You're given an order for a Bacon Pizza, so you pick bacon from the ingredients and serve it.",
                "If you've served the right pizza you'll be paid, if not, no money for you.\nThat's all you need to know now get out there and make some pizzas!"
           };

        int index = 0;
        public Instructions()
        {
            InitializeComponent();
            Back.Visibility = Visibility.Hidden;
            ToMenu.Visibility = Visibility.Hidden;
            InsBlock.Text = _text[index];


        }

        private void Next_Click(object sender, RoutedEventArgs e) //Når spilleren trykker next skifter den til den næste string i array'et
        {
            index = (index + 1) % _text.Length;
            InsBlock.Text = _text[index];
            Back.Visibility = Visibility.Visible;
            if(index >= 3)
            {
                Next.Visibility = Visibility.Hidden;
                ToMenu.Visibility = Visibility.Visible;
                    
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            index--;
            InsBlock.Text = _text[index];
            if(index < 3)
            {
                ToMenu.Visibility = Visibility.Hidden;
                Next.Visibility = Visibility.Visible;
            }
            if (index == 0)
            {
                Back.Visibility = Visibility.Hidden;
            }

        }

        private void ToMenu_Click(object sender, RoutedEventArgs e)
        {
            Next.Visibility = Visibility.Hidden;
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
    
}
