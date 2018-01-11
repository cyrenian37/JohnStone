using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{
    public class HSOrderHistory : ViewModelBase
    {
        public ICommand printCommand { get; set; }
        public ICommand selectCommand { get; set; }


        private int? _salespersonId;
        private int? _deliverypersonid;
        private DateTime? _deliveryDate;

        private ObservableCollection<DataSource.vEmpDept> _salesPerson;

        SunSeven.DataSource.JSDataContext lDataContext;

        public HSOrderHistory()
        {
            lDataContext = new CommonFunction().JSDataContext();
            this.selectCommand = new DelegateCommand(OnSelectCommandExecuted);
            this.printCommand = new DelegateCommand(OnPrintCommandExecuted);
            // _salesPerson = new ObservableCollection<DataSource.vEmpDept>();
        }

        private void OnSelectCommandExecuted(object id)
        {

        }


        public ObservableCollection<DataSource.vEmpDept> SalesPerson
        {
            get;
            set;
            //get
            //{
            //    return _salesPerson;
            //}
            //set
            //{
            //    _salesPerson = value;
            //    OnPropertyChanged(() => this.SalesPerson);
            //}
        }

        public ObservableCollection<DataSource.vEmpDept> DeliveryPerson
        {
            get;
            set;
        }


        private void OnPrintCommandExecuted(object Param)
        {
            HSOrderHistory lOrderHistory = Param as HSOrderHistory;

            HSOrder lEditOrder = CommonFunction.PrintOrder(lOrderHistory.OrderId);

            if (lEditOrder == null) return;

            //HSInvoice lInvoice = new HSInvoice();

            //DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.Id == lOrderHistory.OrderId);

            //if (lOrder != null)
            //{

            //    lEditOrder.Id = lOrder.Id;
            //    lEditOrder.CustomerId = lOrder.CustomerId;
            //    lEditOrder.SelectedCustomer = lOrder.Customer;
            //    lEditOrder.OrderDate = lOrder.OrderDate;
            //    lEditOrder.SellerId = lOrder.EmployeeId;


            //    if (lOrder.Invoice != null)
            //    {
            //        lInvoice.Id = lOrder.Invoice.Id;
            //        lInvoice.InvoiceNo = lOrder.Invoice.InvoiceNo;
            //        lInvoice.InvoiceDate = lOrder.Invoice.InvoiceDate;
            //        lInvoice.DeliveryDate = lOrder.Invoice.DeliveryDate;
            //        lEditOrder.DelivererId = lOrder.Invoice.EmpDeliveryId;
            //        lInvoice.Description = lOrder.Invoice.Description;
            //        lEditOrder.Invoice = lInvoice;
            //    }


            //    foreach (DataSource.OrderItem l in lOrder.OrderItems)
            //    {
            //        lEditOrder.OrderItems.Add(new HSOrderItem
            //        {
            //            Id = l.Id,
            //            CustomerId = lOrder.CustomerId,
            //            OrderId = l.OrderId,
            //            SalesStatusId = l.SalesStatusId,
            //            ProductId = l.ProductId,
            //            SelectedProduct = l.Product,
            //            UnitPrice = l.UnitPrice,
            //            VatId = l.VatId,
            //            SelectedVat = l.VatRate,
            //            Quantity = l.Quantity,
            //            SellingUnitId = l.SellingUnitId,
            //            SelectedSellingUnit = l.SellingUnit
            //        });
            //    }

            //}


            SunSeven.Reports.ReportViewer lRptViewer = new Reports.ReportViewer(lEditOrder, lEditOrder.OrderItems);

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows != null)
                lRptViewer.Owner = lWindows;

            lRptViewer.ShowDialog();

        }

        public int? OrderId { get; set; }

        public string CustomerDetail { get; set; }
        public DateTime? OrderDate { get; set; }


        public DataSource.Person SalesEmp
        {
            get;
            set;
        }

        //public String Seller
        //{
        //    get
        //    {
        //        if (SalesEmp != null)
        //            return SalesEmp.LastName + ", " + SalesEmp.FirstName;

        //        return "";
        //    }
        //}


        public string InvoiceNo
        {
            get;
            set;
        }


        public DateTime? InvoiceDate { get; set; }

        public DateTime? DeliveryDate
        {
            get
            {
                return _deliveryDate;
            }
            set
            {
                _deliveryDate = value;
                OnPropertyChanged(() => this.DeliveryDate);
            }
        }

        public DataSource.Person DeliveryEmp { get; set; }

        //public String Deliverer
        //{
        //    get
        //    {
        //        if (DeliveryEmp != null)
        //            return DeliveryEmp.LastName + ", " + DeliveryEmp.FirstName;
        //        return "";

        //    }
        //}

        public int? SalesPersonId
        {
            get
            {
                return _salespersonId;
            }
            set
            {
                _salespersonId = value;
                OnPropertyChanged(() => this.SalesPersonId);
                OnPropertyChanged(() => this.SelectedSalesPerson);
            }
        }


        public DataSource.vEmpDept SelectedSalesPerson
        {
            get
            {
                return lDataContext.vEmpDepts.SingleOrDefault(p => p.Id == this.SalesPersonId && p.Department.Contains("Sales"));
            }

        }

        public DataSource.vEmpDept SelectedDeliveryPerson
        {
            get
            {
                return lDataContext.vEmpDepts.SingleOrDefault(p => p.Id == this.DeliveryPersonId && p.Department.Contains("Delivery"));
            }

        }
        public int? DeliveryPersonId
        {
            get
            {
                return _deliverypersonid;
            }
            set
            {
                _deliverypersonid = value;
                OnPropertyChanged(() => this.DeliveryPersonId);
                OnPropertyChanged(() => this.SelectedDeliveryPerson);
            }
        }

        public string InvoiceStatus { get; set; }
        public string Description { get; set; }

        public decimal? TotalVAT { get; set; }
        public decimal? TotalPrice { get; set; }

        public string InternalComment { get; set; }
       
    }
}
