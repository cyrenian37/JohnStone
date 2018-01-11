using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{

    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HSPeople : ViewModelBase, IEditableObject
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _address1;
        private string _address2;
        private string _phoneNumber1;
        private string _phoneNumber2;
        private string _email1;
        private string _email2;
        private int _gender;
        ObservableCollection<Gender> _genderCollection;
        private int _genderId;

        public HSPeople()
        {
           

            this._genderId = 0;
            this._genderCollection = new ObservableCollection<Gender>();

            this._genderCollection.Add(new Gender { Id = 0, Name = "Female" });
            this._genderCollection.Add(new Gender { Id = 1, Name = "Male" });

        }

        public int GenderId
        {
            get { return _genderId; }
            set
            {
                _genderId = value;
                this.OnPropertyChanged(() => this.GenderId);
                this.OnPropertyChanged(() => this.GenderName);
            }
        }

        public string GenderName
        {
            get
            {
                return _genderCollection[GenderId - 1].Name;
            }
        }
        public ObservableCollection<Gender> GenderCollection
        {
            get
            {
                return _genderCollection;
            }
            set
            {
                if (_genderCollection == null)
                    _genderCollection = new ObservableCollection<Gender>();

                value = _genderCollection;
            }
        }


        public enum GenderEnum
        {
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
                this.OnPropertyChanged(() => this.Id);
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                this.OnPropertyChanged(() => this.FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                this.OnPropertyChanged(() => this.LastName);
            }
        }

        public string Address1
        {
            get
            {
                return _address1;
            }
            set
            {
                _address1 = value;
                this.OnPropertyChanged(() => this.Address1);
            }
        }

        public string Address2
        {
            get
            {
                return _address2;
            }
            set
            {
                _address2 = value;
                this.OnPropertyChanged(() => this.Address2);
            }
        }

        public string PhoneNumber1
        {
            get
            {
                return _phoneNumber1;
            }
            set
            {
                _phoneNumber1 = value;
                this.OnPropertyChanged(() => this.PhoneNumber1);
            }
        }

        public string PhoneNumber2
        {
            get
            {
                return _phoneNumber2;
            }
            set
            {
                _phoneNumber2 = value;
                this.OnPropertyChanged(() => this.PhoneNumber2);
            }
        }


        public string Email1
        {
            get
            {
                return _email1;
            }
            set
            {
                _email1 = value;
                this.OnPropertyChanged(() => this.Email1);
            }
        }

        public string Email2
        {
            get
            {
                return _email2;
            }
            set
            {
                _email2 = value;
                this.OnPropertyChanged(() => this.Email2);
            }
        }


        public int Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                this.OnPropertyChanged(() => this.Gender);
            }
        }


        public void BeginEdit()
        {
            throw new NotImplementedException();
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            throw new NotImplementedException();
        }
    }


}
