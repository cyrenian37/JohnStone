using SunSeven.Models;
using SunSeven.Reports.ReportModel;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace SunSeven.Reports
{


    public partial class ReportViewer : RadWindow
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public ReportViewer(HSOrder lOrder, ObservableCollection<HSOrderItem> lOrderItems)
        {
            InitializeComponent();

            Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();
            reportSource.ReportDocument = new ReportModel.Invoice(lOrder, lOrderItems);


            // Assigning the report to the report viewer.
            DefaultViewer.ReportSource = reportSource;

            this.Header = "Invoice Report";

        }

        public ReportViewer(HSQuotation lSales, ObservableCollection<HSOrderItem> lOrderItems)
        {
            InitializeComponent();

            Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();
            reportSource.ReportDocument = new rptQuotation(lSales, lOrderItems);

            // Assigning the report to the report viewer.
            DefaultViewer.ReportSource = reportSource;
            this.Header = "Quotation Report";

        }

        public ReportViewer(int ReportType)
        {
            InitializeComponent();

            Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();

            switch (ReportType)
            {
                case 1:
                    reportSource.ReportDocument = new Reports.ReportModel.Order();
                    this.Header = "Daily Order";
                    break;
                case 2:
                    reportSource.ReportDocument = new DeliveryList();
                    this.Header = "Delivery List";
                    break;
                case 3:
                    reportSource.ReportDocument = new rptOrdercsByCustomer();
                    this.Header = "Order By Customer";
                    break;
                case 4:
                    reportSource.ReportDocument = new Packing();
                    this.Header = "Packaging List";
                    break;
                case 5:
                    reportSource.ReportDocument = new rptLoading();
                    this.Header = "Packaging By Delivery Person";
                    break;
                case 6:
                    reportSource.ReportDocument = new OrderByProduct();
                    this.Header = "Product Delivery List";
                    break;
                case 7:
                    reportSource.ReportDocument = new ProductByCustomer();
                    this.Header = "Customer Order Sum";
                    break;
                case 8:
                    reportSource.ReportDocument = new SumProduct();
                    this.Header = "Product Sum";
                    break;
                case 9:
                    reportSource.ReportDocument = new ProductList();
                    this.Header = "Report By Customer 2";
                    break;
            }
            // Assigning the report to the report viewer.
            DefaultViewer.ReportSource = reportSource;


            //Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();
            //reportSource.ReportDocument = new rptOrdercs();

            //// Assigning the report to the report viewer.
            //DefaultViewer.ReportSource = reportSource;

        }

        public void ReportInitialize(int ReportType)
        {

            Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();

            switch (ReportType)
            {
                case 1:
                    reportSource.ReportDocument = new rptDeliveryByDate();
                    this.Header = "Delivery By Date";
                    break;
                case 2:
                    reportSource.ReportDocument = new rptDeliveryByEmp();
                    this.Header = "Delivery By Employee";
                    break;
                case 3:
                    reportSource.ReportDocument = new rptOrdercsByCustomer();
                    this.Header = "Order By Customer";
                    break;
                case 4:
                    reportSource.ReportDocument = new rptLoading();
                    this.Header = "Packaging By Date";
                    break;

            }
            // Assigning the report to the report viewer.
            DefaultViewer.ReportSource = reportSource;

        }

    }
}