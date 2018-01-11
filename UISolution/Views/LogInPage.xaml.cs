using SunSeven.ViewModels;
using System.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : UserControl
    {
        public LoginViewModel ViewModel;
        public LogInPage()
        {
            InitializeComponent();

            this.ViewModel = new LoginViewModel();
            this.LoginControl.DataContext = this.ViewModel;

            this.txtCompany.Text = " " + Models.CommonFunction.GetCompanyInfo().CompanyName;

        }
    }
}
