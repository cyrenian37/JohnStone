using System.Windows.Controls;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for MainPage2.xaml
    /// </summary>
    public partial class MainPage2 : UserControl
    {
        public MainPage2()
        {
            InitializeComponent();
        }

        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new MainPage();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new MainPage();
        }

        private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new LogInPage();
        }
    }
}
    