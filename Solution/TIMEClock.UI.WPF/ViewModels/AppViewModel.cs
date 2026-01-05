using TIMEClock.UI.WPF.ViewModels.Abstracts;

namespace TIMEClock.UI.WPF.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public DashboardViewModel DashboardViewModel { get; }
        public RecordsOverviewViewModel RecordsOverviewViewModel { get; }
        public SettingsViewModel SettingsViewModel { get; }

        public AppViewModel() : base()
        {
            DashboardViewModel = new DashboardViewModel();
            RecordsOverviewViewModel = new RecordsOverviewViewModel();
            SettingsViewModel = new SettingsViewModel();
        }
    }
}
