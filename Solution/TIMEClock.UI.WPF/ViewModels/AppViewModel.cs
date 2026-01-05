using TIMEClock.UI.WPF.ViewModels.Abstracts;

namespace TIMEClock.UI.WPF.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public RecordsOverviewViewModel RecordsOverviewViewModel { get; }

        public SettingsViewModel SettingsViewModel { get; }

        public AppViewModel() : base()
        {
            RecordsOverviewViewModel = new RecordsOverviewViewModel();
            SettingsViewModel = new SettingsViewModel();
        }
    }
}
