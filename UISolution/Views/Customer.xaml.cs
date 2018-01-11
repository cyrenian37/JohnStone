using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        public Customer()
        {
            InitializeComponent();

            DataContext = new vmCustomer();

            this.myRadDataForm.CommandProvider = new CustomKeyboardCommandProvider(this.myRadDataForm);

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.myRadDataForm.CommandButtonsVisibility = Telerik.Windows.Controls.Data.DataForm.DataFormCommandButtonsVisibility.None;
            }
        }


        private void myRadDataForm_DeletingItem(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {

                SunSeven.Models.HSCustomer lItem = myRadDataForm.CurrentItem as SunSeven.Models.HSCustomer;

                DataSource.JSDataContext lDataContext;

                lDataContext = new CommonFunction().JSDataContext();

                try
                {
                    var lDelItem = lDataContext.Customers.Where(p => p.Id == lItem.Id);

                    lDataContext.Customers.DeleteAllOnSubmit(lDelItem);
                    lDataContext.SubmitChanges();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;
                }

            }
        }


    }
}
