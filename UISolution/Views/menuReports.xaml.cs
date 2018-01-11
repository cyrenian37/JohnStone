using System.Windows.Controls;
using UISolution.Reports;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class menuReports : UserControl
    {
        public menuReports()
        {
            InitializeComponent();
        }

        private void listMainMenuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch ((((sender as Telerik.Windows.Controls.RadListBox).SelectedItem) as UISolution.Models.SitePage).DisplayName)
            {
                case "INVOICE":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new ReportInvoice();
                    break;
                case "DAILY SALES":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new ReportSalesHistory();
                    break;
                case "DELIVERY":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new ReportDelivery();
                    break;
            }
        }
    }
}
