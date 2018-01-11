using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UISolution.Models;
using UISolution.ViewModels;


namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : UserControl
    {
        private int rootPageNo;


        public Sales()
        {
            InitializeComponent();

            // dockingMain.DataContext = new vmInvoice();
            DataContext = new vmPeople();
        }

        public Sales(int pageNo)
        {
            InitializeComponent();

            DataContext = new vmPeople();

            rootPageNo = pageNo;


            //this.DataContext = this;
            //this.progressTimer = new DispatcherTimer();
            //this.progressTimer.Interval = TimeSpan.FromSeconds(0.1);
            //this.progressTimer.Tick += new EventHandler(this.progressTimer_Tick);


            //switch (pMenu)
            //{
            //    case 1:
            //        txtTitle.Text = "Sales Editor";
            //        transition.Content = new SalesEditor();
            //        radioEditor.IsChecked = true;
            //        radioHist.IsChecked = false;
            //        break;

            //    case 2:

            //        txtTitle.Text = "Sales History";
            //        transition.Content = new SalesHistory();
            //        radioEditor.IsChecked = false;
            //        radioHist.IsChecked = true;
            //        break;
            //}
        }


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new UISolution.Views.HomeMenu(1);
        }

        private void gridviewPriceHistory_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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

        private void gridviewPriceHistory_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            UISolution.DataSource.HanSungLinqDataContext lDataContext = new DataSource.HanSungLinqDataContext();

            foreach (HSPriceHistory l in e.Items)
            {
                DataSource.PriceHistory ldeletedItem = lDataContext.PriceHistories.SingleOrDefault(p => p.Id == l.Id);
                try
                {
                    lDataContext.PriceHistories.DeleteOnSubmit(ldeletedItem);

                    lDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void myRadDataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {
            HSSales lNewItem = new HSSales();

            lNewItem.SalesDate = DateTime.Now;

            (e.NewItem as HSSales).SalesDate = DateTime.Now;
          
        }

        private void gridSalesItem_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            HSOrderItem lNewItem = new HSOrderItem();

            HSSales lCurrentItem = myRadDataForm.CurrentItem as HSSales;

            lNewItem.SalesId = lCurrentItem.Id;
           // lNewItem.VatRate = lCurrentItem.SelectedVatRate;
            lNewItem.SalesStatusId = 1;

            e.NewObject = lNewItem;

            //myRadDataForm
        }

        private void gridSalesItem_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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

        private void gridSalesItem_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            UISolution.DataSource.HanSungLinqDataContext lDataContext = new DataSource.HanSungLinqDataContext();

            foreach (HSOrderItem l in e.Items)
            {
                DataSource.OrderItem ldeletedItem = lDataContext.OrderItems.SingleOrDefault(p => p.Id == l.Id);
                try
                {
                    lDataContext.OrderItems.DeleteOnSubmit(ldeletedItem);

                    lDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }





    }
}
