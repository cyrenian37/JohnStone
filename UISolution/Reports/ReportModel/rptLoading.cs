namespace SunSeven.Reports.ReportModel
{
    using System;
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for rptLoading.
    /// </summary>
    public partial class rptLoading : Telerik.Reporting.Report
    {
        public rptLoading()
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