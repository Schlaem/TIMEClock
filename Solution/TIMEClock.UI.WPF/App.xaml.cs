using System.Windows;
using TIMEClock.UI.WPF.ViewModels;
using TIMEClock.UI.WPF.Views.Windows;

namespace TIMEClock.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new AppWindow() {
                DataContext = new AppViewModel()
            };

            MainWindow.Show();
        }
    }
}