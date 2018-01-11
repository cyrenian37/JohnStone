namespace SunSeven.Reports.ReportModel
{
    using System;
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for rptOrdercs.
    /// </summary>
    public partial class rptOrdercsByCustomer : Telerik.Reporting.Report
    {
        public rptOrdercsByCustomer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;
        }

        public rptOrdercsByCustomer(DateTime pST, DateTime pET)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;
            lparams[1].Value = pST;
            lparams[2].Value = pET;
        }
    }
}