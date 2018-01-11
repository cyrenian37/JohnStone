using System.Collections.ObjectModel;
using SunSeven.DataSource;
using SunSeven.Models;

namespace SunSeven.ViewModels
{

    public class vmSalesItem : commandCollection
    {

        private ObservableCollection<HSOrderItem> hsCollection = null;
        private ObservableCollection<HSVatRate> _vatRateCollection = null;
        private HSVatRate _selectedVatRate;



        SunSeven.DataSource.JSDataContext lDataContext;

        public vmSalesItem()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        public ObservableCollection<HSOrderItem> SalesItems
        {
            get
            {
                if (this.hsCollection == null)
                {
                    try
                    {
                        hsCollection = new ObservableCollection<HSOrderItem>();


                        foreach (SunSeven.DataSource.OrderItem l in lDataContext.OrderItems)
                        {
                            hsCollection.Add(new HSOrderItem
                            {
                                Id = l.Id,
                                
                                SalesStatusId = l.SalesStatusId,
                                ProductId = l.ProductId,
                                VatId = l.VatId,
                                Quantity = l.Quantity

                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsCollection;
            }
        }

    }
}
