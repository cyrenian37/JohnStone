using SunSeven.Models;
using SunSeven.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for ProductWin.xaml
    /// </summary>
    public partial class ProductWin : RadWindow
    {
        public delegate void selecteProductHander(List<JSProduct> selectedProducts);

        public static event selecteProductHander selecteProductCommand;

        public ProductWin()
        {
            InitializeComponent();
            DataContext = new vmProductLight();
            this.RadGridView1.MouseDoubleClick += this.OnGridMouseDoubleClick;
            textBoxFilterValue.Focus();
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
        }

       
        public ProductWin(int CustomerId)
        {
            InitializeComponent();
            DataContext = new vmProductLight();

            this.RadGridView1.MouseDoubleClick += this.OnGridMouseDoubleClick;
            textBoxFilterValue.Focus();
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;

            Telerik.Windows.Controls.GridViewColumn productColumn = this.RadGridView1.Columns["ProductId"];
            Telerik.Windows.Controls.GridView.IColumnFilterDescriptor productFilter = productColumn.ColumnFilterDescriptor;

            //productColumn = this.RadGridView1.Columns["Description"];
            //Telerik.Windows.Controls.GridView.IColumnFilterDescriptor productFilter2 = productColumn.ColumnFilterDescriptor;

            SunSeven.DataSource.JSDataContext lDataContext = new CommonFunction().JSDataContext();
            foreach (var l in lDataContext.ProductFiltering(CustomerId))
            {
                productFilter.DistinctFilter.AddDistinctValue(l.productId);
              //  productFilter2.DistinctFilter.AddDistinctValue(l.Description);
            }
        }

        void OnGridMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement originalSender = e.OriginalSource as FrameworkElement;
            if (originalSender != null)
            {
                var cell = originalSender.ParentOfType<GridViewCell>();
                if (cell != null)
                {
                    if (cell.Column.UniqueName == "SelectedUnitId")
                    {
                        //textBoxFilterValue.Text = string.Empty;
                        //textBoxFilterValue.Focus();
                        return;
                    }
                    //MessageBox.Show("The double-clicked cell is " + cell.Value);
                }

                var row = originalSender.ParentOfType<GridViewRow>();
                if (row != null)
                {
                    // MessageBox.Show("The double-clicked row is " + ((JSProduct)row.DataContext).productnName);

                    JSProduct lProduct = (JSProduct)row.DataContext;

                    List<JSProduct> lSelectedProducts = new List<JSProduct>();


                    lSelectedProducts.Add(lProduct);


                    if (selecteProductCommand != null)
                    {
                        selecteProductCommand(lSelectedProducts);
                    }

                }
            }

            textBoxFilterValue.Text = string.Empty;
            textBoxFilterValue.Focus();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Apply_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            List<JSProduct> lSelectedProducts = new List<JSProduct>();

            if (this.RadGridView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select product.");
                return;
            }

            foreach (JSProduct l in this.RadGridView1.SelectedItems)
            {
                lSelectedProducts.Add(l);
            }

            if (selecteProductCommand != null)
            {
                selecteProductCommand(lSelectedProducts);
            }

            textBoxFilterValue.Text = string.Empty;
            textBoxFilterValue.Focus();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SunSeven.Models.CommonFunction.productSet = null;
            // SunSeven.Models.CommonFunction.GetProductList();
            DataContext = new vmProductLight();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // this.RadGridView1.FilterDescriptors.Clear();
            RadGridView1.FilterDescriptors.SuspendNotifications();
            foreach (Telerik.Windows.Controls.GridViewColumn column in this.RadGridView1.Columns)
            {
                column.ClearFilters();
            }
            this.RadGridView1.FilterDescriptors.ResumeNotifications();
        }

        private void RadWindow_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            selecteProductCommand = null;
        }
    }
}
