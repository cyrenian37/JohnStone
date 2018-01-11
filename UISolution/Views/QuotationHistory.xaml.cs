using Microsoft.Win32;
using SunSeven.DataSource;
using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.IO;
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
    public partial class QuotationHistory : UserControl
    {
        private DataSource.JSDataContext lDataContext;

        public delegate void selectedQuotationHistory(int orderId);

        static public event selectedQuotationHistory selectedQuotationHistoryCommand;

        public QuotationHistory()
        {
            InitializeComponent();

            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            //this.DataContext = new vmSalesHistory();
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
                        foreach (HSQuotationHistory l in e.Items)
                        {
                            CommonFunction.DeleteSales(l.SalesId);
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
                        foreach (HSQuotationHistory l in e.Items)
                        {
                            CommonFunction.DeleteSales(l.SalesId);
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


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => AfterRendered()), DispatcherPriority.ContextIdle, null);
        }

        private void AfterRendered()
        {
            this.DataContext = new vmQuotationHistory(1);
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
                        HSQuotationHistory lQuotation = row.Item as HSQuotationHistory;

                        if (selectedQuotationHistoryCommand != null)
                        {
                            selectedQuotationHistoryCommand(lQuotation.SalesId);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
