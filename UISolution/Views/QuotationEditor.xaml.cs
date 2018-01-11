using SunSeven.DataSource;
using SunSeven.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for newOrder.xaml
    /// </summary>
    public partial class QuotationEditor : UserControl
    {
        JSDataContext lDataContext;
        public QuotationEditor()
        {
            InitializeComponent();

            this.DataContext = new HSQuotation();

            MainPage.CloseCommand -= MainPage_CloseCommand;
            MainPage.CloseCommand += MainPage_CloseCommand;
        }

        private MessageBoxResult MainPage_CloseCommand(string PageId)
        {

            MessageBoxResult lBoxResult = MessageBoxResult.None;

            HSQuotation lEdit = DataContext as HSQuotation;


            if (PageId.ToUpper().Contains("OPEN QUOTATION") || PageId.ToUpper().Contains("OPEN MASTER QUOTATION"))
            {
                if (lEdit.CustomerId != null && lEdit.CustomerId > 0)
                {
                    lBoxResult = MessageBox.Show("Please Save changes..", "Confirm Quotation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }

            }
            else
            {
                if (lEdit.CustomerId != null && lEdit.CustomerId > 0)
                {
                    lBoxResult = MessageBox.Show(" Yes : Save and Close\n No : Close without Save\n Cancel : Cancel Close", "Confirm Quotation",
                        MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                }

            }

            if (lBoxResult == MessageBoxResult.Yes)
            {
                if (lEdit.CustomerId != null && lEdit.CustomerId > 0)
                {
                    lEdit.SaveQuotation();
                }

            }
            return lBoxResult;
        }

        public QuotationEditor(int SalesId)
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();

            MainPage.CloseCommand -= MainPage_CloseCommand;
            MainPage.CloseCommand += MainPage_CloseCommand;


            HSQuotation lEditSales = new HSQuotation();

            DataSource.Sale lSales = lDataContext.Sales.SingleOrDefault(p => p.Id == SalesId);

            if (lSales != null)
            {

                lEditSales.Id = lSales.Id;
                lEditSales.CustomerId = lSales.CustomerId.Value;
                lEditSales.SelectedCustomer = lSales.Customer;
                lEditSales.SalesDate = lSales.SalesDate;
                lEditSales.SellerId = lSales.SellerId;
                lEditSales.Description = lSales.Description;
                //lEditSales.Order = lEditSales.Order;
                //lEditSales.Order = lSales.Order;
                lEditSales.IsMaster = lSales.Master;
                lEditSales.ExpireDate = lSales.ExpireDate;
                //lEditSales.SalesPerson = new HSEmployee { Id = lSales.Id, SelectedPerson = lSales.Employee.Person };

                lEditSales.DeleteEnabled = true;


                foreach (DataSource.SalesItem l in lSales.SalesItems)
                {
                    lEditSales.SalesItems.Add(new HSOrderItem
                    {
                        Id = l.Id,
                        CustomerId = lSales.CustomerId.Value,
                        OrderId = l.SalesId.Value,
                        ProductId = l.ProductId.Value,
                        SelectedProduct = l.Product,
                        UnitPrice = l.UnitPrice,
                        VatId = l.VatId,
                        SelectedVat = l.VatRate,
                        Quantity = l.Quantity,
                        SellingUnitId = l.SellingUnitId,
                        SelectedSellingUnit = l.SellingUnit,
                        ProductName = l.Product.Name,
                        ProductDescription = l.Product.Description,
                        VAT = l.VatRate.Name,
                        Unit = (l.SellingUnit == null) ? "NA" : l.SellingUnit.Unit,
                        Description = l.Description
                    });
                }

                this.DataContext = lEditSales;
            }

        }

        private void gridSalesItem_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            HSOrderItem lNewItem = new HSOrderItem();

            if (comboCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please Select Customer...");
                e.Cancel = true;
                return;
            }

            lNewItem.CustomerId = (comboCustomer.SelectedItem as DataSource.Customer).Id;
            lNewItem.SalesStatusId = 1;
            lNewItem.Quantity = 0;

            e.NewObject = lNewItem;
        }

        private void gridSalesItem_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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

        private void gridSalesItem_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            foreach (HSOrderItem l in e.Items)
            {
                if (l.Id < 0) continue;

                try
                {
                    DataSource.SalesItem lItem = lDataContext.SalesItems.SingleOrDefault<DataSource.SalesItem>(p => p.Id == l.Id);

                    lDataContext.SalesItems.DeleteOnSubmit(lItem);
                    lDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainPage.CloseCommand -= MainPage_CloseCommand;
        }
    }
}