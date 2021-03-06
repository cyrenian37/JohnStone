﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class DataForm : UserControl
    {
        public DataForm()
        {
            InitializeComponent();

            DataContext = new dataFormDataContext();
        }
    }

    public class dataFormDataContext
    {
        private ICollectionView employees = null;
        public ICollectionView Employees
        {
            get
            {
                if (this.employees == null)
                {
                    ObservableCollection<dataPerson> newEmployees = new ObservableCollection<dataPerson>();
                    newEmployees.Add(new dataPerson(new DateTime(2005, 12, 4), "Sarah", "Blake", dataPerson.OccupationPositions.SuppliesManager, "(555) 943-231", 3500));
                    newEmployees.Add(new dataPerson(new DateTime(2008, 3, 21), "Jane", "Simpson", dataPerson.OccupationPositions.Security, "(555) 912-482", 2000));
                    newEmployees.Add(new dataPerson(new DateTime(2005, 12, 4), "John", "Peterson", dataPerson.OccupationPositions.Consultant, "(555) 543-231", 2600));
                    newEmployees.Add(new dataPerson(new DateTime(2005, 12, 4), "Peter", "Bush", dataPerson.OccupationPositions.Casheer, "(555) 943-221", 2300));

                    this.employees = new QueryableCollectionView(newEmployees);
                }
                return this.employees;
            }
        }
    }

    public class dataPerson : IEditableObject, INotifyPropertyChanged
    {
        EmployeeData backupEmplData;
        private DateTime startingDate;
        private string firstName;
        private string lastName;
        private int salary;
        private OccupationPositions occupation;
        private string phoneNum;

        public enum OccupationPositions
        {
            Casheer,
            Consultant,
            Security,
            Supplies,
            SuppliesManager,
            StaffManager,
            HygeneStaff
        }

        public struct EmployeeData
        {
            internal DateTime startingDate;
            internal string firstName;
            internal string lastName;
            internal int salary;
            internal OccupationPositions occupation;
            internal string phoneNum;
        }

        public dataPerson()
        {
            //
        }

        public dataPerson(DateTime startingDate, string fName, string lName, OccupationPositions occ, string phoneNum, int sal)
        {
            this.backupEmplData = new EmployeeData();
            this.backupEmplData.startingDate = startingDate;
            this.StartingDate = startingDate;
            this.backupEmplData.salary = sal;
            this.Salary = sal;
            this.backupEmplData.firstName = fName;
            this.FirstName = fName;
            this.backupEmplData.lastName = lName;
            this.LastName = lName;
            this.backupEmplData.occupation = occ;
            this.Occupation = occ;
            this.backupEmplData.phoneNum = phoneNum;
            this.PhoneNumber = phoneNum;
            this.StartingDate = startingDate;
        }

        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        public OccupationPositions Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                occupation = value;
                NotifyPropertyChanged("Occupation");
            }
        }

        [Display(Name = "Starting Date")]
        public DateTime StartingDate
        {
            get
            {
                return startingDate;
            }
            set
            {
                startingDate = value;
                NotifyPropertyChanged("StartingDate");
            }
        }

        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get
            {
                return phoneNum;
            }
            set
            {
                phoneNum = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        [Description("Last actualization - 03/21/2010")]
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                NotifyPropertyChanged("Salary");
            }
        }



        public void BeginEdit()
        {

        }

        public void CancelEdit()
        {
            Salary = this.backupEmplData.salary;
            StartingDate = this.backupEmplData.startingDate;
            FirstName = this.backupEmplData.firstName;
            LastName = this.backupEmplData.lastName;
            Occupation = this.backupEmplData.occupation;
            PhoneNumber = this.backupEmplData.phoneNum;
        }

        public void EndEdit()
        {
            this.backupEmplData.salary = Salary;
            this.backupEmplData.startingDate = StartingDate;
            this.backupEmplData.firstName = FirstName;
            this.backupEmplData.lastName = LastName;
            this.backupEmplData.occupation = Occupation;
            this.backupEmplData.phoneNum = PhoneNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}

