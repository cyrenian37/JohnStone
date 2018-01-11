using SunSeven.DataSource;
using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Security.xaml
    /// </summary>
    public partial class Security : UserControl
    {

        public Security()
        {
            InitializeComponent();

            this.DataContext = new vmSecurity();

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.RadGridView1.IsReadOnly = true;
            }
           

        }

        private void RadGridView1_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        {
            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows == null)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
            else
            {
                if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                           MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void RadGridView1_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            foreach (HSSecurity l in e.Items)
            {
                if (l.Id < 0) continue;

                try
                {
                    var lScreen = lDataContext.UserScreens.Where(p => p.UserId == l.Id);

                    lDataContext.UserScreens.DeleteAllOnSubmit(lScreen);
                    lDataContext.SubmitChanges();

                    DataSource.Security lItem = lDataContext.Securities.SingleOrDefault<DataSource.Security>(p => p.Id == l.Id);

                    lDataContext.Securities.DeleteOnSubmit(lItem);
                    lDataContext.SubmitChanges();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void RadGridView1_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            if (e.EditAction == GridViewEditAction.Cancel) return;

            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            HSSecurity lEdited = e.EditedItem as HSSecurity;

            DataSource.Security lUpdate = lDataContext.Securities.SingleOrDefault(p => p.Id == lEdited.Id);


            if (lUpdate == null)
            {
                DataSource.Security newItem = new DataSource.Security
                {
                    Id = lEdited.Id,
                    UserName = lEdited.UserName,
                    Password = lEdited.Password,
                    RoleId = lEdited.RoleId,
                    EmployeeId = lEdited.EmployeeId,
                    DefaultPage = lEdited.PageId,
                    AccessLevel = lEdited.AccessLevel 

                };
                // Add the new object to the Orders collection.
                lDataContext.Securities.InsertOnSubmit(newItem);

                // Submit the change to the database.
                try
                {
                    lDataContext.SubmitChanges();

                    lEdited.Id = newItem.Id;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    RadGridView1.Items.Remove(e.NewData);
                }
            }
            else
            {
                lUpdate.UserName = lEdited.UserName;
                lUpdate.Password = lEdited.Password;
                lUpdate.RoleId = lEdited.RoleId;
                lUpdate.EmployeeId = lEdited.EmployeeId;
                lUpdate.DefaultPage = lEdited.PageId;
                lUpdate.AccessLevel = lEdited.AccessLevel;
                lDataContext.SubmitChanges();
            }
        }

        private void RadGridView1_RowValidated(object sender, Telerik.Windows.Controls.GridViewRowValidatedEventArgs e)
        {

        }




    }
}
