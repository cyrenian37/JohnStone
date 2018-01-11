using System.Windows.Controls;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for menuSettings.xaml
    /// </summary>
    public partial class menuSettings : UserControl
    {
        public menuSettings()
        {
            InitializeComponent();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((((sender as Telerik.Windows.Controls.RadListBox).SelectedItem) as UISolution.Models.SitePage).DisplayName)
            {
                case "PEOPLE":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new People();
                    break;
                case "SUPPLIER":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Suppliers();
                    break;
                case "CUSTOMER":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Customer();
                    break;
                case "EMPLOYEE":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Employee();
                    break;
                case "CONFIGURATION":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Configuration();
                    break;
            }

        }
    }
}
