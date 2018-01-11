using System;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.DataSource;

namespace SunSeven.Models
{
    public class HSDepartment : ViewModelBase, IEditableObject
    {

        private string _name;
        private Boolean _isSelected;


        public int Id { get; set; }

        private JSDataContext lDataContext;

        public HSDepartment()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }

        public Boolean IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                this.OnPropertyChanged(() => this.IsSelected);
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
            DataSource.Department lUpdate = lDataContext.Departments.SingleOrDefault(p => p.Id == this.Id);

            if (lUpdate == null)
            {
                DataSource.Department newItem = new DataSource.Department
                {
                    Name = this.Name

                };
                // Add the new object to the Orders collection.
                lDataContext.Departments.InsertOnSubmit(newItem);

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
                lUpdate.Name = this.Name;


                lDataContext.SubmitChanges();
            }
        }
    }


    public class HSClientType : ViewModelBase, IEditableObject
    {

        private string _type;


        private JSDataContext lDataContext;

        public HSClientType()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }

        public int Id { get; set; }


        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                this.OnPropertyChanged(() => this.Type);
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
            DataSource.ClientType lUpdate = lDataContext.ClientTypes.SingleOrDefault(p => p.Id == this.Id);

            if (lUpdate == null)
            {
                DataSource.ClientType newItem = new DataSource.ClientType
                {
                    Type = this.Type

                };
                // Add the new object to the Orders collection.
                lDataContext.ClientTypes.InsertOnSubmit(newItem);

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
                lUpdate.Type = this.Type;


                lDataContext.SubmitChanges();
            }
        }
    }

    public class HSRole : ViewModelBase, IEditableObject
    {

        private string _name;


        private JSDataContext lDataContext;

        public HSRole()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }

        public int Id { get; set; }


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
            DataSource.Role lUpdate = lDataContext.Roles.SingleOrDefault(p => p.Id == this.Id);

            if (lUpdate == null)
            {
                DataSource.Role newItem = new DataSource.Role
                {
                    Name = this.Name

                };
                // Add the new object to the Orders collection.
                lDataContext.Roles.InsertOnSubmit(newItem);

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
                lUpdate.Name = this.Name;


                lDataContext.SubmitChanges();
            }
        }
    }

   
}
