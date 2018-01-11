using System.Collections.ObjectModel;
using System.ComponentModel;
using UISolution.DataSource;
using UISolution.Models;

namespace UISolution.ViewModels
{

    public class vmPriceHistory : commandCollection
    {

        private ICollectionView hsCollection = null;


        private ObservableCollection<HSSellingUnit> _sellingUnitColl;

        UISolution.DataSource.HanSungLinqDataContext lDataContext;

        public vmPriceHistory()
        {
            lDataContext = new HanSungLinqDataContext();
        }


        public ObservableCollection<HSPriceHistory> PriceHistories
        {
            get
            {
                ObservableCollection<HSPriceHistory> lhsCollection = new ObservableCollection<HSPriceHistory>();

                foreach (UISolution.DataSource.PriceHistory l in lDataContext.PriceHistories)
                {
                    lhsCollection.Add(new HSPriceHistory
                    {
                        Id = l.Id,
                        CustomerId = l.CustomerId,
                        EmployeeId = l.EmployeeId,
                       
                       
                        UnitPrice = l.UnitPrice,
                        ProductId = l.ProductId,
                        SalesId = l.SalesId,
                        SellingUnitId = l.SellingUnitId,


                    });
                }


                return lhsCollection;
            }
        }




    }
}
