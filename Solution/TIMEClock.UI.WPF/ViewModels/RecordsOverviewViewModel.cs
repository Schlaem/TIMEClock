using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TIMEClock.UI.WPF.Entities;
using TIMEClock.UI.WPF.ViewModels.Abstracts;

namespace TIMEClock.UI.WPF.ViewModels
{
    public partial class RecordsOverviewViewModel : BaseViewModel
    {
        public bool CanAddNewRecord => !TimeRecordsCollection.Any(x => x.Until == null);

        public bool HasChanges => AppContext.ChangeTracker.HasChanges();

        public ObservableCollection<TimeRecord> TimeRecordsCollection { get; } = [];

        public RecordsOverviewViewModel()
        {
            LoadData();
        }

        public void Update()
        {
            OnPropertyChanged(nameof(CanAddNewRecord));
            LoadDataCommand.NotifyCanExecuteChanged();
            SaveChangesCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand]
        private void LoadData()
        {
            TimeRecordsCollection.Clear();
            foreach (TimeRecord timeRecord in AppContext.TimeRecords)
            {
                TimeRecordsCollection.Add(timeRecord);
            }

            OnPropertyChanged(nameof(CanAddNewRecord));
        }

        private bool CanSaveChanges()
        {
            return HasChanges;
        }

        [RelayCommand(CanExecute = nameof(CanSaveChanges))]
        private void SaveChanges()
        {
            AppContext.SaveChanges();
            OnPropertyChanged(nameof(HasChanges));
        }
    }
}
