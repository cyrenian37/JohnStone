using SunSeven.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using Telerik.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class OpenOrder : RadWindow
    {

        public delegate void selecteOrderHander(int OrderId);

        static public event selecteOrderHander selectedOrderCommand;

        SunSeven.DataSource.JSDataContext lDataContext;

        public OpenOrder()
        {
            InitializeComponent();
            lDataContext = new CommonFunction().JSDataContext();

            dtPickerST.SelectedValue = DateTime.Today;
            dtPickerET.SelectedValue = DateTime.Today.AddDays(1).AddSeconds(-1);

            List<DataSource.OpenOrderResult> lOpenOrderSet = new List<DataSource.OpenOrderResult>();
            foreach (DataSource.OpenOrderResult l in lDataContext.OpenOrder(null, null))
            {
                lOpenOrderSet.Add(l);
            }
            this.DataContext = lOpenOrderSet;

            this.textBoxFilterValue.Focus();
        }

        private void RadGridView1_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (selectedOrderCommand != null)
            {
                if (e.AddedItems.Count > 0)
                    selectedOrderCommand((e.AddedItems[0] as DataSource.OpenOrderResult).Id);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (dtPickerST.SelectedValue.Value > dtPickerET.SelectedValue.Value)
            {
                MessageBox.Show("End Date must be bigger than Start Date");
                return;
            }

            if (( dtPickerET.SelectedValue.Value - dtPickerST.SelectedValue.Value ).TotalDays > 60)
            {
                MessageBox.Show("Maximum search window. Less than 60 days");
                return;
            }


            List<DataSource.OpenOrderResult> lOpenOrderSet = new List<DataSource.OpenOrderResult>();
            foreach (DataSource.OpenOrderResult l in lDataContext.OpenOrder(dtPickerST.SelectedValue, dtPickerET.SelectedValue))
            {
                lOpenOrderSet.Add(l);
            }
            this.DataContext = lOpenOrderSet;
        }

        private void RadWindow_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            selectedOrderCommand = null;
        }
    }
}
