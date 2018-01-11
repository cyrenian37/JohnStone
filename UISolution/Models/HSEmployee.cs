using SunSeven.DataSource;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{

    public class HSEmployee : ViewModelBase, IEditableObject
    {
        private int _id;
        private int? _personId;
        private DateTime? _dateIn;
        private DateTime? _dateOut;
        private int? _role;
        private string _roleName;
        private int? _departmentId;

        private DataSource.Person _selectedPerson;


        ObservableCollection<HSDepartment> _departments;

        backupPeopleData backupData;

        SunSeven.DataSource.JSDataContext lDataContext;

        public HSEmployee()
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

        public int? PersonId
        {
            get
            {
                return _personId;
            }
            set
            {
                _personId = value;
            }

        }

        [Required(ErrorMessage = "Employee Name is required")]
        public DataSource.Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                this.OnPropertyChanged(() => this.SelectedPerson);
                this.OnPropertyChanged(() => this.FirstName);
                this.OnPropertyChanged(() => this.LastName);
            }
        }

        public int? DepartmentId
        {
            get
            {
                return _departmentId;
            }
            set
            {
                _departmentId = value;
                this.OnPropertyChanged(() => this.DepartmentId);
                //this.OnPropertyChanged(() => this.Department);
            }

        }

        public System.Linq.IQueryable<Emp_Dept> EmpDept
        {
            get
            {
                var l = lDataContext.Emp_Depts.Where(p => p.EmployeeId == this.Id);

                return l;
            }
        }

        public ObservableCollection<HSDepartment> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value;
            }
        }


        public string EmployeeDetail
        {
            get
            {
                if (this.SelectedPerson != null)
                    return this.SelectedPerson.LastName + "," + this.SelectedPerson.FirstName + " (" + this.SelectedPerson.Address1 + ")";

                return null;
            }
        }

        //public Department Department
        //{
        //    get
        //    {
        //        return DepartmentCollection.SingleOrDefault(p => p.Id == this.DepartmentId);
        //    }
        //    set
        //    {
        //        _department = value;
        //        this.OnPropertyChanged(() => this.Department);
        //    }
        //}

        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                if (SelectedPerson != null)
                    return SelectedPerson.FirstName;
                else
                    return null;
            }
            //set
            //{
            //    _firstName = value;
            //    this.OnPropertyChanged(() => this.FirstName);
            //}
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                if (SelectedPerson != null)
                    return SelectedPerson.LastName;
                else
                    return null;
            }
            //set
            //{
            //    _lastName = value;
            //    this.OnPropertyChanged(() => this.LastName);
            //}
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public DateTime? DateIn
        {
            get
            {
                return _dateIn;
            }
            set
            {
                _dateIn = value;
                this.OnPropertyChanged(() => this.DateIn);
            }
        }


        public DateTime? DateOut
        {
            get
            {
                return _dateOut;
            }
            set
            {
                _dateOut = value;
                this.OnPropertyChanged(() => this.DateOut);
            }
        }


        public int? Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                this.OnPropertyChanged(() => this.Role);
            }

        }

        public string RoleName
        {
            get { return _roleName; }
        }

        public struct backupPeopleData
        {

            internal int? personId;
            internal DateTime? datein;
            internal DateTime? dateout;


            internal ObservableCollection<HSDepartment> departments;
            internal Person selectedPerson;

        }


        public void BeginEdit()
        {

            this.backupData.personId = this.PersonId;
            this.backupData.datein = this.DateIn;
            this.backupData.dateout = this.DateOut;

            this.backupData.departments = this.Departments;
            this.backupData.selectedPerson = this.SelectedPerson;

        }

        public void CancelEdit()
        {

            this.PersonId = this.backupData.personId;
            this.DateIn = this.backupData.datein;
            this.DateOut = this.backupData.dateout;
            this.Departments = this.backupData.departments;
            this.SelectedPerson = this.backupData.selectedPerson;

            //if (this.Departments != null)
            //{
            //    foreach (HSDepartment l in this.Departments)
            //    {
            //        DataSource.Emp_Dept lEmpDept = lDataContext.Emp_Depts.FirstOrDefault(p => p.EmployeeId == this.Id && p.DepartmentId == l.Id);

            //        l.IsSelected = true;

            //        if (lEmpDept == null)
            //            l.IsSelected = false;
            //    }



            //    this.OnPropertyChanged(() => this.Departments);
            //}


            foreach (HSDepartment l in this.Departments ?? Enumerable.Empty<HSDepartment>())
            {
                DataSource.Emp_Dept lEmpDept = lDataContext.Emp_Depts.FirstOrDefault(p => p.EmployeeId == this.Id && p.DepartmentId == l.Id);

                l.IsSelected = true;

                if (lEmpDept == null)
                    l.IsSelected = false;
            }

            this.OnPropertyChanged(() => this.Departments);
            this.OnPropertyChanged(() => this.SelectedPerson);

        }

        public void EndEdit()
        {
            Boolean lChanged = false;
            DataSource.Employee lUpdate = lDataContext.Employees.SingleOrDefault(p => p.Id == this.Id);


            if (lUpdate == null)
            {
                DataSource.Employee newItem = new DataSource.Employee
                {
                    PersonId = this.PersonId,
                    DateIn = this.DateIn,
                    DateOut = this.DateOut,
                };
                // Add the new object to the Orders collection.
                lDataContext.Employees.InsertOnSubmit(newItem);

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
                lUpdate.PersonId = this.PersonId;
                lUpdate.DateIn = this.DateIn;
                lUpdate.DateOut = this.DateOut;

                lDataContext.SubmitChanges();
            }

            DataSource.Emp_Dept lEmpDept;

            foreach (HSDepartment l in this.Departments)
            {

                lEmpDept = lDataContext.Emp_Depts.SingleOrDefault(p => p.EmployeeId == this.Id && p.DepartmentId == l.Id);


                if (lEmpDept == null)
                {
                    if (l.IsSelected)
                    {
                        DataSource.Emp_Dept newEmpDept = new DataSource.Emp_Dept
                        {
                            EmployeeId = this.Id,
                            DepartmentId = l.Id
                        };
                        // Add the new object to the Orders collection.
                        lDataContext.Emp_Depts.InsertOnSubmit(newEmpDept);
                        lChanged = true;
                    }
                }
                else
                {
                    if (l.IsSelected)
                    {
                        lEmpDept.EmployeeId = this.Id;
                        lEmpDept.DepartmentId = l.Id;
                    }
                    else
                        lDataContext.Emp_Depts.DeleteOnSubmit(lEmpDept);

                    lChanged = true;

                }

                try
                {
                    if (lChanged)
                        lDataContext.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }


        }

        public void DeleteEnd()
        {
            //var deleteOrderDetails =
            //    from details in lContext.Persons
            //    where details.Id  == this.Id 
            //    select details;


            DataSource.Employee lDeleted = lDataContext.Employees.SingleOrDefault(p => p.Id == this.Id);

            if (lDeleted != null)
            {
                lDataContext.Employees.DeleteOnSubmit(lDeleted);

                try
                {
                    lDataContext.SubmitChanges();
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
