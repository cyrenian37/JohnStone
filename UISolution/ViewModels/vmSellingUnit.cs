using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Data;
using SunSeven.DataSource;
using SunSeven.Models;

namespace SunSeven.ViewModels
{


    public class vmSellingUnit : commandCollection
    {

        private ICollectionView people = null;

        SunSeven.DataSource.JSDataContext lDataContext;

        public vmSellingUnit()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        public ICollectionView SellingUnits
        {
            get
            {
                if (this.people == null)
                {
                    ObservableCollection<HSPerson> personCollection = new ObservableCollection<HSPerson>();

                    foreach (SunSeven.DataSource.Person l in lDataContext.Persons)
                    {
                        personCollection.Add(new HSPerson
                        {
                            Id = l.Id,
                            FirstName = l.FirstName,
                            LastName = l.LastName,
                            Address1 = l.Address1,
                            Address2 = l.Address2,
                            Phone1 = l.Phone1,
                            Phone2 = l.Phone2,
                            Email1 = l.Email1,
                            Email2 = l.Email2,
                            DOB = l.DOB,
                            Gender = (l.Gender == 0) ? HSPerson.GenderEnum.Female : HSPerson.GenderEnum.Male
                        });
                    }

                    this.people = new QueryableCollectionView(personCollection);
                }

                return this.people;
            }
        }
    }
}
