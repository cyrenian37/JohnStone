using System.Windows;
using System.Windows.Controls;
using SunSeven.ViewModels;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class Suppliers : UserControl
    {
        public Suppliers()
        {
            InitializeComponent();

            DataContext = new vmSupplier();

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.myRadDataForm.CommandButtonsVisibility = Telerik.Windows.Controls.Data.DataForm.DataFormCommandButtonsVisibility.None;
            }
        }

      
    }
}
