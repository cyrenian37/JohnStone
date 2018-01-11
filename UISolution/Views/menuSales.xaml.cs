using System.Windows;
using System.Windows.Controls;
using UISolution.Views;

namespace UISolution
{
    /// <summary>
    /// Interaction logic for menuProduct.xaml
    /// </summary>
    public partial class menuSales : UserControl
    {
        public menuSales()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new LogInPage();

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((((sender as Telerik.Windows.Controls.RadListBox).SelectedItem) as UISolution.Models.SitePage).DisplayName)
            {
                case "SALES EDITOR":
                    busyIndicator.IsBusy = true;
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Sales(1);
                    break;
                case "SALES HISTORY":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Sales(2);
                    break;

                case "SALESV2":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Sales(2);
                    break;


                case "INVOICE":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Invoice(2);
                    break;

            }

        }
    }
}
