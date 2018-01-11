using SunSeven.DataSource;
using SunSeven.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Input;
using Telerik.Reporting.Processing;
using Telerik.Windows.Controls;


namespace SunSeven.Models
{
    public class HSSupply : ViewModelBase
    {

        private HSInvoice _invoice;
        private int? _id;
        private int _customerId;
        private int? _delivererId;
        private int? _sellerId;
        private string _description;
        private DateTime? _supplyDate;


        private DataSource.Supplier _selectedSupplier;
        private DataSource.vEmpDept _selectedDeliverer;
        private DataSource.vEmpDept _selectedSeller;


        private ObservableCollection<HSSupplyItem> _supplyItems;

        private SunSeven.DataSource.JSDataContext lDataContext;

        private Boolean _buttonEnabled;
        private Boolean _deleteEnabled;
        private Boolean _isBusy;
        private String _message;

        public ICommand saveCommand { get; set; }
        public ICommand AddNewCommand { get; set; }
        public ICommand deleteCommand { get; set; }

        public ICommand printCommand { get; set; }
        public ICommand previewCommand { get; set; }

        public ICommand invoiceCommand { get; set; }

        public ICommand closeCommand { get; set; }


        public HSSupply()
        {

            lDataContext = new CommonFunction().JSDataContext();

            _supplyItems = new ObservableCollection<HSSupplyItem>();
            _invoice = new HSInvoice();

            this.saveCommand = new DelegateCommand(OnSaveCommandExecuted);
            this.AddNewCommand = new DelegateCommand(OnAddNewCommandExecuted);
            this.deleteCommand = new DelegateCommand(OnDeleteCommandExecuted);
            this.printCommand = new DelegateCommand(OnPrintCommandExecuted);
            this.previewCommand = new DelegateCommand(OnPreviewCommandExecuted);
            this.invoiceCommand = new DelegateCommand(OnInvoiceCommandExecuted);
            this.closeCommand = new DelegateCommand(OnCloseCommandExecuted);

            _invoice.InvoiceStatusId = 1;

            ButtonEnabled = false;
            DeleteEnabled = false;
            IsBusy = false;
            Foreground = "Blue";
        }

        private void OnCloseCommandExecuted(object id)
        {
        }

        public HSSupply(int SupplierId)
        {
            lDataContext = new CommonFunction().JSDataContext();

            _supplyItems = new ObservableCollection<HSSupplyItem>();
           // _invoice = new HSInvoice();

        }

        #region "Event"

        private string GetInvoiceNo()
        {
            //string lInvoiceNo = DateTime.Now.ToString("yyyyMMdd");
            string lInvoiceNo = DateTime.Now.ToString("yyMMdd");

            var InvoiceStr = (from p in lDataContext.Invoices
                              where p.InvoiceNo.Contains(lInvoiceNo)
                              orderby p.InvoiceNo descending
                              select p.InvoiceNo).Take(1);

            int InvoiceInt = 0;

            foreach (string l in InvoiceStr)
            {
                InvoiceInt = Convert.ToInt16(l.Substring(6));
            }

            return DateTime.Now.ToString("yyMMdd") + (InvoiceInt + 1).ToString("D3");

        }

        private void OnInvoiceCommandExecuted(object id)
        {
            Invoice.InvoiceNo = GetInvoiceNo();
        }

        private void OnSaveCommandExecuted(object id)
        {
            SaveOrder();
        }

        public void SaveOrder()
        {
            this.IsBusy = true;
            this.ButtonEnabled = false;
            SavingAsyncStart();

            DeleteEnabled = true;
        }

        private async void SavingAsyncStart()
        {
            var lReturn = await SavingAsync();

            if (this.Foreground == "Red")
                this.Foreground = "Blue";
            else
                this.Foreground = "Red";


            this.ButtonEnabled = true;
            this.IsBusy = lReturn;

        }

        private Task<Boolean> SavingAsync()
        {
            return Task.Factory.StartNew(() => SavingEnded());
        }


        private Boolean SavingEnded()
        {
            //System.Threading.Thread.Sleep(2000);


            DataSource.Invoice lInvoice = lDataContext.Invoices.SingleOrDefault(p => p.Id == this.Invoice.Id);


            if (lInvoice == null)
            {
                this.Invoice.InvoiceNo = GetInvoiceNo();

                DataSource.Invoice newInvoice = new DataSource.Invoice
                {
                    CustomerId = this.CustomerId,
                    InvoiceNo = this.Invoice.InvoiceNo,
                    InvoiceDate = this.Invoice.InvoiceDate,
                    DeliveryDate = this.Invoice.DeliveryDate,
                    Description = this.Invoice.Description,
                    Status = this.Invoice.InvoiceStatusId,
                    EmpDeliveryId = this.DelivererId
                };

                lDataContext.Invoices.InsertOnSubmit(newInvoice);

                try
                {
                    lDataContext.SubmitChanges();

                    this.Invoice.Id = newInvoice.Id;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Cannot insert duplicate Invoice No [" + this.Invoice.InvoiceNo + "] Please save again.");
                    }
                    else
                        MessageBox.Show("SqlException : " + ex.Message);

                    ChangeSet pendingChanges = lDataContext.GetChangeSet();

                    foreach (object obj in pendingChanges.Inserts)
                    {
                        var tableToDeleteFrom = lDataContext.GetTable(obj.GetType());
                        //(tableToDeleteFrom as DataSource.Invoice).InvoiceNo = GetInvoiceNo();

                        //lDataContext.SubmitChanges();

                        //this.Invoice.Id = newInvoice.Id;

                        tableToDeleteFrom.DeleteOnSubmit(obj);
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    this.Message = "Faled to Save - Invoice Detail";
                    return false;
                }
            }
            else
            {
                lInvoice.CustomerId = this.CustomerId;
                lInvoice.InvoiceNo = this.Invoice.InvoiceNo;
                lInvoice.InvoiceDate = this.Invoice.InvoiceDate;
                lInvoice.DeliveryDate = this.Invoice.DeliveryDate;
                lInvoice.Description = this.Invoice.Description;
                lInvoice.EmpDeliveryId = this.DelivererId;
                lInvoice.Status = this.Invoice.InvoiceStatusId;
                try
                {
                    lDataContext.SubmitChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Message = "Faled to Update - Invoice Detail";
                    return false;
                }
            }


            DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.Id == this.Id);

            if (lOrder == null)
            {
                DataSource.Order lnewOrder = new DataSource.Order
                {
                    CustomerId = this.CustomerId,
                    OrderDate = this.OrderDate.Value,
                    InvoiceId = (this.Invoice == null) ? null : this.Invoice.Id,
                    EmpDeliveryId = this.DelivererId,
                    EmployeeId = this.SellerId,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    Description = this.Description
                };


                lDataContext.Orders.InsertOnSubmit(lnewOrder);

                try
                {
                    lDataContext.SubmitChanges();
                    this.Id = lnewOrder.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Message = "Faled to Save - Order Detail";
                    return false;
                }

            }
            else
            {
                lOrder.CustomerId = this.CustomerId;
                lOrder.OrderDate = this.OrderDate.Value;
                lOrder.InvoiceId = this.Invoice.Id;
                lOrder.EmpDeliveryId = this.DelivererId;
                lOrder.EmployeeId = this.SellerId;
                lOrder.RequiredDate = DateTime.Now;
                lOrder.ShippedDate = DateTime.Now;
                lOrder.Description = this.Description;

                try
                {
                    lDataContext.SubmitChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Message = "Faled to Update - Order Detail";
                    return false;
                }
            }


            foreach (HSSupplyItem l in this.SupplyItems)
            {

                if (l.Id == -1 || l.Id == null)
                {
                    DataSource.OrderItem lDSOrderItem = new OrderItem();

                    lDSOrderItem.OrderId = this.Id.Value;
                    lDSOrderItem.SalesStatusId = l.SalesStatusId;
                    lDSOrderItem.ProductId = l.ProductId;
                    lDSOrderItem.VatId = l.VatId;
                    lDSOrderItem.UnitPrice = l.UnitPrice;
                    lDSOrderItem.Quantity = l.Quantity;
                    lDSOrderItem.SellingUnitId = (l.SellingUnitId == null) ? 0 : l.SellingUnitId;
                    lDSOrderItem.Description = l.Description;
                    lDataContext.OrderItems.InsertOnSubmit(lDSOrderItem);

                    try
                    {
                        lDataContext.SubmitChanges();
                        l.Id = lDSOrderItem.Id;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        this.Message = "Faled to Save - OrderItem Detail";
                        return false;
                    }
                }
                else
                {
                    DataSource.OrderItem lItem = lDataContext.OrderItems.SingleOrDefault(p => p.Id == l.Id);

                    lItem.OrderId = this.Id.Value;
                    lItem.SalesStatusId = l.SalesStatusId;
                    lItem.ProductId = l.ProductId;
                    lItem.VatId = l.VatId;
                    lItem.UnitPrice = l.UnitPrice;
                    lItem.Quantity = l.Quantity;
                    lItem.SellingUnitId = (l.SellingUnitId == null) ? 0 : l.SellingUnitId;
                    lItem.Description = l.Description;

                    try
                    {
                        lDataContext.SubmitChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        this.Message = "Faled to Update - OrderItem Detail";
                        return false;
                    }

                }

            }

            this.Message = "Saved Successfully...";

            return false;
        }


        private void OnDeleteCommandExecuted(object id)
        {

            var lWindows = Models.CommonFunction.GetApplicationWindow();

            if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                int ret = CommonFunction.DeleteOrder(this.Id);


                this.Id = -1;
                this.CustomerId = 0;
                this.SellerId = null;
                this.DelivererId = null;
                this.Invoice = new HSInvoice();
                this.Invoice.InvoiceStatusId = 1;
                this.SupplyItems = new ObservableCollection<HSSupplyItem>();

            }
        }

        private void OnPrintCommandExecuted(object id)
        {

            //Direct to default
            try
            {
                //if (this.Invoice.InvoiceNo == null || this.Invoice.InvoiceNo == string.Empty)
                //{
                //    MessageBox.Show("Please save first.");
                //    return;
                //}

                SaveOrder();

                ReportProcessor reportProcessor = new ReportProcessor();
                // reportProcessor.PrintReport(new SunSeven.Reports.ReportModel.rptInvoice(this, this.OrderItems), new PrinterSettings());
              //  reportProcessor.PrintReport(new SunSeven.Reports.ReportModel.Invoice(this, this.OrderItems), new PrinterSettings());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        private void OnPreviewCommandExecuted(object id)
        {
            //if (this.Invoice.InvoiceNo == null || this.Invoice.InvoiceNo == string.Empty)
            //{
            //    MessageBox.Show("Please save first.");
            //    return;
            //}

            SaveOrder();

            //SunSeven.Reports.ReportViewer lRptViewer = new Reports.ReportViewer(this, this.OrderItems);

            //Window lWindows = Models.CommonFunction.GetApplicationWindow();

            //if (lWindows != null)
            //    lRptViewer.Owner = lWindows;

            //lRptViewer.ShowDialog();
        }


        private void OnAddNewCommandExecuted(object id)
        {
            if (SelectedSupplier == null)
            {
                MessageBox.Show("Please select Customer first.");
                return;
            }


            //RadWindow productWin = new ProductWin();
            RadWindow productWin = new ProductWin(this.CustomerId);

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            //var lWindows = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains(""));
            productWin.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;

            //Point position = productWin.PointToScreen(new Point(0d, 0d)),
            //controlPosition = this.PointToScreen(new Point(0d, 0d));

            //position.X -= controlPosition.X;
            //position.Y -= controlPosition.Y;

            productWin.Top = 80;
            productWin.Left = 200;

            ProductWin.selecteProductCommand -= ProductWindow_selecteProductCommand;
            ProductWin.selecteProductCommand += ProductWindow_selecteProductCommand;

            if (lWindows != null)
                productWin.Owner = lWindows;

            productWin.Show();
        }

        void ProductWindow_selecteProductCommand(List<JSProduct> selectedProduct)
        {
            Decimal? lDefaultPrice = null;
            string unitName;

            foreach (JSProduct l in selectedProduct)
            {

                if (SelectedSupplier == null)
                    SupplyItems.Add(new HSSupplyItem { Id = -1, ProductId = l.Id, Quantity = 0, UnitPrice = 0, VatId = 1, SellingUnitId = 1 });
                else
                {
                    if (l.SelectedUnitId == null)
                    {
                        MessageBox.Show("Unit is empty");
                        return;
                    }

                    unitName = l.productUnits.Single(p => p.UnitId == l.SelectedUnitId).UnitName;

                    lDefaultPrice = lDataContext.getHistoryUnitPrice(SelectedSupplier.Id, l.Id, l.SelectedUnitId, this.Invoice.InvoiceDate);

                    SupplyItems.Add(new HSSupplyItem
                    {
                        Id = -1,
                        ProductId = l.Id,
                        CustomerId = SelectedSupplier.Id,
                        Quantity = 1,
                        UnitPrice = (lDefaultPrice == null) ? 0 : lDefaultPrice,
                        VatId = l.VAT.Id,
                        SellingUnitId = l.SelectedUnitId,
                        Unit = unitName,
                        VAT = l.VAT.Name,
                        SelectedVat = l.VAT,
                        ProductName = l.ProductName,
                        ProductDescription = l.Description,
                        Description = l.itemDescription


                    });
                }
            }
            //MessageBox.Show(selectedProduct.Category.Name);
        }



        #endregion

        private string _foreGround;
        public string Foreground
        {
            get
            {
                return _foreGround;
            }

            set
            {
                _foreGround = value;
                this.OnPropertyChanged(() => this.Foreground);
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                this.OnPropertyChanged(() => this.Message);
            }
        }
        public Boolean IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                this.OnPropertyChanged(() => this.IsBusy);
            }

        }
        public Boolean ButtonEnabled
        {
            get
            {
                return _buttonEnabled;
            }
            set
            {
                _buttonEnabled = value;

                this.OnPropertyChanged(() => this.ButtonEnabled);
            }
        }


        public Boolean DeleteEnabled
        {
            get
            {
                return _deleteEnabled;
            }
            set
            {
                _deleteEnabled = value;

                this.OnPropertyChanged(() => this.DeleteEnabled);
            }
        }

        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                this.OnPropertyChanged(() => this.Id);
            }
        }



        public int CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
                this.OnPropertyChanged(() => this.CustomerId);
            }
        }

        public DateTime? OrderDate
        {
            get
            {
                return _supplyDate;
            }
            set
            {
                _supplyDate = value;
                this.OnPropertyChanged(() => this.OrderDate);
            }
        }

        public int? DelivererId
        {
            get
            {
                return _delivererId;
            }
            set
            {
                _delivererId = value;
                this.OnPropertyChanged(() => this.DelivererId);
            }
        }

        public int? SellerId
        {
            get
            {
                return _sellerId;
            }
            set
            {
                _sellerId = value;
                this.OnPropertyChanged(() => this.SellerId);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                this.OnPropertyChanged(() => this.Description);
            }
        }


        public DataSource.Supplier SelectedSupplier
        {
            get
            {
                return _selectedSupplier;
            }
            set
            {
                _selectedSupplier = value;
                this.OnPropertyChanged(() => this.SelectedSupplier);

                if (_selectedSupplier != null)
                {
                    foreach (HSSupplyItem l in SupplyItems)
                    {
                        l.CustomerId = _selectedSupplier.Id;
                    }

                    this.OrderDate = DateTime.Now;


                    // Invoice.InvoiceNo = GetInvoiceNo();
                    Invoice.InvoiceDate = DateTime.Now;
                    Invoice.DeliveryDate = DateTime.Now;

                    ButtonEnabled = true;

                }

            }
        }

        public DataSource.vEmpDept SelectedDeliverer
        {
            get
            {
                return _selectedDeliverer;
            }
            set
            {
                _selectedDeliverer = value;
                this.OnPropertyChanged(() => this.SelectedDeliverer);


            }
        }

        public DataSource.vEmpDept SelectedSeller
        {
            get
            {
                return _selectedSeller;
            }
            set
            {
                _selectedSeller = value;
                this.OnPropertyChanged(() => this.SelectedSeller);


            }
        }

        public ObservableCollection<HSSupplyItem> SupplyItems
        {
            get
            {
                if (_supplyItems == null)
                    _supplyItems = new ObservableCollection<HSSupplyItem>();


                return _supplyItems;
            }
            set
            {
                _supplyItems = value;


                this.OnPropertyChanged(() => this.SupplyItems);
            }
        }

        public HSInvoice Invoice
        {
            get
            {
                return _invoice;
            }
            set
            {
                _invoice = value;

                this.OnPropertyChanged(() => this.Invoice);
            }
        }




    }

    //enum StatusType { Open=1, Close=2, Returned=3 PartialReturned=4};

}
