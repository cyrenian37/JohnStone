using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.DataSource;

namespace SunSeven.Models
{
    public class HSPerson : ViewModelBase, IEditableObject
    {
        private int _id;
        private string firstName;
        private string lastName;
        private string address1;
        private string address2;
        private string phone1;
        private string phone2;
        private string email1;
        private string email2;
        private DateTime? dob;
        private GenderEnum gender;
        backupPeopleData backupData;

        private JSDataContext lContext;


        public HSPerson()
        {
            lContext = new CommonFunction().JSDataContext();
        }

        public enum GenderEnum
        {
            NA,
            Female,
            Male
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

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                this.OnPropertyChanged(() => this.FirstName);
            }
        }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                this.OnPropertyChanged(() => this.LastName);
            }
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public DateTime? DOB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                this.OnPropertyChanged(() => this.DOB);
            }
        }

        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
                this.OnPropertyChanged(() => this.Address1);
            }
        }


        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
                this.OnPropertyChanged(() => this.Address2);
            }
        }


        public string Phone1
        {
            get
            {
                return phone1;
            }
            set
            {
                phone1 = value;
                this.OnPropertyChanged(() => this.Phone1);
            }
        }


        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
                this.OnPropertyChanged(() => this.Phone2);
            }
        }

        public string Email1
        {
            get
            {
                return email1;
            }
            set
            {
                email1 = value;
                this.OnPropertyChanged(() => this.Email1);
            }
        }


        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
                this.OnPropertyChanged(() => this.Email2);
            }
        }


        public GenderEnum Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                this.OnPropertyChanged(() => this.Gender);
            }
        }


        public struct backupPeopleData
        {

            internal string firstName;
            internal string lastName;
            internal string address1;
            internal string address2;
            internal string phone1;
            internal string phone2;
            internal string email1;
            internal string email2;
            internal GenderEnum gender;
            internal DateTime? dob;
        }


        public void BeginEdit()
        {
            this.backupData.firstName = this.FirstName;
            this.backupData.lastName = this.LastName;
            this.backupData.address1 = this.Address1;
            this.backupData.address2 = this.Address2;
            this.backupData.phone1 = this.Phone1;
            this.backupData.phone2 = this.Phone2;
            this.backupData.email1 = this.Email1;
            this.backupData.email2 = this.Email2;
            this.backupData.gender = this.Gender;
            this.backupData.dob = this.DOB;
        }

        public void CancelEdit()
        {
            this.FirstName = this.backupData.firstName;
            this.LastName = this.backupData.lastName;
            this.Address1 = this.backupData.address1;
            this.Address2 = this.backupData.address2;
            this.Phone1 = this.backupData.phone1;
            this.Phone2 = this.backupData.phone2;
            this.Email1 = this.backupData.email1;
            this.Email2 = this.backupData.email2;
            this.Gender = this.backupData.gender;
            this.DOB = this.backupData.dob;
        }

        public void EndEdit()
        {


            DataSource.Person lUpdatePerson = lContext.Persons.SingleOrDefault(p => p.Id == this.Id);


            if (lUpdatePerson == null)
            {
                DataSource.Person newPerson = new DataSource.Person
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Address1 = this.Address2,
                    Address2 = this.Address2,
                    Phone1 = this.Phone1,
                    Phone2 = this.Phone2,
                    Email1 = this.Email1,
                    Email2 = this.Email2,
                    DOB = this.DOB
                    // Gender = this.Gender 


                };

                // Add the new object to the Orders collection.
                lContext.Persons.InsertOnSubmit(newPerson);

                // Submit the change to the database.
                try
                {
                    lContext.SubmitChanges();

                    this.Id = newPerson.Id;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                lUpdatePerson.FirstName = this.FirstName;
                lUpdatePerson.LastName = this.LastName;
                lUpdatePerson.Address1 = this.Address1;
                lUpdatePerson.Address2 = this.Address2;
                lUpdatePerson.Phone1 = this.Phone1;
                lUpdatePerson.Phone2 = this.Phone2;
                lUpdatePerson.Email1 = this.Email1;
                lUpdatePerson.Email2 = this.Email2;
                lUpdatePerson.DOB = this.DOB;

                lContext.SubmitChanges();
            }

        }

        public void DeleteEnd()
        {
            //var deleteOrderDetails =
            //    from details in lContext.Persons
            //    where details.Id  == this.Id 
            //    select details;


            DataSource.Person lUpdatePerson = lContext.Persons.SingleOrDefault(p => p.Id == this.Id);

            if (lUpdatePerson != null)
            {
                lContext.Persons.DeleteOnSubmit(lUpdatePerson);

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
