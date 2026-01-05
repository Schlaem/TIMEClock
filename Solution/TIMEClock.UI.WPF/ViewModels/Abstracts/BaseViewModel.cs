using CommunityToolkit.Mvvm.ComponentModel;
using TIMEClock.UI.WPF.EFCore;

namespace TIMEClock.UI.WPF.ViewModels.Abstracts
{
    public abstract class BaseViewModel : ObservableRecipient
    {
        private static AppDbContext? _dbContext;

        protected AppDbContext AppContext => _dbContext ??= new AppDbContext();
    }
}
