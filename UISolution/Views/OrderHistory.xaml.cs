using Microsoft.Win32;
using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class OrderHistory : UserControl
    {
        private DataSource.JSDataContext lDataContext;

        public delegate void selectedOrderHistory(int? orderId);

        static public event selectedOrderHistory selectedOrderHistoryCommand;

        static int PageIndex = -1;
        static DateTime? PageST;
        static DateTime? PageET;

        private int PageIndexAlreadySet = 0;

        public OrderHistory()
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();

        }


        private void RadGridView1_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        {
            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows == null)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        foreach (HSOrderHistory l in e.Items)
                        {
                            CommonFunction.DeleteOrder(l.OrderId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Cancel = true;
                    }

                }
            }
            else
            {
                if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                           MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        foreach (HSOrderHistory l in e.Items)
                        {
                            CommonFunction.DeleteOrder(l.OrderId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Cancel = true;
                    }

                }
            }

        }

        private void RadGridView1_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            SunSeven.Models.HSOrderHistory lOrderHistory = e.EditedItem as SunSeven.Models.HSOrderHistory;

            DataSource.Order lOrder = lDataContext.Orders.FirstOrDefault(p => p.Id == lOrderHistory.OrderId);

            if (lOrder != null)
            {
                try
                {
                    lOrder.EmpDeliveryId = lOrderHistory.DeliveryPersonId;
                    lOrder.EmployeeId = lOrderHistory.SalesPersonId;

                    DataSource.Invoice lInvoice = lDataContext.Invoices.Single(p => p.Id == lOrder.InvoiceId);

                    if (lInvoice != null)
                    {
                        lInvoice.DeliveryDate = lOrderHistory.DeliveryDate;
                        lInvoice.EmpDeliveryId = lOrderHistory.DeliveryPersonId;
                        lInvoice.Description = lOrderHistory.Description;
                        lDataContext.SubmitChanges();
                    }
                                     
                    if (lOrder != null)
                    {
                        lOrder.Description = lOrderHistory.InternalComment;
                        lDataContext.SubmitChanges();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => AfterRendered()), DispatcherPriority.ContextIdle, null);

        }

        private void AfterRendered()
        {

           this.DataContext = new vmOrderHistory(1, PageST, PageET);                       
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
                        HSOrderHistory lOrderHistory = row.Item as HSOrderHistory;

                        if (selectedOrderHistoryCommand != null)
                        {
                            selectedOrderHistoryCommand(lOrderHistory.OrderId);
                            PageST = this.dtPickerST.SelectedValue;
                            PageET = this.dtPickerET.SelectedValue;

                        }

                        break;
                    case "Delete":

                        break;
                    default:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string extension = "xls";
            SaveFileDialog dialog = new SaveFileDialog()
            {
                DefaultExt = extension,
                Filter = String.Format("{1} files (*.{0})|*.{0}|All files (*.*)|*.*", extension, "Excel"),
                FilterIndex = 1
            };

            try
            {
                if (dialog.ShowDialog() == true)
                {
                    radDataPager1.PageSize = 0;
                    using (Stream stream = dialog.OpenFile())
                    {
                        RadGridView1.Export(stream,
                         new GridViewExportOptions()
                         {
                             Format = ExportFormat.Html,
                             ShowColumnHeaders = true,
                             ShowColumnFooters = true,
                             ShowGroupFooters = false,
                         });
                    }

                    radDataPager1.PageSize = 18;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            PageIndex = radDataPager1.PageIndex;
        }

        private void RadGridView1_DataLoaded(object sender, EventArgs e)
        {
            if (PageIndexAlreadySet == 1)
                return;

            if (PageIndex >= 0)
            {
                radDataPager1.PageIndex = PageIndex;
                PageIndexAlreadySet = 1;
            }
        }


    }
}

