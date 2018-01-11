using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunSeven.Models
{
    public class UserScreen
    {
        public String ScreenName { get; set; }
        public String ScreenPath { get; set; }
    }

    public class UserScreenSet : List<UserScreen>
    {

    }
}
