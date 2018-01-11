using SunSeven.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Data;

namespace SunSeven.ViewModels
{

    public class vmCustomer : commandCollection
    {

        private ICollectionView hsCollection = null;

        SunSeven.DataSource.JSDataContext lDataContext;

        public vmCustomer()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        public ICollectionView Customers
        {
            get
            {
                if (this.hsCollection == null)
                {
                    ObservableCollection<HSCustomer> lhsCollection = new ObservableCollection<HSCustomer>();

                    string clientType;

                    foreach (SunSeven.DataSource.Customer l in lDataContext.Customers)
                    {
                        try
                        {
                            clientType =  l.ClientType.Type;
                        }
                        catch
                        {
                            clientType = "";
                        }

                        lhsCollection.Add(new HSCustomer
                        {
                            Id = l.Id,
                            Name = l.Name,
                            CompanyName = l.CompanyName,
                            ContactId = l.Contact,
                            BillingAddress = l.BillingAddress,
                            DeliveryAddress = l.DeliveryAddress,
                            SelectedPerson = l.Person,
                            ClientTypeId = l.Type,
                            ClientType = clientType,                                                    
                            Description = l.Description

                        });
                    }

                    this.hsCollection = new QueryableCollectionView(lhsCollection);
                }

                return this.hsCollection;
            }
        }
    }
}
