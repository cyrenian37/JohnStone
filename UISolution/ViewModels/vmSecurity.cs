using SunSeven.DataSource;
using SunSeven.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.ViewModels
{


    public class vmSecurity 
    {

        private ICollectionView people = null;

        

        SunSeven.DataSource.JSDataContext lDataContext;

        public vmSecurity()
        {
            lDataContext = new CommonFunction().JSDataContext();

            this.Employees = new List<Employee>();
            this.Roles = new List<Role>();

            foreach (DataSource.Employee l in lDataContext.Employees)
            {
                
                this.Employees.Add(l);
            }

            foreach (DataSource.Role l in lDataContext.Roles)
            {
                this.Roles.Add(l);
            }

            
        }

    

        public List<DataSource.Employee> Employees
        {
            get;
            set;
        }

        public List<DataSource.Role> Roles
        {
            get;
            set;
        }
        public ObservableCollection<HSSecurity> SecuritySet
        {
            get
            {
                ObservableCollection<HSSecurity> securityCollection = new ObservableCollection<HSSecurity>();

                foreach (SunSeven.DataSource.Security l in lDataContext.Securities)
                {
                    securityCollection.Add(new HSSecurity
                    {
                        Id = l.Id,
                        UserName = l.UserName,
                        Password = l.Password,
                        EmployeeId = l.EmployeeId,
                        RoleId = l.RoleId,
                        PageId = l.DefaultPage,
                        AccessLevel = l.AccessLevel                        
                    });
                }

                return securityCollection;
            }
        }
    }
}
