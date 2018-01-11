using SunSeven.Views;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;


namespace SunSeven.Models
{
    public class HSOrderItem : ViewModelBase
    {

        private int _id;
        private int _orderId;
        private int? _salesStatusId;
        private int _productId;
        private int? _vatId;
        private int? _sellingUnitId;
        private decimal? _unitprice;
        private decimal? _price;
        private decimal? _quantity;
        private string _description;
        
        
        public DataSource.SellingUnit _selectedSellingUnit;
        private DataSource.Product _selectedProduct;
        private DataSource.VatRate _selectedVat;


        SunSeven.DataSource.JSDataContext lDataContext;

        public ICommand priceHistoryCommand { get; set; }
        public ICommand deleteCommand { get; set; }


        public HSOrderItem()
        {
            lDataContext = new CommonFunction().JSDataContext();
            this.priceHistoryCommand = new DelegateCommand(OnPriceHisotry);
            //this.deleteCommand = new DelegateCommand(OnDeleteItem);

        }

        private void OnPriceHisotry(object id)
        {
            RadWindow priceHisotoryWin = new PriceHistoryWindow(this.CustomerId, this.ProductId, this.SellingUnitId);

            //var lWindows = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains("John Stone Vegetable"));

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            priceHisotoryWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            if (lWindows != null)
                priceHisotoryWin.Owner = lWindows;

            priceHisotoryWin.ShowDialog();
        }


        //private void OnDeleteItem(object id)
        //{
        //    var lWindows = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains("John Stone Vegetable"));

        //    DataSource.OrderItem lItem = lDataContext.OrderItems.SingleOrDefault<DataSource.OrderItem>(p => p.Id == this.Id);

        //    if (lItem == null)
        //    {               
        //        return;
        //    }

        //    if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
        //               MessageBoxButton.OKCancel) == MessageBoxResult.OK)
        //    {
        //        try
        //        {


        //            lDataContext.OrderItems.DeleteOnSubmit(lItem);
        //            lDataContext.SubmitChanges();
        //        }
        //        catch(Exception e)
        //        {
        //            MessageBox.Show(e.Message);
        //        }
        //    }


        //}

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int CustomerId { get; set; }

        public int OrderId
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;


                this.OnPropertyChanged(() => this.OrderId);
                this.OnPropertyChanged(() => this.isVisible);
                
            }
        }

        public int? SellingUnitId
        {
            get
            {
                return _sellingUnitId;
            }
            set
            {
                _sellingUnitId = value;


                this.OnPropertyChanged(() => this.SellingUnitId);

            }
        }


        public DataSource.SellingUnit SelectedSellingUnit
        {
            get
            {

                return _selectedSellingUnit;
            }
            set
            {

                _selectedSellingUnit = value;

                this.OnPropertyChanged(() => this.SelectedSellingUnit);

            }
        }


        public int? SalesStatusId
        {
            get
            {

                return _salesStatusId;
            }
            set
            {
                _salesStatusId = value;

                this.OnPropertyChanged(() => this.SalesStatusId);

            }
        }

        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;

                this.OnPropertyChanged(() => this.ProductId);
            }
        }



        public DataSource.Product SelectedProduct
        {
            get
            {

                return _selectedProduct;
            }
            set
            {

                _selectedProduct = value;

                this.OnPropertyChanged(() => this.SelectedProduct);
            }
        }

        public int? VatId
        {
            get
            {
                return _vatId;
            }
            set
            {
                _vatId = value;

                this.OnPropertyChanged(() => this.VatId);
                this.OnPropertyChanged(() => this.Price);
                this.OnPropertyChanged(() => this.PriceWithVat);
            }
        }

        public DataSource.VatRate SelectedVat
        {
            get
            {
                //if (_selectedVat == null)
                //    _selectedVat = new DataSource.VatRate();

                return _selectedVat;
            }
            set
            {

                //if (_selectedVat == null)
                //    _selectedVat = new DataSource.VatRate();

                _selectedVat = value;

                this.OnPropertyChanged(() => this.SelectedVat);
                this.OnPropertyChanged(() => this.Price);
                this.OnPropertyChanged(() => this.PriceWithVat);
            }
        }



        public decimal? UnitPrice
        {
            get
            {
                return _unitprice;
            }
            set
            {
                _unitprice = value;
                this.OnPropertyChanged(() => this.UnitPrice);
                this.OnPropertyChanged(() => this.Price);
                this.OnPropertyChanged(() => this.PriceWithVat);
            }

        }


        public decimal? Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                this.OnPropertyChanged(() => this.Quantity);
                this.OnPropertyChanged(() => this.Price);
                this.OnPropertyChanged(() => this.PriceWithVat);

            }

        }

        public decimal? Price
        {
            get
            {
                try
                {
                    _price = this.UnitPrice.Value * this.Quantity.Value;
                }
                catch
                {
                    _price = 0;
                }

                return _price;
            }
            set
            {
                _price = value;
            }

        }

        public decimal PriceWithVat
        {
            get
            {

                decimal lInclPrice = 0;

                try
                {
                    lInclPrice = this.UnitPrice.Value * this.Quantity.Value;
                    lInclPrice = lInclPrice + (lInclPrice * (this.SelectedVat.Rate / 100));
                }
                catch
                {
                    lInclPrice = -1;
                }

                return lInclPrice;
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

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public string ProductDetail
        {
            get
            {
                return this.ProductName + " (" + this.ProductDescription + ")";
            }
        }
        public string Unit { get; set; }
        public string VAT { get; set; }

        public bool isVisible
        {

            get
            {
                if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
                {
                    return false;
                }
                return true;
            }
        }
    }
}
