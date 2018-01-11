using Microsoft.PointOfService;
using SunSeven.DataSource;
using SunSeven.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for newOrder.xaml
    /// </summary>
    public partial class SupplyEditor : UserControl
    {
        //private PosExplorer devExplorer;
        private Scanner activeScanner;

        public delegate void closeWindowHander(int Action);

        static public event closeWindowHander closeWindowCommand;


        public SupplyEditor()
        {
            InitializeComponent();
            this.DataContext = new HSOrder();


            MainPage.CloseCommand -= MainPage_CloseCommand;
            MainPage.CloseCommand += MainPage_CloseCommand;

            this.comboStatus.IsEnabled = false;

            if (MainPage.lCurrentUser.UserRole.Name == "Admin")
                this.comboStatus.IsEnabled = true;

        }

        private MessageBoxResult MainPage_CloseCommand(string PageId)
        {
            MessageBoxResult lBoxResult = MessageBoxResult.None;

            HSOrder lEdit = DataContext as HSOrder;

            if (PageId.ToUpper().Contains("OPEN SUPPLY"))
            {
                if (lEdit.CustomerId != null && lEdit.CustomerId > 0)
                {
                    lBoxResult = MessageBox.Show("Please Save changes..", "Confirm Order", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            else
            {
                if (lEdit.CustomerId != null && lEdit.CustomerId > 0)
                {
                    lBoxResult = MessageBox.Show(" Yes : Save and Close\n No : Close without Save\n Cancel : Cancel Close", "Confirm Order"
                        , MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                }
            }

            if (lBoxResult == MessageBoxResult.Yes)
            {
                if (lEdit.CustomerId != null && lEdit.CustomerId > 0)
                {
                    lEdit.SaveOrder();
                }

            }

            return lBoxResult;
        }

        public SupplyEditor(int? SupplyId)
        {
            InitializeComponent();

            this.comboStatus.IsEnabled = false;

            if (MainPage.lCurrentUser.UserRole.Name == "Admin")
                this.comboStatus.IsEnabled = true;

            MainPage.CloseCommand -= MainPage_CloseCommand;
            MainPage.CloseCommand += MainPage_CloseCommand;

            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            HSSupply lEditOrder = new HSSupply();
            //HSInvoice lInvoice = new HSInvoice();

            DataSource.Supply lSupply = lDataContext.Supplies.SingleOrDefault(p => p.Id == SupplyId);

            if (lSupply != null)
            {

                lEditOrder.Id = lSupply.Id;
                lEditOrder.CustomerId = lSupply.SupplierId;
                lEditOrder.SelectedSupplier = lSupply.Supplier;
                lEditOrder.OrderDate = lSupply.SupplyDate;
                lEditOrder.SellerId = lSupply.EmployeeId;

                lEditOrder.Description = lSupply.Description;


                //if (lOrder.Invoice != null)
                //{
                //    lInvoice.Id = lOrder.Invoice.Id;
                //    lInvoice.InvoiceNo = lOrder.Invoice.InvoiceNo;
                //    lInvoice.InvoiceDate = lOrder.Invoice.InvoiceDate;
                //    lInvoice.DeliveryDate = lOrder.Invoice.DeliveryDate;
                //    lEditOrder.DelivererId = lOrder.Invoice.EmpDeliveryId;
                //    lInvoice.Description = lOrder.Invoice.Description;
                //    lEditOrder.Invoice = lInvoice;
                //    lInvoice.InvoiceStatusId = lOrder.Invoice.Status;
                //}


                lEditOrder.DeleteEnabled = true;


                foreach (DataSource.SupplyItem l in lSupply.SupplyItems)
                {
                    lEditOrder.SupplyItems.Add(new HSSupplyItem
                    {
                        Id = l.Id,
                        CustomerId = lSupply.SupplierId,
                        OrderId = l.SupplyId,
                        SalesStatusId = l.SalesStatusId,
                        ProductId = l.ProductId,
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
                        Unit = l.SellingUnit.Unit,
                        Description = l.Description
                    });
                }

                this.DataContext = lEditOrder;
            }


        }

        private void gridOrderItem_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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


        private void gridOrderItem_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            foreach (HSOrderItem l in e.Items)
            {
                if (l.Id < 0) continue;

                try
                {
                    DataSource.OrderItem lItem = lDataContext.OrderItems.SingleOrDefault<DataSource.OrderItem>(p => p.Id == l.Id);

                    lDataContext.OrderItems.DeleteOnSubmit(lItem);
                    lDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void gridOrderItem_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            if (e.EditAction == GridViewEditAction.Cancel) return;

            HSSupply lOrder = comboSupplier.SelectedItem as HSSupply;

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainPage.CloseCommand -= MainPage_CloseCommand;
        }



    }
}