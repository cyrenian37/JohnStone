using System.Windows.Controls;
using UISolution.ViewModels;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public LoginViewModel ViewModel;
        public MainMenu()
        {
            InitializeComponent();


        }



        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listBox.SelectedItem as UISolution.Models.NavigationItem).DisplayName == "Log Out")

            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new LogInPage();
            //try
            //{
            //    this.LoginControl.Lock();
            //}
            //catch
            //{ }
        }
    }
}
