using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Data;
using SunSeven.DataSource;
using SunSeven.Models;

namespace SunSeven.ViewModels
{


    public class vmInvoice : commandCollection
    {

        private ICollectionView hsCollection = null;


        SunSeven.DataSource.JSDataContext lDataContext;


        public vmInvoice()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        //public ICollectionView Invoices
        //{
        //    get
        //    {
        //        if (this.hsCollection == null)
        //        {
        //            ObservableCollection<HSInvoice> invoiceCollection = new ObservableCollection<HSInvoice>();


        //            foreach (SunSeven.DataSource.Invoice l in lDataContext.Invoices)
        //            {
        //                ObservableCollection<HSSales> salesCollection = new ObservableCollection<HSSales>();

        //                foreach (SunSeven.DataSource.Sale ll in lDataContext.Sales.Where(p => p.InvoiceId == l.Id))
        //                {
        //                    salesCollection.Add(new HSSales { Id = ll.Id, SalesDate = ll.SalesDate });
        //                }

        //                invoiceCollection.Add(new HSInvoice
        //                {
        //                    Id = l.Id,
        //                    CustomerId = l.CustomerId,
        //                    Description = l.Description,
        //                    InvoiceDate = l.InvoiceDate,
        //                    DeliveryDate = l.DeliveryDate,
        //                    InvoiceNo = l.InvoiceNo,
        //                    SelectedCustomer = l.Customer,
        //                    SalesCollection = salesCollection

        //                });
        //            }

        //            this.hsCollection = new QueryableCollectionView(invoiceCollection);
        //        }

        //        return this.hsCollection;
        //    }
        //}



    }

}
