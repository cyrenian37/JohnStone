namespace SunSeven.Reports.ReportModel
{
    using System;
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for rptOrdercs.
    /// </summary>
    public partial class rptDeliveryByEmp : Telerik.Reporting.Report
    {
        public rptDeliveryByEmp()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;
            textCompany.Value = Models.CommonFunction.GetCompanyInfo().CompanyName;
        }

        public rptDeliveryByEmp(DateTime pST, DateTime pET)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            textCompany.Value = Models.CommonFunction.GetCompanyInfo().CompanyName;
            lparams[0].Value = Environment.MachineName;
            lparams[1].Value = pST;
            lparams[2].Value = pET;

        }
    }
}