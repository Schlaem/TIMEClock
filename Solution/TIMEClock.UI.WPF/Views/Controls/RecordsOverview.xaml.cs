using System.Windows.Controls;
using TIMEClock.UI.WPF.ViewModels;

namespace TIMEClock.UI.WPF.Views.Controls
{
    /// <summary>
    /// Interaction logic for RecordsOverview.xaml
    /// </summary>
    public partial class RecordsOverview : UserControl
    {
        public RecordsOverview()
        {
            InitializeComponent();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ((RecordsOverviewViewModel)DataContext).Update();
        }
    }
}
