namespace SunSeven.Reports.ReportModel
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ProductByCustomer.
    /// </summary>
    public partial class OrderByProduct : Telerik.Reporting.Report
    {
        public OrderByProduct()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;

            this.textCompany.Value = Models.CommonFunction.GetCompanyInfo().CompanyName;
        }
    }
}