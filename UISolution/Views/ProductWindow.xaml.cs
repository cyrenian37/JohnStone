using System.Collections.Generic;
using System.Windows.Input;
using Telerik.Windows.Controls;
using SunSeven.Models;
using SunSeven.ViewModels;
namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class ProductWindow : RadWindow
    {
        //private SunSeven.DataSource.JSDataContext lDataContext;

        public delegate void selecteProductHander(List<HSProduct> selectedProducts);

        static public event selecteProductHander selecteProductCommand;

       
        public ProductWindow()
        {
            InitializeComponent();
            DataContext = new vmProduct();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Apply_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //HSProduct lSelectedProduct = this.RadGridView1.SelectedItem as HSProduct;

            List<HSProduct> lSelectedProducts = new List<HSProduct>();

            foreach (HSProduct l in this.RadGridView1.SelectedItems)
            {
                lSelectedProducts.Add(l);
            }

            if (selecteProductCommand != null)
            {
                selecteProductCommand(lSelectedProducts);
            }

        }

    }
}
