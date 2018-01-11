using System.Windows;
using System.Windows.Controls;
using UISolution.Views;

namespace UISolution
{
    /// <summary>
    /// Interaction logic for menuProduct.xaml
    /// </summary>
    public partial class menuProduct : UserControl
    {
        public menuProduct()
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
                case "PRODUCT EDITOR":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new ProductEditor();
                    break;
                case "CATEGORIES":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new Configuration();
                    break;

                case "PRICE HISTORY":
                    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new PriceHistory();
                    break;

            }

        }
    }
}
