using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;


namespace SunSeven.Models
{
    public class HSInvoice : ViewModelBase
    {

        private int? _id;
        private int? _customerId;
        private int? _delivererId;
        private string _invoiceNo;
        private DateTime _invoiceDate;
        private DateTime? _deliveryDate;
        private string _description;
        private DataSource.Customer _selectedCustomer;
        private ObservableCollection<HSQuotation> _salesCollection;
        private DataSource.SalesStatus _invoiceStatus;

        SunSeven.DataSource.JSDataContext lDataContext;

        public HSInvoice()
        {
            lDataContext = new CommonFunction().JSDataContext();

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


        public string InvoiceNo
        {
            get
            {
                return _invoiceNo;
            }
            set
            {
                _invoiceNo = value;
                this.OnPropertyChanged(() => this.InvoiceNo);

            }
        }


        public DateTime InvoiceDate
        {
            get
            {
                return _invoiceDate;
            }
            set
            {
                _invoiceDate = value;
                _deliveryDate = value;
                this.OnPropertyChanged(() => this.InvoiceDate);
                this.OnPropertyChanged(() => this.DeliveryDate);

            }
        }

        public DateTime? DeliveryDate
        {
            get
            {
                return _deliveryDate;
            }
            set
            {
                _deliveryDate = value;

                if (value != null)
                {
                    _invoiceDate = value.Value;
                    this.OnPropertyChanged(() => this.InvoiceDate);
                }
                this.OnPropertyChanged(() => this.DeliveryDate);

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

        private int? _invoiceStatusId;

        public int? InvoiceStatusId
        {
            get
            {
                return _invoiceStatusId;
            }
            set
            {
                _invoiceStatusId = value;

                this.OnPropertyChanged(() => this.InvoiceStatusId);
                this.OnPropertyChanged(() => this.StatusColour);
            }

        }

        //public DataSource.SalesStatus InvoiceStatus
        //{
        //    get
        //    {
        //        return _invoiceStatus;
        //    }
        //    set
        //    {
        //        _invoiceStatus = value;

        //        this.OnPropertyChanged(() => this.InvoiceStatus);
        //        this.OnPropertyChanged(() => this.StatusColour);
        //    }
        //}

        public string StatusColour
        {
            get
            {

                switch (this.InvoiceStatusId)
                {
                    case 1:
                        return "Transparent";
                    case 2:
                        return "Silver";
                    case 3:
                        return "Transparent";
                    case 4:
                        return "Transparent";
                    default:
                        return "Transparent";

                }

            }

        }

        //public string StatusColour2
        //{
        //    get
        //    {
        //        if (this.InvoiceStatus != null)
        //        {
        //            switch (this.InvoiceStatus.Name.ToUpper())
        //            {
        //                case "OPEN":
        //                    return "Green";
        //                case "CLOSED":
        //                    return "Gray";
        //                case "RETURNED":
        //                    return "Black";
        //                case "PARTIAL RETURNED":
        //                    return "Yellow";
        //                default:
        //                    return "Transparent";

        //            }
        //        }

        //        return "Transparent";

        //    }

        //}

    }
}
