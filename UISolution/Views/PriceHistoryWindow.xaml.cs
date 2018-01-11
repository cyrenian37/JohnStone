using SunSeven.Models;
using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class PriceHistoryWindow : RadWindow
    {
        private SunSeven.DataSource.JSDataContext lDataContext;
        public PriceHistoryWindow()
        {
            InitializeComponent();

        }

        public PriceHistoryWindow(int CustomerId, int ProductId, int? Unit)
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();

            try
            {
                this.Header += " (" + lDataContext.Customers.SingleOrDefault(p => p.Id == CustomerId).Name + ")";
                var lProduct = lDataContext.Products.SingleOrDefault(p => p.Id == ProductId);
                this.txtProduct.Text = lProduct.Name + " (" + lProduct.Description + ")";
                this.txtProduct.Text += "\nUnit : " + lDataContext.SellingUnits.SingleOrDefault(p => p.Id == Unit).Unit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var lPriceHist = from o in lDataContext.Orders
                             join i in lDataContext.Invoices 
                             on o.InvoiceId equals i.Id 
                             join oi in lDataContext.OrderItems
                             on o.Id equals oi.OrderId
                             where o.CustomerId.Equals(CustomerId) && oi.ProductId.Equals(ProductId) && oi.SellingUnitId.Equals(Unit)
                             select new
                             {
                                 o.OrderDate,
                                 i.DeliveryDate,
                                // Product = oi.Product.Name + " (" + oi.Product.Description + ")",
                                // oi.SellingUnit.Unit,
                                // VAT = oi.VatRate.Name,
                                 oi.UnitPrice,
                                 //Price = oi.UnitPrice + (oi.UnitPrice * (oi.VatRate.Rate / 100)),
                                 oi.Quantity
                             };


            gridPriceHistory.ItemsSource = lPriceHist;

            var lSalesHist = from o in lDataContext.Sales
                             join oi in lDataContext.SalesItems
                             on o.Id equals oi.SalesId
                             where o.CustomerId.Equals(CustomerId) && oi.ProductId.Equals(ProductId) && oi.SellingUnitId.Equals(Unit)
                             select new
                             {
                                 o.SalesDate,
                                 o.ExpireDate,
                                 //Product = oi.Product.Name + " (" + oi.Product.Description + ")",
                                 //oi.SellingUnit.Unit,
                                // VAT = oi.VatRate.Name,
                                 oi.UnitPrice,
                                // Price = oi.UnitPrice + (oi.UnitPrice * (oi.VatRate.Rate / 100))
                             };

            gridSalesHistory.ItemsSource = lSalesHist;

        }
    }
}
