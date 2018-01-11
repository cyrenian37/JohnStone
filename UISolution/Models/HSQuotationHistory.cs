using System;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{
    public class HSQuotationHistory
    {
        public ICommand printCommand { get; set; }
        public ICommand selectCommand { get; set; }



        public HSQuotationHistory()
        {
            this.selectCommand = new DelegateCommand(OnSelectCommandExecuted);
            this.printCommand = new DelegateCommand(OnPrintCommandExecuted);
            // this.SalesEmp = new DataSource.Person();
        }

        private void OnSelectCommandExecuted(object id)
        {

        }


        private void OnPrintCommandExecuted(object Param)
        {
            HSQuotationHistory lSalesHistory = Param as HSQuotationHistory;

            HSQuotation lEditOrder = CommonFunction.PrintSales(lSalesHistory.SalesId);

            SunSeven.Reports.ReportViewer lRptViewer = new Reports.ReportViewer(lEditOrder, lEditOrder.SalesItems);

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows != null)
                lRptViewer.Owner = lWindows;

            lRptViewer.ShowDialog();

        }



        public int SalesId { get; set; }

        public string CustomerDetail { get; set; }
        public DateTime? SalesDate { get; set; }

        public Boolean Master { get; set; }



        public String SalesPerson
        {
            get;
            set;
        }


        public string Description { get; set; }

        public decimal? TotalVAT { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
