using Microsoft.EntityFrameworkCore;
using TIMEClock.UI.WPF.ViewModels.Abstracts;

namespace TIMEClock.UI.WPF.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string? DbConnectionString { get; }

        public SettingsViewModel() : base()
        {
            DbConnectionString = AppContext.Database.GetConnectionString();
        }
    }
}
