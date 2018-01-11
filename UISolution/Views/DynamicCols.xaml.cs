using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using UISolution.DataSource;
using UISolution.Models;
using UISolution.ViewModels;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class DynamicCols : UserControl
    {
        public DynamicCols()
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
        }

        private void gridCategory_Deleted(object sender, GridViewDeletedEventArgs e)
        {
            UISolution.DataSource.HanSungLinqDataContext lDataContext = new HanSungLinqDataContext();

            foreach (HSCategory l in e.Items)
            {
                UISolution.DataSource.Category items = (lDataContext.Categories.Single(p => p.Id == l.Id));

                lDataContext.Categories.DeleteOnSubmit(items);
                try
                {
                    lDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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
    }

}
