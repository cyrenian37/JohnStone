using SunSeven.Models;
using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class OpenSupply : RadWindow
    {


        public delegate void selecteSupplyHander(int OrderId);

        static public event selecteSupplyHander selectedSupplyCommand;

        SunSeven.DataSource.JSDataContext lDataContext;

        public OpenSupply()
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
            if (selectedSupplyCommand != null)
            {
                if (e.AddedItems.Count > 0)
                    selectedSupplyCommand((e.AddedItems[0] as DataSource.OpenOrderResult).Id);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            List<DataSource.OpenOrderResult> lOpenOrderSet = new List<DataSource.OpenOrderResult>();
            foreach (DataSource.OpenOrderResult l in lDataContext.OpenOrder(dtPickerST.SelectedValue, dtPickerET.SelectedValue))
            {
                lOpenOrderSet.Add(l);
            }
            this.DataContext = lOpenOrderSet;
        }


    }
}
