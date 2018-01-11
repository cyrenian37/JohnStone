using SunSeven.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for ProductEditor.xaml
    /// </summary>
    public partial class ProductEditor : UserControl
    {
        public ProductEditor()
        {
            InitializeComponent();

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.myRadDataForm.CommandButtonsVisibility = Telerik.Windows.Controls.Data.DataForm.DataFormCommandButtonsVisibility.None;
            }
            //DataContext = new vmProduct();

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

                SunSeven.Models.HSProduct lItem = myRadDataForm.CurrentItem as SunSeven.Models.HSProduct;

                DataSource.JSDataContext lDataContext;

                lDataContext = new CommonFunction().JSDataContext();

                try
                {
                    var lDelProductUnit = lDataContext.ProductUnits.Where(p => p.ProductId == lItem.Id);
                    lDataContext.ProductUnits.DeleteAllOnSubmit(lDelProductUnit);

                    var lDelItem = lDataContext.Products.Single(p => p.Id == lItem.Id);

                    lDataContext.Products.DeleteOnSubmit(lDelItem);
                    lDataContext.SubmitChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;
                }

            }


        }

        //private void radGridUnit_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        //{
        //    //HSProductUnit lNew = new HSProductUnit();

        //    //lNew.UnitId = 1;
        //    //lNew.Id = -1;

        //    //e.NewObject = lNew;


        //    //e.Cancel = true;
        //}

        private void radGridUnit_CellValidating(object sender, Telerik.Windows.Controls.GridViewCellValidatingEventArgs e)
        {
            if (e.NewValue == null)
            {
                e.IsValid = false;

                return;
            }

            foreach (HSProductUnit l in (sender as Telerik.Windows.Controls.RadGridView).Items)
            {
                if (l.UnitId == (int)e.NewValue)
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Unit Already exits.";


                    return;
                }
            }

            e.IsValid = true;


        }


    }

}
