using System.Windows;
using UISolution.ViewModels;

namespace UISolution.Views
{
    public partial class MainWindow
    {
        #region Fields

        public LoginViewModel ViewModel;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            this.ViewModel = new LoginViewModel();
            this.DataContext = this.ViewModel;
        }

        #endregion

        #region Event handler

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            this.LoginControl.Lock();
        }

        #endregion
    }
}
