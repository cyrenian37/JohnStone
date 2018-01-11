// ReSharper disable RedundantUsingDirective
// ReSharper restore RedundantUsingDirective

using SunSeven.DataSource;
using System.Collections.Generic;
using System.Linq;

namespace SunSeven.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMailAddress { get; set; }
        public string ImageSourcePath { get; set; }

        public int? AccessLevel { get; set; }

        public DataSource.Role UserRole { get; set; }

        public System.Data.Linq.Binary UserImage { get; set; }

        public DataSource.Employee Employee { get; set; }

        public List<string> Dempartments
        {
            get
            {
                List<string> EmpDepts = new List<string>();
                JSDataContext lDataContext = new CommonFunction().JSDataContext();
                var lDeps = lDataContext.vEmpDepts.Where(p => p.Id == this.Employee.Id);


                foreach (DataSource.vEmpDept l in lDeps)
                {
                    EmpDepts.Add(l.Department);
                }

                return EmpDepts;
            }

        }
    }
}
