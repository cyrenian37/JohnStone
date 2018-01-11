using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Data;
using SunSeven.DataSource;
using SunSeven.Models;

namespace SunSeven.ViewModels
{

    public class vmSupplier : commandCollection
    {

        private ICollectionView hsCollection = null;

        SunSeven.DataSource.JSDataContext lDataContext;

        public vmSupplier()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        public ICollectionView Suppliers
        {
            get
            {
                if (this.hsCollection == null)
                {
                    ObservableCollection<HSSupplier> lhsCollection = new ObservableCollection<HSSupplier>();

                    foreach (SunSeven.DataSource.Supplier l in lDataContext.Suppliers)
                    {
                        lhsCollection.Add(new HSSupplier
                        {
                            Id = l.Id,
                            ContactId = l.Contact,
                            BillingAddress = l.BillingAddress,
                            SupplierName = l.Name,
                            SelectedPerson = l.Person,

                        });
                    }

                    this.hsCollection = new QueryableCollectionView(lhsCollection);
                }

                return this.hsCollection;
            }
        }
    }
}
