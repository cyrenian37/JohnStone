using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.DataForm;
using SunSeven.DataSource;


namespace SunSeven.Models
{
    public class HSPriceHistory : ViewModelBase
    {

        private int _id;
        private int? _customerId;
        private int? _employeeId;
        private int? _vatId;
        private decimal? _vatRate;
        private int? _productId;
        private decimal? _unitprice;
        private decimal? _price;
        private int? _orderId;
        private int? _sellingUnitId;
             

        SunSeven.DataSource.JSDataContext lDataContext;



        public HSPriceHistory()
        {
            lDataContext = new CommonFunction().JSDataContext();
            

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
            }
        }


        public int? CustomerId
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

        public int? EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
                this.OnPropertyChanged(() => this.EmployeeId);
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
            }
        }

        public decimal? VatRate
        {
            get
            {
                return _vatRate / 100;
            }
            set
            {
                _vatRate = value;
                this.OnPropertyChanged(() => this.VatRate);
            }
        }

        public int? ProductId
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

        public int? OrderId
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
                this.OnPropertyChanged(() => this.OrderId);

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

            }
        }


        public decimal? Price
        {
            get
            {
                _price = this.VatRate.Value * this.UnitPrice.Value;
                return _price;
            }

        }



       

    }
}
