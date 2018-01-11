using SunSeven.Models;
using SunSeven.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for ProductWin.xaml
    /// </summary>
    public partial class ScreenSelection : RadWindow
    {
        public delegate void selecteProductHander(List<JSProduct> selectedProducts);

        public static event selecteProductHander selecteProductCommand;

        private SunSeven.DataSource.JSDataContext lDataContext;
        public ScreenSelection()
        {
            InitializeComponent();

            DataContext = new Models.ScreenSet(1);

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.btnApply.IsEnabled = false;
                this.lbScreen.IsEnabled = false;
            }


        }

        public ScreenSelection(int UserId)
        {
            InitializeComponent();

            DataContext = new Models.ScreenSet(UserId);

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.btnApply.IsEnabled = false;
                this.lbScreen.IsEnabled = false;
            }
        }


        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Apply_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            //List<JSProduct> lSelectedProducts = new List<JSProduct>();

            //if (this.RadGridView1.SelectedItems.Count <= 0)
            //{
            //    MessageBox.Show("Please select product.");
            //    return;
            //}

            //foreach (JSProduct l in this.RadGridView1.SelectedItems)
            //{
            //    lSelectedProducts.Add(l);
            //}

            //if (selecteProductCommand != null)
            //{
            //    selecteProductCommand(lSelectedProducts);
            //}

           

        }

     
    }
}
