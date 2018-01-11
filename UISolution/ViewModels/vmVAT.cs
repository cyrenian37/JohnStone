using System.Collections.ObjectModel;
using SunSeven.DataSource;
using SunSeven.Models;

namespace SunSeven.ViewModels
{

    public class vmVatRate : commandCollection
    {

        private ObservableCollection<HSVatRate> hsCollection = null;

        SunSeven.DataSource.JSDataContext lDataContext;

        public vmVatRate()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        public ObservableCollection<HSVatRate> VATS
        {

            get
            {
                if (this.hsCollection == null)
                {
                    hsCollection = new ObservableCollection<HSVatRate>();

                    foreach (SunSeven.DataSource.VatRate l in lDataContext.VatRates)
                    {
                        hsCollection.Add(new HSVatRate
                        {

                            Id = l.Id,
                            Name = l.Name,
                            Rate = l.Rate

                        });
                    }
                }

                return this.hsCollection;
            }
        }
    }
}
