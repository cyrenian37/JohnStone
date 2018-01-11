using SunSeven.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Data;

namespace SunSeven.ViewModels
{

    public class vmEmployee
    {

        private ICollectionView EmployCollection = null;
        private ObservableCollection<HSEmployee> _lsellers;
        private ObservableCollection<HSEmployee> _ldelivers;

        SunSeven.DataSource.JSDataContext lDataContext;

        public vmEmployee()
        {
            lDataContext = new CommonFunction().JSDataContext();

            SalesPerson = new ObservableCollection<DataSource.vEmpDept>();
            foreach(DataSource.vEmpDept l in lDataContext.vEmpDepts.Where(p => p.Department == "Sales" ))
            {
                SalesPerson.Add(l);
            }

            DeliveryPerson = new ObservableCollection<DataSource.vEmpDept>();

            foreach(DataSource.vEmpDept l in lDataContext.vEmpDepts.Where(p => p.Department == "Delivery" ))
            {
                DeliveryPerson.Add(l);
            }
        }

        public ObservableCollection<DataSource.vEmpDept> SalesPerson
        {
            get;
            set;

        }

        public ObservableCollection<DataSource.vEmpDept> DeliveryPerson
        {
            get;
            set;
        }


        public ICollectionView Employees
        {
            get
            {
                Boolean _selectedDept;

                if (this.EmployCollection == null)
                {
                    ObservableCollection<HSEmployee> hsCollection = new ObservableCollection<HSEmployee>();

                    foreach (SunSeven.DataSource.Employee l in lDataContext.Employees)
                    {
                        ObservableCollection<HSDepartment> ldepts = new ObservableCollection<HSDepartment>();

                        foreach (DataSource.Department ll in lDataContext.Departments)
                        {
                            DataSource.Emp_Dept lDept = lDataContext.Emp_Depts.SingleOrDefault(p => p.EmployeeId == l.Id
                                                                        && p.DepartmentId == ll.Id);

                            _selectedDept = true;

                            if (lDept == null)
                                _selectedDept = false;

                            ldepts.Add(new HSDepartment
                            {
                                Id = ll.Id,
                                Name = ll.Name,
                                IsSelected = _selectedDept
                            });
                        }

                        hsCollection.Add(new HSEmployee
                        {
                            Id = l.Id,
                            PersonId = l.PersonId,
                            DateIn = l.DateIn,
                            DateOut = l.DateOut,
                            SelectedPerson = l.Person,
                            Departments = ldepts

                        });
                    }

                    this.EmployCollection = new QueryableCollectionView(hsCollection);
                }

                return this.EmployCollection;
            }

        }
    }

    public class EmployeeType
    {
        public int Id { get; set; }
        public string Detail { get; set; }
    }
}
