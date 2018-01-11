using SunSeven.Models;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.ViewModels
{

    public class vmCommon : commandCollection
    {


        public vmCommon()
        {
            this.printOrderCommand = new DelegateCommand(OnPrintOrderCommandExecuted);
        }

        public ICommand printOrderCommand { get; set; }

        private void OnPrintOrderCommandExecuted(object Order)
        {
            DataSource.Order lOrder = Order as DataSource.Order;

            HSOrder lhsOrder = new HSOrder();

            SunSeven.Reports.ReportViewer lRptViewer = new Reports.ReportViewer(lhsOrder, lhsOrder.OrderItems);

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows != null)
                lRptViewer.Owner = lWindows;

            lRptViewer.ShowDialog();


            //open print dialog
            //using (PrintDialog printDlg = new PrintDialog())
            //{
            //    printDlg.AllowSomePages = true;
            //    printDlg.AllowCurrentPage = false;
            //    printDlg.UseEXDialog = true;

            //    if (System.Windows.Forms.DialogResult.OK == printDlg.ShowDialog())
            //    {
            //        ReportProcessor reportProcessor1 = new ReportProcessor();
            //        reportProcessor1.PrintReport(new SunSeven.Reports.ReportModel.rptInvoice(this, this.OrderItems), printDlg.PrinterSettings);
            //    }
            //}




            //Direct to default
            //try
            //{
            //    ReportProcessor reportProcessor = new ReportProcessor();
            //    reportProcessor.PrintReport(new SunSeven.Reports.ReportModel.rptInvoice(this, this.OrderItems), new PrinterSettings());
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}

        }

    }
}
