using TIMEClock.UI.WPF.ViewModels.Abstracts;

namespace TIMEClock.UI.WPF.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public SettingsViewModel SettingsViewModel { get; }

        public AppViewModel() : base()
        {
            SettingsViewModel = new SettingsViewModel();
        }
    }
}
