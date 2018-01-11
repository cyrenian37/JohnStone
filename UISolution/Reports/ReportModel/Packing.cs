namespace SunSeven.Reports.ReportModel
{
    using System;
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for Packaging.
    /// </summary>
    public partial class Packing : Telerik.Reporting.Report
    {
        public Packing()
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