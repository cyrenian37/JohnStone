using SunSeven.Models;
using System;
using System.Collections.ObjectModel;
using Telerik.Reporting;

namespace SunSeven.Reports.ReportModel
{


    /// <summary>
    /// Summary description for rptInvoice.
    /// </summary>
    public partial class rptQuotation : Telerik.Reporting.Report
    {
        public rptQuotation()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;

            this.textBox2.Value = Models.CommonFunction.GetCompanyInfo().CompanyName;

            SunSeven.DataSource.CompanyInfo lCompanyInfo = Models.CommonFunction.GetCompanyInfo();

            this.textBox2.Value = lCompanyInfo.CompanyName;

            string lComanynDetail = lCompanyInfo.Address;
            lComanynDetail += "\n\nEmail : " + lCompanyInfo.Email;
            lComanynDetail += "\nVAT NO : " + lCompanyInfo.VATNo;
            lComanynDetail += "\nTEL : " + lCompanyInfo.Phone;
            lComanynDetail += "\nMobile : " + lCompanyInfo.FAX;

            this.txtTerm.Value = lCompanyInfo.TermCondition;

            this.txtCompanyInfo.Value = lComanynDetail;

        }

        public rptQuotation(HSQuotation lOrder, ObservableCollection<HSOrderItem> lOrderItems)
        {

            InitializeComponent();

            ReportParameterCollection lparams = this.ReportParameters;

            lparams[0].Value = Environment.MachineName;

            this.oDSSales.DataSource = lOrder;
            this.oDSSalesItems.DataSource = lOrderItems;

            SunSeven.DataSource.CompanyInfo lCompanyInfo = Models.CommonFunction.GetCompanyInfo();

            this.textBox2.Value = lCompanyInfo.CompanyName;

            string lComanynDetail = lCompanyInfo.Address;
            lComanynDetail += "\n\nEmail : " + lCompanyInfo.Email;
            lComanynDetail += "\nVAT NO : " + lCompanyInfo.VATNo;
            lComanynDetail += "\nTEL : " + lCompanyInfo.Phone;
            lComanynDetail += "\nMobile : " + lCompanyInfo.FAX;

            this.txtTerm.Value = lCompanyInfo.TermCondition;

            this.txtCompanyInfo.Value = lComanynDetail;
          

        }
    }
}