using SunSeven.Models;
using System.Linq;
using Telerik.Windows.Controls;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class OpenQuotation : RadWindow
    {
        private SunSeven.DataSource.JSDataContext lDataContext;

        public delegate void selecteSalesHander(int SalesId);

        static public event selecteSalesHander selectedSalesCommand;

        public delegate void newOrderHander(int SalesId);

        //static public event newOrderHander newOrderCommand;


        public OpenQuotation()
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();

            this.DataContext = lDataContext.Sales;
            textBoxFilterValue.Focus();
            //new vmSalesHistory();

        }

        public OpenQuotation(string pType)
        {
            InitializeComponent();

            lDataContext = new CommonFunction().JSDataContext();

            switch (pType)
            {
                case "QUOTATION":
                    this.DataContext = lDataContext.Sales.Where(p => p.Master == false);
                    this.Header = "Open Quotation";
                    break;
                case "MASTER":
                    this.DataContext = lDataContext.Sales.Where(p => p.Master == true);
                    this.Header = "Open Master Quotation";
                    break;
            }

            textBoxFilterValue.Focus();
            //new vmSalesHistory();

        }

        private void RadGridView1_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (selectedSalesCommand != null)
            {
                selectedSalesCommand((e.AddedItems[0] as DataSource.Sale).Id);
            }
        }

        private void RadWindow_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            selectedSalesCommand = null;
        }
    }
}
