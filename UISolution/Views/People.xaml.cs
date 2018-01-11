using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class People : UserControl
    {
        public People()
        {
            InitializeComponent();

            DataContext = new vmPeople();

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.myRadDataForm.CommandButtonsVisibility = Telerik.Windows.Controls.Data.DataForm.DataFormCommandButtonsVisibility.None;
            }
        }

        private void myRadDataForm_DeletedItem(object sender, Telerik.Windows.Controls.Data.DataForm.ItemDeletedEventArgs e)
        {
            SunSeven.Models.HSPeople lItem = e.DeletedItem as SunSeven.Models.HSPeople;

            DataSource.JSDataContext lDataContext;

            lDataContext = new CommonFunction().JSDataContext();

            try
            {
                var lDelItem = lDataContext.Persons.Where(p => p.Id == lItem.Id);

                lDataContext.Persons.DeleteAllOnSubmit(lDelItem);
                lDataContext.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }

}
