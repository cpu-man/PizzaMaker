using System.Configuration;
using System.Data;
using System.Windows;

namespace DesignPattern_Pizza
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen("images_png/StartSplash.png");
            splashScreen.Show(false);
            Thread.Sleep(2500);

            splashScreen.Close(TimeSpan.FromSeconds(0.5));
            base.OnStartup(e);
        }
    }

}
