using SunSeven.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Telerik.Reporting.Processing;
using Telerik.Windows.Controls;


namespace SunSeven.Models
{
    public class HSQuotation : ViewModelBase
    {

        private HSOrder _order;
        private int _id;
        private int _customerId;
        private int? _delivererId;
        private int? _sellerId;
        private DateTime? _salesDate;
        private DateTime? _expireDate;
        private string _description;
        private DataSource.vEmpDept _salesPerson;

        private DataSource.Customer _selectedCustomer;
        private ObservableCollection<HSOrderItem> _salesItems;

        private SunSeven.DataSource.JSDataContext lDataContext;

        private Boolean _buttonEnabled;
        private Boolean _isBusy;
        private String _message;
        private string _foreGround;
        private Boolean _isMaster;

        public ICommand saveCommand { get; set; }
        public ICommand AddNewCommand { get; set; }
        public ICommand deleteCommand { get; set; }

        public ICommand printCommand { get; set; }
        public ICommand previewCommand { get; set; }

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
            get;
            set;
        }

        public HSQuotation()
        {
            lDataContext = new CommonFunction().JSDataContext();


            this.saveCommand = new DelegateCommand(OnSaveCommandExecuted);
            this.AddNewCommand = new DelegateCommand(OnAddNewCommandExecuted);
            this.deleteCommand = new DelegateCommand(OnDeleteCommandExecuted);
            this.printCommand = new DelegateCommand(OnPrintCommandExecuted);
            this.previewCommand = new DelegateCommand(OnPreviewCommandExecuted);

            _salesItems = new ObservableCollection<HSOrderItem>();

            ButtonEnabled = false;
            DeleteEnabled = false;
            this.Foreground = "Blue";
        }

        #region "Event"


        private void OnSaveCommandExecuted(object id)
        {
            SaveQuotation();
        }

        public void SaveQuotation()
        {
            this.IsBusy = true;

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

            this.Message = "Saved Successfully...";
            this.IsBusy = lReturn;

        }

        private Task<Boolean> SavingAsync()
        {
            return Task.Factory.StartNew(() => SavingEnded());
        }


        private Boolean SavingEnded()
        {

            DataSource.Sale lSales = lDataContext.Sales.SingleOrDefault(p => p.Id == this.Id);

            if (lSales == null)
            {
                DataSource.Sale newSales = new DataSource.Sale
                {
                    CustomerId = this.CustomerId,
                    SalesDate = this.SalesDate.Value,
                    SellerId = this.SellerId,
                    Description = this.Description,
                    Master = this.IsMaster,
                    ExpireDate = this.ExpireDate

                };

                lDataContext.Sales.InsertOnSubmit(newSales);

                try
                {
                    lDataContext.SubmitChanges();
                    this.Id = newSales.Id;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                lSales.CustomerId = this.CustomerId;
                lSales.SalesDate = this.SalesDate.Value;
                lSales.SellerId = this.SellerId;
                lSales.Description = this.Description;
                lSales.Master = this.IsMaster;
                lSales.ExpireDate = this.ExpireDate;

                try
                {
                    lDataContext.SubmitChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }




            foreach (HSOrderItem l in this.SalesItems)
            {

                if (l.Id == -1 || l.Id == null)
                {
                    DataSource.SalesItem lDSSalesItem = new DataSource.SalesItem();

                    lDSSalesItem.SalesId = this.Id;
                    lDSSalesItem.ProductId = l.ProductId;
                    lDSSalesItem.VatId = l.VatId;
                    lDSSalesItem.UnitPrice = l.UnitPrice;
                    lDSSalesItem.Quantity = l.Quantity;
                    lDSSalesItem.SellingUnitId = (l.SellingUnitId == null) ? 0 : l.SellingUnitId;
                    lDSSalesItem.Description = l.Description;
                    lDataContext.SalesItems.InsertOnSubmit(lDSSalesItem);

                    try
                    {
                        lDataContext.SubmitChanges();
                        l.Id = lDSSalesItem.Id;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    DataSource.SalesItem lItem = lDataContext.SalesItems.SingleOrDefault(p => p.Id == l.Id);

                    lItem.SalesId = this.Id;
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
                    }

                }


            }


            return false;
        }

        private void OnDeleteCommandExecuted(object id)
        {
            var lWindows = Models.CommonFunction.GetApplicationWindow();

            if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                int ret = CommonFunction.DeleteSales(this.Id);

                if (ret == 0)
                {
                    this.Id = -1;
                    this.CustomerId = 0;
                    this.SellerId = null;
                    this.DelivererId = null;

                    this.SalesItems = new ObservableCollection<HSOrderItem>();
                }

            }
        }

        private void OnPrintCommandExecuted(object id)
        {

            try
            {
                SaveQuotation();

                ReportProcessor reportProcessor = new ReportProcessor();
                reportProcessor.PrintReport(new SunSeven.Reports.ReportModel.rptQuotation(this, this.SalesItems), new PrinterSettings());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnPreviewCommandExecuted(object id)
        {

            SaveQuotation();

            SunSeven.Reports.ReportViewer lRptViewer = new Reports.ReportViewer(this, this.SalesItems);

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows != null)
                lRptViewer.Owner = lWindows;

            lRptViewer.ShowDialog();


        }

        private void OnAddNewCommandExecuted(object id)
        {
            if (SelectedCustomer == null)
            {
                MessageBox.Show("Please select Customer first.");
                return;
            }

            RadWindow productWin = new ProductWin();

            //var lWindows = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains("John Stone Vegetable"));

            Window lWindows = Models.CommonFunction.GetApplicationWindow();
            productWin.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;

            ProductWin.selecteProductCommand -= ProductWindow_selecteProductCommand;
            ProductWin.selecteProductCommand += ProductWindow_selecteProductCommand;

            if (lWindows != null)
                productWin.Owner = lWindows;

            productWin.ShowDialog();
        }

        void ProductWindow_selecteProductCommand(List<JSProduct> selectedProduct)
        {
            foreach (JSProduct l in selectedProduct)
            {
                HSOrderItem lOrderItem = new HSOrderItem();
                lOrderItem.Id = -1;
                lOrderItem.ProductId = l.Id;
                lOrderItem.CustomerId = SelectedCustomer.Id;
                lOrderItem.Quantity = 1;
                lOrderItem.UnitPrice = 0;
                lOrderItem.VatId = l.VAT.Id;
                lOrderItem.SellingUnitId = l.SelectedUnitId;
                lOrderItem.Unit = (l.SelectedUnitId == null) ? String.Empty : l.productUnits.Single(p => p.UnitId == l.SelectedUnitId).UnitName;
                lOrderItem.VAT = l.VAT.Name;
                lOrderItem.SelectedVat = l.VAT;
                lOrderItem.ProductName = l.ProductName;
                lOrderItem.ProductDescription = l.Description;
                lOrderItem.Description = "";

                SalesItems.Add(lOrderItem);

            }
            //MessageBox.Show(selectedProduct.Category.Name);
        }

        #endregion


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

        public DataSource.vEmpDept SalesPerson
        {
            get
            {
                return _salesPerson;
            }
            set
            {
                _salesPerson = value;
                this.OnPropertyChanged(() => this.SalesPerson);
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


        public int Id
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

        public DateTime? SalesDate
        {
            get
            {
                return _salesDate;
            }
            set
            {
                _salesDate = value;
                this.OnPropertyChanged(() => this.SalesDate);
            }
        }

        public DateTime? ExpireDate
        {
            get
            {
                return _expireDate;
            }
            set
            {
                _expireDate = value;
                this.OnPropertyChanged(() => this.ExpireDate);
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

        public DataSource.Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                this.OnPropertyChanged(() => this.SelectedCustomer);

                if (_selectedCustomer != null)
                {
                    foreach (HSOrderItem l in SalesItems)
                    {
                        l.CustomerId = _selectedCustomer.Id;
                    }

                    this.SalesDate = DateTime.Now;

                    ButtonEnabled = true;
                }

            }
        }

        public DataSource.Order Order
        {
            get;
            set;
        }


        public ObservableCollection<HSOrderItem> SalesItems
        {
            get
            {
                return _salesItems;
            }
            set
            {
                _salesItems = value;

                this.OnPropertyChanged(() => this.SalesItems);
            }
        }

        public Boolean IsMaster
        {
            get
            {
                return _isMaster;
            }
            set
            {
                _isMaster = value;

                this.OnPropertyChanged(() => this.IsMaster);
            }
        }

    }
}
