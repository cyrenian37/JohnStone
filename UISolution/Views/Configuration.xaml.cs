using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Configuration : UserControl
    {
        public Configuration()
        {
            InitializeComponent();

            DataContext = new vmConfiguration();

        }


        private bool HasSubordinates(Employee employee)
        {
            //return
            //(from emp in (IEnumerable<Employee>)this.RadGridView1.ItemsSource
            // where emp.ReportsTo == employee.EmployeeID
            // select emp).Any();

            return true;
        }



        private void gridCategory_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();


                foreach (HSCategory l in e.Items)
                {
                    SunSeven.DataSource.Category items = (lDataContext.Categories.Single(p => p.Id == l.Id));

                    lDataContext.Categories.DeleteOnSubmit(items);
                    try
                    {
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

        private void gridCategory_Deleted(object sender, GridViewDeletedEventArgs e)
        {


        }

        private void AddingNewDataItem(object sender, GridViewAddingNewEventArgs e)
        {
            HSCategory lNew = new HSCategory();

            RadGridView grid = sender as RadGridView;
            GridViewRow parentRow = grid.ParentRow as GridViewRow;

            if (parentRow == null)
                lNew.ParentId = null;
            else
                lNew.ParentId = (parentRow.Item as HSCategory).Id;

            e.NewObject = lNew;
        }




        private void gridDepartment_Deleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        private void gridDepartment_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();


                foreach (HSDepartment l in e.Items)
                {
                    SunSeven.DataSource.Department items = (lDataContext.Departments.SingleOrDefault(p => p.Id == l.Id));

                    lDataContext.Departments.DeleteOnSubmit(items);
                    try
                    {
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

        private void gridClientType_Deleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        private void gridClientType_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();


                foreach (HSClientType l in e.Items)
                {
                    SunSeven.DataSource.ClientType items = (lDataContext.ClientTypes.SingleOrDefault(p => p.Id == l.Id));

                    lDataContext.ClientTypes.DeleteOnSubmit(items);
                    try
                    {
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

        private void gridVAT_Deleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        private void gridVAT_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();


                foreach (HSVatRate l in e.Items)
                {
                    SunSeven.DataSource.VatRate items = (lDataContext.VatRates.SingleOrDefault(p => p.Id == l.Id));

                    lDataContext.VatRates.DeleteOnSubmit(items);
                    try
                    {
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

        private void gridSellingUnit_Deleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        private void gridSellingUnit_Deleting(object sender, GridViewDeletingEventArgs e)
        {

            
            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();


                foreach (HSSellingUnit l in e.Items)
                {
                    if (l.Id == 0)
                    {
                        MessageBox.Show("Can't delete default Unit [" +  l.Unit + "]");
                        return;
                    }

                    SunSeven.DataSource.SellingUnit items = (lDataContext.SellingUnits.SingleOrDefault(p => p.Id == l.Id));

                    lDataContext.SellingUnits.DeleteOnSubmit(items);
                    try
                    {
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

        private void gridRoles_Deleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        private void gridRoles_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();


                foreach (HSRole l in e.Items)
                {
                    SunSeven.DataSource.Role items = (lDataContext.Roles.SingleOrDefault(p => p.Id == l.Id));

                    lDataContext.Roles.DeleteOnSubmit(items);
                    try
                    {
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

        private void gridSellingUnit_AddingNewDataItem(object sender, GridViewAddingNewEventArgs e)
        {
            e.NewObject = new HSSellingUnit() { Id = -1 };
        }
    }

}
