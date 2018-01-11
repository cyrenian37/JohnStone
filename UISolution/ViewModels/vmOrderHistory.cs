using SunSeven.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.ViewModels
{


    public class vmOrderHistory : ViewModelBase
    {

        public static ObservableCollection<HSOrderHistory> lStaticOrderHistory = null;

        private ObservableCollection<HSOrderHistory> _orderHistory = null;

        SunSeven.DataSource.JSDataContext lDataContext;
        public ICommand searchCommand { get; set; }
        public ICommand updownCommand { get; set; }

        private DateTime? _startDT;
        private DateTime? _endDT;
        private int? _type;
        private Boolean _isBusy;
        private ObservableCollection<HSOrderHistory> _orderHistories;
        private int _pageIndex = 1;



        public vmOrderHistory()
        {
            lDataContext = new CommonFunction().JSDataContext();
            this.searchCommand = new DelegateCommand(OnSearchCommandExecuted);
            this.updownCommand = new DelegateCommand(OnUpDownCommandExecuted);
            this.StartDT = DateTime.Today.AddDays(-1);
            this.EndDT = DateTime.Today.AddDays(1).AddSeconds(-1);

            this.Type = 0;
        }

        public vmOrderHistory(int? Type, DateTime? pST, DateTime? pET)
        {
            lDataContext = new CommonFunction().JSDataContext();

            this.searchCommand = new DelegateCommand(OnSearchCommandExecuted);
            this.updownCommand = new DelegateCommand(OnUpDownCommandExecuted);

            this.StartDT = (pST == null) ? DateTime.Today.AddDays(-1) : pST.Value;
            this.EndDT = (pET == null) ? DateTime.Today.AddDays(1).AddSeconds(-1) : pET.Value;
            this.Type = Type;

            if (lStaticOrderHistory == null)
            {
                this.IsBusy = true;
                lStaticOrderHistory = new ObservableCollection<HSOrderHistory>();

                LoadingAsyncStart();
            }
        }

        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
                OnPropertyChanged(() => PageIndex);
            }
        }
        public DateTime? StartDT
        {
            get
            {
                return _startDT;
            }
            set
            {
                _startDT = value;
                OnPropertyChanged(() => StartDT);
            }
        }

        public DateTime? EndDT
        {
            get
            {
                return _endDT;
            }
            set
            {
                _endDT = value;
                OnPropertyChanged(() => EndDT);
            }
        }

        public int? Type { get; set; }

        private void OnSearchCommandExecuted(object id)
        {

            this.IsBusy = true;
            this.Type = null;

            lStaticOrderHistory = new ObservableCollection<HSOrderHistory>();
            LoadingAsyncStart();
        }

        private void OnUpDownCommandExecuted(object Param)
        {

            this.IsBusy = true;
            this.Type = null;

            switch ((string)Param)
            {
                case "UP":
                    this.StartDT = this.StartDT.Value.AddDays(1);

                    break;
                case "DOWN":
                    this.StartDT = this.StartDT.Value.AddDays(-1);

                    break;
                case "TODAY":
                    this.StartDT = DateTime.Today;

                    break;

            }

            this.EndDT = this.StartDT.Value.AddDays(1).AddSeconds(-1);
            lStaticOrderHistory = new ObservableCollection<HSOrderHistory>();
            LoadingAsyncStart();

        }


        private async void LoadingAsyncStart()
        {
            var lReturn = await LoadingAsync();

            this.IsBusy = lReturn;

        }

        private Task<Boolean> LoadingAsync()
        {
            return Task.Factory.StartNew(() => LoadingEnded());
        }

        private Boolean LoadingEnded()
        {
            ObservableCollection<HSOrderHistory> orderHistorySet = new ObservableCollection<HSOrderHistory>();

            var lorderHistory = lDataContext.orderHistory(this.StartDT, this.EndDT, this.Type);

            //ObservableCollection<DataSource.vEmpDept> SalesPerson = new ObservableCollection<DataSource.vEmpDept>();
            ObservableCollection<DataSource.vEmpDept> DeliveryPeople = new ObservableCollection<DataSource.vEmpDept>();

            //foreach (var l in lDataContext.vEmpDepts.Where(p => p.Department.Contains("Sales")))
            //{
            //    SalesPerson.Add(new DataSource.vEmpDept
            //    {
            //        Id = l.Id,
            //        FirstName = l.FirstName,
            //        LastName = l.LastName,
            //        Department = l.Department,
            //        Person = l.Person
            //    });
            //}

            foreach (var l in lDataContext.vEmpDepts.Where(p => p.Department.Contains("Delivery")))
            {
                DeliveryPeople.Add(new DataSource.vEmpDept
                {
                    Id = l.Id,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    Department = l.Department,
                    DateOut = l.DateOut,
                    Person = l.Person
                });
            }

            foreach (DataSource.orderHistoryResult l in lorderHistory)
            {
                //ObservableCollection<DataSource.vEmpDept> SalesPerson = new ObservableCollection<DataSource.vEmpDept>();
                ObservableCollection<DataSource.vEmpDept> DeliveryPerson = new ObservableCollection<DataSource.vEmpDept>();

                var EmpAtWork = DeliveryPeople.Where(p => p.DateOut == null || p.Id == l.DeliveryPersonId );

                foreach (var ll in EmpAtWork)
                {
                    DeliveryPerson.Add(new DataSource.vEmpDept { Id = ll.Id, FirstName = ll.FirstName, LastName = ll.LastName, Person = ll.Person, Department = ll.Department });
                }

                orderHistorySet.Add(new HSOrderHistory
                {
                    CustomerDetail = l.customer,
                    OrderId = l.orderId,
                    OrderDate = l.OrderDate,
                    InvoiceNo = l.InvoiceNo,
                    InvoiceDate = l.InvoiceDate,
                    DeliveryDate = l.DeliveryDate,
                    SalesPersonId = l.salesPersonId,
                    DeliveryPersonId = l.DeliveryPersonId,
                   // SalesPerson = SalesPerson,
                    
                    DeliveryPerson = DeliveryPerson,
                    InvoiceStatus = l.InvoiceStatus,
                    TotalPrice = l.inclVAT,
                    TotalVAT = l.totalVAT,
                    Description = l.Description,
                    InternalComment = l.InternalComment

                });
            }

            OrderHistories = orderHistorySet;
            //lStaticOrderHistory = orderHistorySet;
            //Thread.Sleep(5000);
            return false;
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
                OnPropertyChanged(() => IsBusy);
            }
        }

        public ObservableCollection<HSOrderHistory> OrderHistories
        {
            get
            {
                //return _orderHistories;
                return lStaticOrderHistory;
            }
            set
            {
                lStaticOrderHistory = value;
                OnPropertyChanged(() => OrderHistories);
            }
        }



        public ObservableCollection<HSOrderHistory> getOrderHistory()
        {
            ObservableCollection<HSOrderHistory> orderHistorySet = new ObservableCollection<HSOrderHistory>();

            //_orderHistories = new ObservableCollection<HSOrderHistory>();

            var lorderHistory = lDataContext.orderHistory(this.StartDT, this.EndDT, this.Type);

            ObservableCollection<DataSource.vEmpDept> SalesPerson = new ObservableCollection<DataSource.vEmpDept>();
            ObservableCollection<DataSource.vEmpDept> DeliveryPerson = new ObservableCollection<DataSource.vEmpDept>();

            foreach (var l in lDataContext.vEmpDepts.Where(p => p.Department.Contains("Sales")))
            {
                SalesPerson.Add(new DataSource.vEmpDept { Id = l.Id, FirstName = l.FirstName, LastName = l.LastName, Department = l.Department });
            }

            foreach (var l in lDataContext.vEmpDepts.Where(p => p.Department.Contains("Delivery")))
            {
                DeliveryPerson.Add(new DataSource.vEmpDept { Id = l.Id, FirstName = l.FirstName, LastName = l.LastName, Department = l.Department });
            }

            foreach (DataSource.orderHistoryResult l in lorderHistory)
            {
                orderHistorySet.Add(new HSOrderHistory
                {
                    CustomerDetail = l.customer,
                    OrderId = l.orderId.Value,
                    OrderDate = l.OrderDate,
                    InvoiceNo = l.InvoiceNo,
                    InvoiceDate = l.InvoiceDate,
                    DeliveryDate = l.DeliveryDate,
                    SalesPersonId = l.salesPersonId,
                    DeliveryPersonId = l.DeliveryPersonId,
                    SalesPerson = SalesPerson,
                    DeliveryPerson = DeliveryPerson,
                    TotalPrice = l.inclVAT,
                    TotalVAT = l.totalVAT

                });
            }

            return orderHistorySet;
        }

        public ObservableCollection<HSOrderHistory> OrderHistoriesOLD
        {
            get
            {
                if (this._orderHistory == null)
                {
                    _orderHistory = new ObservableCollection<HSOrderHistory>();

                    foreach (SunSeven.DataSource.Order l in lDataContext.Orders.OrderByDescending(p => p.OrderDate))
                    {

                        var lPriceHist = from oi in lDataContext.OrderItems
                                         join v in lDataContext.VatRates
                                         on oi.VatId equals v.Id
                                         where oi.OrderId == l.Id
                                         select new
                                         {
                                             VAT = (oi.UnitPrice * oi.Quantity) * v.Rate / 100,
                                             InclVAT = (oi.UnitPrice * oi.Quantity) + (oi.UnitPrice * oi.Quantity) * v.Rate / 100

                                         };

                        //decimal? inclVat = (from p in lDataContext.OrderItems
                        //                    where p.OrderId == l.Id
                        //                    select p.UnitPrice * p.Quantity).Sum();

                        _orderHistory.Add(new HSOrderHistory
                        {
                            OrderId = l.Id,
                            CustomerDetail = l.Customer.Name + " (" + l.Customer.CompanyName + ")",
                            OrderDate = l.OrderDate,
                            SalesEmp = (l.Employee == null) ? null : l.Employee.Person,
                            InvoiceNo = (l.Invoice == null) ? null : l.Invoice.InvoiceNo,
                            InvoiceDate = (l.Invoice == null) ? (DateTime?)null : l.Invoice.InvoiceDate,
                            DeliveryDate = (l.Invoice == null) ? (DateTime?)null : l.Invoice.DeliveryDate,
                            DeliveryEmp = (l.Invoice == null) ? null : (l.Invoice.Employee == null) ? null : l.Invoice.Employee.Person,
                            SalesPersonId = (l.Employee == null) ? (int?)null : l.Employee.Id,
                            DeliveryPersonId = (l.Invoice == null) ? (int?)null : l.Invoice.EmpDeliveryId,
                            Description = (l.Invoice == null) ? null : l.Invoice.Description,

                            TotalVAT = lPriceHist.Sum(p => p.VAT),
                            TotalPrice = lPriceHist.Sum(p => p.InclVAT)

                        });
                    }


                }

                return _orderHistory;
            }
        }
    }
}
