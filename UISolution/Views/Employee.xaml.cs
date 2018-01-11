using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : UserControl
    {
        private SunSeven.DataSource.JSDataContext lDataContext;
        public Employee()
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();

            this.DataContext = new vmEmployee();

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.myRadDataForm.CommandButtonsVisibility = Telerik.Windows.Controls.Data.DataForm.DataFormCommandButtonsVisibility.None;
            }
        }

        private void myRadDataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {

            HSEmployee lNewItem = new HSEmployee();

            ObservableCollection<HSDepartment> lDepts = new ObservableCollection<HSDepartment>();


            foreach (DataSource.Department l in lDataContext.Departments)
            {

                lDepts.Add(new HSDepartment
                {
                    Id = l.Id,
                    Name = l.Name,
                    IsSelected = false
                });
            }

            lNewItem.Departments = lDepts;

            ((e.NewItem) as HSEmployee).Departments = lDepts;
        }

        private void myRadDataForm_DeletedItem(object sender, Telerik.Windows.Controls.Data.DataForm.ItemDeletedEventArgs e)
        {

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

                SunSeven.Models.HSEmployee lItem = myRadDataForm.CurrentItem as SunSeven.Models.HSEmployee;

                DataSource.JSDataContext lDataContext;

                lDataContext = new CommonFunction().JSDataContext();

                try
                {
                    var lDelEmpDept = lDataContext.Emp_Depts.Where(p => p.EmployeeId == lItem.Id);
                    lDataContext.Emp_Depts.DeleteAllOnSubmit(lDelEmpDept);

                    var lDelItem = lDataContext.Employees.Single(p => p.Id == lItem.Id);

                    lDataContext.Employees.DeleteOnSubmit(lDelItem);
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
