using System;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.DataSource;


namespace SunSeven.Models
{
    public class HSVatRate : ViewModelBase, IEditableObject
    {

        private int _id;
        private string _name;
        private decimal _rate;


        SunSeven.DataSource.JSDataContext lDataContext;

        public HSVatRate()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }


        public int Id
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

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.OnPropertyChanged(() => this.Name);

            }
        }

        public decimal Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;


                this.OnPropertyChanged(() => this.Rate);
            }
        }


        public void BeginEdit()
        {
            //throw new System.NotImplementedException();
        }

        public void CancelEdit()
        {
            //throw new System.NotImplementedException();
        }

        public void EndEdit()
        {

            DataSource.VatRate lUpdateItem = lDataContext.VatRates.SingleOrDefault(p => p.Id == this.Id);

            if (lUpdateItem == null)
            {

                DataSource.VatRate lNewItem = new DataSource.VatRate
                {
                    Name = this.Name,
                    Rate = this.Rate
                };

                // Add the new object to the Orders collection.
                lDataContext.VatRates.InsertOnSubmit(lNewItem);

                // Submit the change to the database.
                try
                {
                    lDataContext.SubmitChanges();

                    this.Id = lNewItem.Id;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            else
            {
                lUpdateItem.Name = this.Name;
                lUpdateItem.Rate = this.Rate;

                lDataContext.SubmitChanges();
            }
        }
    }
}
