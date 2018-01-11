using SunSeven.Models;
using System;
using System.Collections.ObjectModel;
using Telerik.Reporting;

namespace SunSeven.Reports.ReportModel
{


    /// <summary>
    /// Summary description for rptInvoice.
    /// </summary>
    public partial class rptInvoice : Telerik.Reporting.Report
    {
        public rptInvoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;



        }

        public rptInvoice(HSOrder lOrder, ObservableCollection<HSOrderItem> lOrderItems)
        {

            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;

            this.oDSOrder.DataSource = lOrder;
            this.oDSOrderItems.DataSource = lOrderItems;


            this.textBox2.Value = Models.CommonFunction.GetCompanyInfo().CompanyName;


        }
    }
}