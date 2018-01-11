using System.Collections.Generic;
using System.Windows.Input;
using Telerik.Windows.Controls;
using SunSeven.Models;
using SunSeven.ViewModels;
namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : RadWindow
    {
        public delegate void selecteProductHander2(List<JSProduct> selectedProducts);

        static public event selecteProductHander2 selecteProductCommand2;

        public ProductList()
        {
            InitializeComponent();
            DataContext = new vmProductLight();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Apply_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //HSProduct lSelectedProduct = this.RadGridView1.SelectedItem as HSProduct;

            List<JSProduct> lSelectedProducts = new List<JSProduct>();

            foreach (JSProduct l in this.RadGridView1.SelectedItems)
            {
                lSelectedProducts.Add(l);
            }

            if (selecteProductCommand2 != null)
            {
                selecteProductCommand2(lSelectedProducts);
            }

        }
    }
}
