using SunSeven.DataSource;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{

    public class HSCustomer : ViewModelBase, IEditableObject
    {
        private int _id;
        private string _name;
        private string _companyName;
        private int? _contactId;
        private string _deliveryAddress;
        private string _billingAddress;
        private int? _clientTypeId;
        private Person _selectedPerson;
        private string _description;


        backupPeopleData backupData;

        private JSDataContext lContext;

        public HSCustomer()
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

        [Required(ErrorMessage = "Customer Name is required")]
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

        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                _companyName = value;
                this.OnPropertyChanged(() => this.CompanyName);


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

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                this.OnPropertyChanged(() => this.Description);


            }
        }

        public string FullName
        {
            get
            {
                if (SelectedPerson != null)
                    return this.SelectedPerson.LastName + ", " + this.SelectedPerson.FirstName;
                else
                    return null;
            }
        }


        public string DeliveryAddress
        {
            get
            {

                return _deliveryAddress;
            }
            set
            {
                _deliveryAddress = value;
                this.OnPropertyChanged(() => this.DeliveryAddress);
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

        public int? ClientTypeId
        {
            get
            {
                return _clientTypeId;
            }
            set
            {
                _clientTypeId = value;
                this.OnPropertyChanged(() => this.ClientTypeId);
            }

        }

        public string ClientType
        {
            get;
            set;
        }

        public struct backupPeopleData
        {

            internal int? contactId;
            internal string name;
            internal string companyName;
            internal string deliverAddress;
            internal string billingAddress;
            internal string description;
            internal Person selectedPerson;
            internal int? ClientTypeId;

        }


        public void BeginEdit()
        {

            this.backupData.contactId = this.ContactId;
            this.backupData.name = this.Name;
            this.backupData.companyName = this.CompanyName;
            this.backupData.deliverAddress = this.DeliveryAddress;
            this.backupData.billingAddress = this.BillingAddress;
            this.backupData.description = this.Description;
            this.backupData.selectedPerson = this.SelectedPerson;
            this.backupData.ClientTypeId = this.ClientTypeId;

        }

        public void CancelEdit()
        {

            this.ContactId = this.backupData.contactId;
            this.Name = this.backupData.name;
            this.CompanyName = this.backupData.companyName;
            this.DeliveryAddress = this.backupData.deliverAddress;
            this.BillingAddress = this.backupData.billingAddress;
            this.SelectedPerson = this.backupData.selectedPerson;
            this.ClientTypeId = this.backupData.ClientTypeId;
            this.Description = this.backupData.description;
        }

        public void EndEdit()
        {

            DataSource.Customer lUpdate = lContext.Customers.SingleOrDefault(p => p.Id == this.Id);


            if (lUpdate == null)
            {
                DataSource.Customer newItem = new DataSource.Customer
                {
                    Id = this.Id,
                    Contact = this.ContactId,
                    Name = this.Name,
                    CompanyName = this.CompanyName,
                    DeliveryAddress = this.DeliveryAddress,
                    BillingAddress = this.BillingAddress,
                    Type = this.ClientTypeId,
                    Description = this.Description

                };
                // Add the new object to the Orders collection.
                lContext.Customers.InsertOnSubmit(newItem);

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
                lUpdate.Name = this.Name;
                lUpdate.CompanyName = this.CompanyName;
                lUpdate.DeliveryAddress = this.DeliveryAddress;
                lUpdate.BillingAddress = this.BillingAddress;
                lUpdate.Type = this.ClientTypeId;
                lUpdate.Description = this.Description;
                lContext.SubmitChanges();
            }

        }

        public void DeleteEnd()
        {
            //var deleteOrderDetails =
            //    from details in lContext.Persons
            //    where details.Id  == this.Id 
            //    select details;


            DataSource.Customer lDeleted = lContext.Customers.SingleOrDefault(p => p.Id == this.Id);

            if (lDeleted != null)
            {
                lContext.Customers.DeleteOnSubmit(lDeleted);

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
