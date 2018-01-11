using SunSeven.Models;
using SunSeven.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace SunSeven
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SunSeven.DataSource.JSDataContext lDataContext;
        public Window1()
        {
            InitializeComponent();




            lDataContext = new CommonFunction().JSDataContext();


        }

        private void radGridUnit_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            //HSProductUnit lunit = new HSProductUnit();
            //lunit.ProductId = 1;
            //lunit.UnitId = 1;
            //e.NewObject = lunit;
        }

      
    }
}
