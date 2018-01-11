using SunSeven.DataSource;
using System;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{
    public class HSSellingUnit : ViewModelBase, IEditableObject
    {

        private string _unit;
        

        private JSDataContext lDataContext;

        public HSSellingUnit()
        {
            lDataContext = new CommonFunction().JSDataContext();
            
        }
        public int Id { get; set; }
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                this.OnPropertyChanged(() => this.Unit);
            }
        }

        public Boolean CanDelete
        {
            get
            {
                if (this.Unit == "NA")
                    return false;
                else
                    return true;
            }
        }

        public Boolean ReadOnly
        {
            get
            {
                if (this.Unit == "NA")
                    return true;
                else
                    return false;
               
            }
           
        }
        public void BeginEdit()
        {
            //throw new NotImplementedException();
        }

        public void CancelEdit()
        {
            //throw new NotImplementedException();
        }

        public void EndEdit()
        {
            DataSource.SellingUnit lUpdate = lDataContext.SellingUnits.SingleOrDefault(p => p.Id == this.Id);


            if (lUpdate == null)
            {
                DataSource.SellingUnit newItem = new DataSource.SellingUnit
                {
                    Unit = this.Unit

                };
                // Add the new object to the Orders collection.
                lDataContext.SellingUnits.InsertOnSubmit(newItem);

                // Submit the change to the database.
                try
                {
                    lDataContext.SubmitChanges();

                    this.Id = newItem.Id;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                lUpdate.Unit = this.Unit;


                lDataContext.SubmitChanges();
            }

        }
    }


}
