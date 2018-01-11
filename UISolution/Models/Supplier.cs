using System;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.DataSource;

namespace SunSeven.Models
{

    public class HSSupplier : ViewModelBase, IEditableObject
    {
        private int _id;
        private int? _contactId;
        private string _supplierName;
        private string _billingAddress;
        private Person _selectedPerson;

        backupCollection backupData;

        private JSDataContext lContext;

        public HSSupplier()
        {
            lContext = new CommonFunction().JSDataContext();
        }

        public System.Data.Linq.Table<Person> PersonCollection
        {
            get
            {
                return lContext.Persons;
            }
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

        public int? ContactId
        {
            get
            {
                return _contactId;
            }
            set
            {
                _contactId = value;
            }

        }

        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                this.OnPropertyChanged(() => this.SelectedPerson);
                this.OnPropertyChanged(() => this.FullName);

            }
        }



        public string FullName
        {
            get
            {
                if (SelectedPerson != null)
                    return this.SelectedPerson.FirstName + ", " + this.SelectedPerson.LastName;
                else
                    return null;
            }
        }


        public string SupplierName
        {
            get
            {

                return _supplierName;
            }
            set
            {
                _supplierName = value;
                this.OnPropertyChanged(() => this.SupplierName);
            }
        }

        public string BillingAddress
        {
            get
            {

                return _billingAddress;
            }
            set
            {
                _billingAddress = value;
                this.OnPropertyChanged(() => this.BillingAddress);
            }
        }

        public struct backupCollection
        {

            internal int? contactId;
            internal string supplierName;
            internal string billingAddress;
            internal Person selectedPerson;

        }


        public void BeginEdit()
        {

            this.backupData.contactId = this.ContactId;
            this.backupData.supplierName = this.SupplierName;
            this.backupData.billingAddress = this.BillingAddress;

            this.backupData.selectedPerson = this.SelectedPerson;

        }

        public void CancelEdit()
        {

            this.ContactId = this.backupData.contactId;
            this.SupplierName = this.backupData.supplierName;
            this.BillingAddress = this.backupData.billingAddress;
            this.SelectedPerson = this.backupData.selectedPerson;


        }

        public void EndEdit()
        {

            DataSource.Supplier lUpdate = lContext.Suppliers.SingleOrDefault(p => p.Id == this.Id);


            if (lUpdate == null)
            {
                DataSource.Supplier newItem = new DataSource.Supplier
                {
                    Id = this.Id,
                    Contact = this.ContactId,
                    Name = this.SupplierName,
                    BillingAddress = this.BillingAddress,


                };
                // Add the new object to the Orders collection.
                lContext.Suppliers.InsertOnSubmit(newItem);

                // Submit the change to the database.
                try
                {
                    lContext.SubmitChanges();

                    this.Id = newItem.Id;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                lUpdate.Contact = this.ContactId;
                lUpdate.Name = this.SupplierName;
                lUpdate.BillingAddress = this.BillingAddress;

                lContext.SubmitChanges();
            }

        }

        public void DeleteEnd()
        {
            //var deleteOrderDetails =
            //    from details in lContext.Persons
            //    where details.Id  == this.Id 
            //    select details;


            DataSource.Supplier lDeleted = lContext.Suppliers.SingleOrDefault(p => p.Id == this.Id);

            if (lDeleted != null)
            {
                lContext.Suppliers.DeleteOnSubmit(lDeleted);

                try
                {
                    lContext.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
            }
        }


    }

}
