using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UISolution.Models;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class PriceHistCompact : UserControl
    {
        public PriceHistCompact()
        {
            InitializeComponent();

            // DataContext = new vmPriceHistory();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new UISolution.Views.HomeMenu(0);
        }

        private void RadGridView1_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        {

            var lWindows = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains("John Stone Vegetable"));

            if (lWindows == null)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete",
                      MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
            else
            {
                if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                          MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }


        }

        private void RadGridView1_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            UISolution.DataSource.HanSungLinqDataContext lDataContext = new DataSource.HanSungLinqDataContext();

            foreach (HSPriceHistory l in e.Items)
            {
                DataSource.PriceHistory ldeletedItem = lDataContext.PriceHistories.SingleOrDefault(p => p.Id == l.Id);
                try
                {
                    lDataContext.PriceHistories.DeleteOnSubmit(ldeletedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
