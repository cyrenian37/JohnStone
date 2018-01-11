using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using SunSeven.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for ScanEditor.xaml
    /// </summary>
    /// 
    public partial class ScanEditor : UserControl
    {
        public delegate void scannedOrderHanlder(int orderId);

        static public event scannedOrderHanlder scannedOrderCommand;

        static ObservableCollection<DataSource.Invoice> invoiceSet = new ObservableCollection<DataSource.Invoice>();

        public ICommand editCommand { get; set; }

        SunSeven.DataSource.JSDataContext lDataContext;
        public ScanEditor()
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();
            
            DataContext = invoiceSet;
           
            MainPage.scanCommand -= MainPage_scanCommand;
            MainPage.scanCommand += MainPage_scanCommand;

            //this.RadGridView1.MouseDoubleClick += this.OnGridMouseDoubleClick;
        }

        void OnGridMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            FrameworkElement originalSender = e.OriginalSource as FrameworkElement;

            if (originalSender != null)
            {
                DataSource.Invoice lSelectedInvoice = originalSender.DataContext as DataSource.Invoice;

                if (lSelectedInvoice != null)
                {
                    DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.InvoiceId == lSelectedInvoice.Id);

                    if (lOrder == null)
                    {
                        MessageBox.Show("Failed to find Order Id [" + lSelectedInvoice.Id + "]");
                        return;
                    }

                    scannedOrderCommand?.Invoke(lOrder.Id);
                }
            }
           
        }

        private void MainPage_scanCommand(string invoiceNo)
        {
            scanInvoiceNo(invoiceNo);          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            scanInvoiceNo(txtInvoiceNo.Text);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
           invoiceSet.Clear();
        }

        private int saveInvoiceStatus(string invoiceNo)
        {
            DataSource.Invoice lInvoice = lDataContext.Invoices.SingleOrDefault(p => p.InvoiceNo == invoiceNo);
                   
            try
            {
                lInvoice.Status = 3;  // Returned

                lDataContext.SubmitChanges();

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Status : Can not find Invoice No [" + invoiceNo + "]");
                //MessageBox.Show(ex.Message);   
                return -1;            
            }

        }

        private void scanInvoiceNo(string invoiceNo)
        {
            if (saveInvoiceStatus(invoiceNo) < 0)
                return;

            DataSource.Invoice findInvoice = invoiceSet.SingleOrDefault<DataSource.Invoice>(p => p.InvoiceNo == invoiceNo);

            if (findInvoice != null)
            {
                MessageBox.Show("Already Scanned [" + invoiceNo + "]");
                return;
            }

            DataSource.Invoice lInvoice = lDataContext.Invoices.SingleOrDefault(p => p.InvoiceNo == invoiceNo);

          
            if (lInvoice == null)
            {
                MessageBox.Show("Scan : Can not find Invoice No [" + invoiceNo + "]");
                return;
            }

            DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.InvoiceId == lInvoice.Id);

            invoiceSet.Add(new DataSource.Invoice
            {
                Id = lInvoice.Id,
                InvoiceNo = lInvoice.InvoiceNo,
                DeliveryDate = lInvoice.DeliveryDate,
                Description = lOrder.Description,
                Status = lInvoice.Status
            });
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainPage.scanCommand -= MainPage_scanCommand;
        }

        private void RadGridView1_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            DataSource.Invoice gridInvoice = e.NewData as DataSource.Invoice;

            DataSource.Order orgOrder = lDataContext.Orders.Single(p => p.InvoiceId == gridInvoice.Id);
            DataSource.Invoice orgInvoice = lDataContext.Invoices.Single(p => p.Id  == gridInvoice.Id);

            if (orgOrder != null)
            {
                orgOrder.Description = gridInvoice.Description;
                orgInvoice.Status = gridInvoice.Status;

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

        private void GridContextMenu_ItemClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadContextMenu menu = (RadContextMenu)sender;
            RadMenuItem clickedItem = e.OriginalSource as RadMenuItem;
            GridViewRow row = menu.GetClickedElement<GridViewRow>();

            if (clickedItem != null && row != null)
            {
                string header = Convert.ToString(clickedItem.Header);

                switch (header)
                {
                    case "Add":

                        break;
                    case "Edit":
                        
                        DataSource.Invoice lSelectedInvoice = row.Item as DataSource.Invoice;

                        if (lSelectedInvoice != null)
                        {
                            DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.InvoiceId == lSelectedInvoice.Id);

                            if (lOrder == null)
                            {
                                MessageBox.Show("Failed to find Order Id [" + lSelectedInvoice.Id + "]");
                                return;
                            }

                            scannedOrderCommand?.Invoke(lOrder.Id);
                        }

                        break;
                    case "Delete":

                        break;
                    default:
                        break;
                }
            }
        }

    }
}
