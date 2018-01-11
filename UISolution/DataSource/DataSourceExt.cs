
namespace SunSeven.DataSource
{
    public partial class Product
    {
        private string _productDetail;
        public string ProductDetail
        {
            get
            {
                return this.Name + " (" + this.Category.Name + ")";

            }
            //set
            //{
            //    if ((this._productDetail != value))
            //    {
            //        this.SendPropertyChanging();
            //        this._productDetail = value;
            //        this.SendPropertyChanged("ProductDetail");
            //    }
            //}
        }
    }

    public partial class Customer
    {
        private string _customerDetail;
        public string CustomerDetail
        {
            get
            {
                return this.Name + " (" + this.CompanyName + ")";
            }

            //set
            //{
            //    if ((this._customerDetail != value))
            //    {
            //        this.SendPropertyChanging();
            //        this._customerDetail = value;
            //        this.SendPropertyChanged("CustomerDetail");
            //    }
            //}

        }
    }

    public partial class Employee
    {
        public string EmpDetail
        {
            get
            {
                return this.Person.PersonDetail;
            }
        }
    }

    public partial class Person
    {
        public string PersonDetail
        {
            get
            {
                return this.LastName + "," + this.FirstName;
            }
        }
    }

    //public partial class Order
    //{
    //    public ICommand printCommand { get; set; }

    //    public Order(int id)
    //    {
    //        this.printCommand = new DelegateCommand(OnPrintCommandExecuted);
    //    }
    //    private void OnPrintCommandExecuted(object Order)
    //    {                          
    //        SunSeven.Reports.ReportViewer lRptViewer = new Reports.ReportViewer(this, this.OrderItems);

    //        var lWindows = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains("John Stone Vegetable"));

    //        if (lWindows != null)
    //            lRptViewer.Owner = lWindows;

    //        lRptViewer.ShowDialog();


    //        //open print dialog
    //        //using (PrintDialog printDlg = new PrintDialog())
    //        //{
    //        //    printDlg.AllowSomePages = true;
    //        //    printDlg.AllowCurrentPage = false;
    //        //    printDlg.UseEXDialog = true;

    //        //    if (System.Windows.Forms.DialogResult.OK == printDlg.ShowDialog())
    //        //    {
    //        //        ReportProcessor reportProcessor1 = new ReportProcessor();
    //        //        reportProcessor1.PrintReport(new SunSeven.Reports.ReportModel.rptInvoice(this, this.OrderItems), printDlg.PrinterSettings);
    //        //    }
    //        //}




    //        //Direct to default
    //        //try
    //        //{
    //        //    ReportProcessor reportProcessor = new ReportProcessor();
    //        //    reportProcessor.PrintReport(new SunSeven.Reports.ReportModel.rptInvoice(this, this.OrderItems), new PrinterSettings());
    //        //}
    //        //catch(Exception e)
    //        //{
    //        //    MessageBox.Show(e.Message);
    //        //}

    //    }
    //}
}
