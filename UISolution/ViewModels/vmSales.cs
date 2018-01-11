using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Data;
using SunSeven.DataSource;
using SunSeven.Models;
using Telerik.Windows.Controls;

namespace SunSeven.ViewModels
{


    public class vmSales : commandCollection
    {

        private ICollectionView hsCollection = null;
        private ObservableCollection<HSVatRate> _varRateCollection = null;

        SunSeven.DataSource.JSDataContext lDataContext;


        public vmSales()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        //public ICollectionView Sales
        //{
        //    get
        //    {
        //        if (this.hsCollection == null)
        //        {
        //            ObservableCollection<HSSales> salesCollection = new ObservableCollection<HSSales>();

        //            foreach (SunSeven.DataSource.Sale l in lDataContext.Sales)
        //            {
        //                salesCollection.Add(new HSSales
        //                {

        //                    Id = l.Id,
        //                    SalesDate = l.SalesDate,
        //                    InvoiceId = l.InvoiceId,
        //                    Description = l.Description,
        //                    SalesStatusId = l.SalesStatusId,
        //                    SalesTypeId = l.SalesTypeId,
        //                    VatRateId = l.VatRateId,                                                        
        //                    PayTypeId = l.PayTypeId,
        //                    PayStatusId = l.PayStatusId,
        //                    SellerId = l.SellerId,
        //                    DelivererId = l.DelivererId
                          
        //                });
        //            }

        //            this.hsCollection = new QueryableCollectionView(salesCollection);
        //        }

        //        return this.hsCollection;
        //    }
        //}


        public System.Data.Linq.Table<DataSource.Sale> SalesCollection
        {
            get
            {
                return lDataContext.Sales;
            }
        }
        public ObservableCollection<HSVatRate> VatRateCollection
        {
            get
            {
                if (this._varRateCollection == null)
                {
                    _varRateCollection = new ObservableCollection<HSVatRate>();

                    foreach (SunSeven.DataSource.VatRate l in lDataContext.VatRates)
                    {
                        _varRateCollection.Add(new HSVatRate
                        {
                            Id = l.Id,
                            Name = l.Name,
                            Rate = l.Rate

                        });
                    }
                }

                return _varRateCollection;
            }
        }

        public System.Data.Linq.Table<DataSource.SalesStatus> SalesStatusCollection
        {
            get
            {
                return lDataContext.SalesStatus;
            }
        }
        public System.Data.Linq.Table<DataSource.SalesType> SalesTypeCollection
        {
            get
            {
                return lDataContext.SalesTypes;
            }
        }

        public System.Data.Linq.Table<DataSource.PayStatus> PayStatusCollection
        {
            get
            {
                return lDataContext.PayStatus;
            }
        }

        public System.Data.Linq.Table<DataSource.PayType> PayTypeCollection
        {
            get
            {
                return lDataContext.PayTypes;
            }
        }

        //public ObservableCollection<DataSource.Credit> CreditCollection
        //{
        //    get
        //    {
        //        ObservableCollection<DataSource.Credit> lColl = new ObservableCollection<Credit>();

        //        foreach (DataSource.Credit l in lDataContext.Credits)
        //        {
        //            lColl.Add(new Credit { Id = l.Id, Sale = l.Sale, Customer = l.Customer, ModifiedOn = l.ModifiedOn, Value = l.Value });
        //        }
        //        return lColl;
        //    }
        //}


        public ObservableCollection<HSCredit> CreditCollection2
        {
            get
            {
                ObservableCollection<HSCredit> lColl = new ObservableCollection<HSCredit>();

                foreach (DataSource.Credit l in lDataContext.Credits)
                {
                    //lColl.Add(new HSCredit
                    //{
                    //    Id = l.Id,
                    //    Sales = new HSSales { SalesDate = l.Sale.SalesDate },
                    //    Customer = new HSCustomer { Id = l.Customer.Id, SelectedPerson = l.Customer.Person },
                    //    Value = l.Value,
                    //    Modified = l.ModifiedOn
                    //});
                }
               

                return lColl;
            }
        }


    }

    public class HSCredit : ViewModelBase
    {

        private int _id;
        private HSQuotation _sales;
        private HSCustomer _customer;
        private decimal? _value;
        private DateTime? _modified;

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

        public decimal? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                this.OnPropertyChanged(() => this.Value);
            }
        }

        public DateTime? Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                this.OnPropertyChanged(() => this.Modified);
            }
        }

        public HSQuotation Sales
        {
            get
            {
                return _sales;
            }
            set
            {
                _sales = value;
                this.OnPropertyChanged(() => this.Sales);
            }
        }

        public HSCustomer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                this.OnPropertyChanged(() => this.Customer);
            }
        }
    }

}
