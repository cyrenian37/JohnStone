namespace SunSeven.Reports.ReportModel
{
    using System;
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for rptOrdercs.
    /// </summary>
    public partial class rptOrdercs : Telerik.Reporting.Report
    {
        public rptOrdercs()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;
        }

        public rptOrdercs(DateTime pST, DateTime pET)
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