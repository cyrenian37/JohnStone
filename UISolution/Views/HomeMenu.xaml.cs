using System.Windows.Controls;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for MainPage2.xaml
    /// </summary>
    public partial class HomeMenu : UserControl
    {
        public HomeMenu()
        {
            InitializeComponent();
        }

        public HomeMenu(int Id)
        {
            InitializeComponent();

            listMainMenuBox.SelectedItem = listMainMenuBox.Items[Id];
        }

        private void listMainMenuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch ((((sender as Telerik.Windows.Controls.RadListBox).SelectedItem) as UISolution.Models.SitePage).DisplayName)
            {
                case "LOG OUT":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new LogInPage();
                    break;
                case "ORDERS":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Order();
                    break;
                //case "SALES":
                //    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Sales();
                //    break;
            }
        }

    }
}
