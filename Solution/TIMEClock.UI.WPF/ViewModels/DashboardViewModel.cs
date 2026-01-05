using CommunityToolkit.Mvvm.Input;
using TIMEClock.UI.WPF.Entities;
using TIMEClock.UI.WPF.ViewModels.Abstracts;

namespace TIMEClock.UI.WPF.ViewModels
{
    public partial class DashboardViewModel : BaseViewModel
    {
        public TimeSpan CurrentTotalSaldo => GetCurrentTotalSaldo();
        public TimeSpan CurrentWorkTime => GetCurrentWorkTime();
        public TimeSpan CurrentYearSaldo => GetCurrentYearSaldo();

        private bool CanDoClocking()
        {
            return true;
        }

        private TimeSpan CalculateSollWorktime(DateTime? from = null)
        {
            DateTime startDate = from ?? Properties.Settings.Default.StartDate;
            TimeSpan total = TimeSpan.Zero;

            for(DateTime date = startDate; date <= DateTime.Today; date = date.AddDays(1))
            {
                if(date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    total = total.Add(Properties.Settings.Default.SollWorktime);
                }
            }

            return total;
        }

        [RelayCommand(CanExecute = nameof(CanDoClocking))]
        private void DoClocking()
        {
            TimeRecord lastEntry = AppContext.TimeRecords.OrderBy(x => x.From).Last();

            if(lastEntry.Until == null)
            {
                lastEntry.Until = DateTime.Now;
            }
            else
            {
                TimeRecord newEntry = new TimeRecord {
                    From = DateTime.Now,
                };
                AppContext.TimeRecords.Add(newEntry);
            }

            AppContext.SaveChanges();

            OnPropertyChanged(nameof(CurrentTotalSaldo));
            OnPropertyChanged(nameof(CurrentWorkTime));
            OnPropertyChanged(nameof(CurrentYearSaldo));
        }

        private TimeSpan GetCurrentTotalSaldo()
        {
            TimeSpan total = TimeSpan.Zero;

            foreach (TimeRecord item in AppContext.TimeRecords)
            {
                DateTime from = item.From;
                DateTime until = item.Until ?? DateTime.Now;
                total = total.Add(until - from);
            }

            TimeSpan soll = CalculateSollWorktime();

            return total.Subtract(soll);
        }

        private TimeSpan GetCurrentWorkTime()
        {
            TimeSpan total = TimeSpan.Zero;

            DateTime endOfDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);
            foreach (TimeRecord item in AppContext.TimeRecords.Where(x => x.From <= DateTime.Today.AddDays(1) && (x.Until == null || DateTime.Today < x.Until)))
            {
                DateTime from = item.From;
                DateTime until = item.Until ?? DateTime.Now;

                if(from < DateTime.Today)
                {
                    from = DateTime.Today;
                }

                if(until > endOfDay)
                {
                    until = endOfDay;
                }

                total = total.Add(until - from);
            }

            return total;
        }

        private TimeSpan GetCurrentYearSaldo()
        {
            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            TimeSpan total = TimeSpan.Zero;

            foreach (TimeRecord item in AppContext.TimeRecords.Where(x => x.Until > startOfYear))
            {
                DateTime from = item.From;
                DateTime until = item.Until ?? DateTime.Now;
                total = total.Add(until - from);
            }

            TimeSpan soll = CalculateSollWorktime(startOfYear);

            return total.Subtract(soll);
        }
    }
}
