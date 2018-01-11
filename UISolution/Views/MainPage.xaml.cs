
using Microsoft.PointOfService;
using SunSeven.DataSource;
using SunSeven.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows;
using Telerik.Windows.Controls;


namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        private PosExplorer devExplorer;
        static public Scanner activeScanner;

        public delegate MessageBoxResult CloseWinHander(string PageId);
        public static event CloseWinHander CloseCommand;

        public static User lCurrentUser;
        private DataSource.JSDataContext lDataContext;
        private UserScreenSet UserScreens;

        public delegate void scanHandler(string invoiceNo);

        static public event scanHandler  scanCommand;

        private string gCurrentMenu = "";
       

        public MainPage()
        {
            InitializeComponent();
            CloseCommand = null;
        }


        public MainPage(User pUser)
        {

            InitializeComponent();

            CloseCommand = null;

            lDataContext = new CommonFunction().JSDataContext();

            UserScreens = new UserScreenSet();

            lCurrentUser = pUser;

            this.txtUser.Text = pUser.UserName + " / " + pUser.UserRole.Name;

            var lUserScreen = from us in lDataContext.UserScreens
                              join s in lDataContext.Screens
                              on us.ScreenId equals s.ScreenId
                              where us.UserId == pUser.Id
                              select new
                              {
                                  s.ScreenName,
                                  s.ScreenPath,
                                  us.Default,
                              };

            var DefaultScreen = lUserScreen.SingleOrDefault(p => p.Default == true);

            foreach (var l in lUserScreen)
            {
                UserScreens.Add(new Models.UserScreen { ScreenName = l.ScreenName, ScreenPath = l.ScreenPath });
            }

            if (DefaultScreen != null)
                OpenMenu(DefaultScreen.ScreenPath);
           
        }

#region SCANNER
        private void InitializeScanner()
        {
            if (activeScanner != null)
                if (activeScanner.DeviceEnabled || activeScanner.DataEventEnabled)
                {
                    MessageBox.Show("USB Bar Scanner already enabled.");
                    return;
                }

            try
            {
                devExplorer = new PosExplorer();

                try
                {

                    DeviceCollection lUSBScanners = devExplorer.GetDevices(DeviceType.Scanner);

                    foreach (DeviceInfo devInfo in lUSBScanners)
                    {
                        if (devInfo.ServiceObjectName == "USBHHScanner")
                        {
                            if (activeScanner == null)
                                activeScanner = devExplorer.CreateInstance(devInfo) as Scanner;
                            activeScanner.Open();
                            activeScanner.AutoDisable = true;
                            activeScanner.DecodeData = true;
                            activeScanner.Claim(1000);
                            activeScanner.DataEvent += new DataEventHandler(activeScanner_DataEvent);
                            activeScanner.ErrorEvent += new DeviceErrorEventHandler(activeScanner_ErrorDataEvent);
                            activeScanner.DataEventEnabled = true;
                            activeScanner.DeviceEnabled = true;

                        }
                    }
                }
                catch (Exception ex)
                {
                    if (activeScanner.DataEventEnabled)
                    {
                        activeScanner.Release();
                        activeScanner.DeviceEnabled = true;
                    }
                    MessageBox.Show("Failed to find USB Scanner : " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pos Explorer : " + ex.Message);
            }

        }
        private void activeScanner_ErrorDataEvent(object sender, DeviceErrorEventArgs e)
        {
            MessageBox.Show(e.ErrorCode.ToString());
        }


        private void activeScanner_DataEvent(object sender, DataEventArgs e)
        {
            if (!MainPage.lCurrentUser.Dempartments.Contains("Account"))
            {
                MessageBox.Show("Only Account and Not Read Only are allowed.");
                return;
            }

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                MessageBox.Show("Only Account and Not Read Only are allowed.");
                return;
            }

            ASCIIEncoding encoding = new ASCIIEncoding();

            string ScanData = encoding.GetString(activeScanner.ScanDataLabel);

            ScanInvoice(ScanData);

            activeScanner.DataEventEnabled = true;
            activeScanner.DeviceEnabled = true;

        }

        private void ScanInvoice(string invoiceNo)
        {
            if (PagePresenter.Content == null || !PagePresenter.Content.GetType().Name.Contains("ScanEditor"))
            {
                txtTitle.Text = "Scan Editor";

                PagePresenter.Content = new ScanEditor();

                ScanEditor.scannedOrderCommand -= ScanEditor_scannedOrderCommand;
                ScanEditor.scannedOrderCommand += ScanEditor_scannedOrderCommand;
                gCurrentMenu = txtTitle.Text;           
            }

            scanCommand?.Invoke(invoiceNo);
        }

#endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!MainPage.lCurrentUser.Dempartments.Contains("Account"))
            {
                MessageBox.Show("Only Account and Not Read Only are allowed.");
                return;
            }

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                MessageBox.Show("Only Account and Not Read Only are allowed.");
                return;
            }

            if (PagePresenter.Content == null || !PagePresenter.Content.GetType().Name.Contains("ScanEditor"))
            {
                txtTitle.Text = "Scan Editor";

                PagePresenter.Content = new ScanEditor();

                ScanEditor.scannedOrderCommand -= ScanEditor_scannedOrderCommand;
                ScanEditor.scannedOrderCommand += ScanEditor_scannedOrderCommand;
                gCurrentMenu = txtTitle.Text;
            }


            scanCommand?.Invoke(txtInvoice.Text);

            //if (scanCommand != null)
            //{
            //    scanCommand(txtInvoice.Text);
            //}


        }

        private void ScanEditor_scannedOrderCommand(int orderId)
        {
            PagePresenter.Content = new OrderEditor(orderId);
            txtTitle.Text = "ORDER/Order Detail/Edit Order";
            gCurrentMenu = txtTitle.Text;

            ScanEditor.scannedOrderCommand -= ScanEditor_scannedOrderCommand;

        }

        private void OpenOrder_SelectedOrderCommand(int OrderId)
        {
            PagePresenter.Content = new OrderEditor(OrderId);
            txtTitle.Text = "ORDER/Order Detail/Edit Order";
            gCurrentMenu = txtTitle.Text;

           // OpenOrder.selectedOrderCommand -= OpenOrder_SelectedOrderCommand;
          
        }

        private void OpenSupply_selectedSupplyCommand(int OrderId)
        {
            PagePresenter.Content = new OrderEditor(OrderId);
            txtTitle.Text = "SUPPLY/Supply Detail/Edit Supply";
            gCurrentMenu = txtTitle.Text;

            OpenSupply.selectedSupplyCommand -= OpenSupply_selectedSupplyCommand;
        }

        private void OpenQuotation_selectedSalesCommand(int SalesId)
        {
            PagePresenter.Content = new QuotationEditor(SalesId);
            txtTitle.Text = "ORDER/Quotation Detail/Edit Quotation";
            gCurrentMenu = txtTitle.Text;
        }

        private void OpenOrder_SelectedHistoryCommand(int? OrderId)
        {
            if (OrderId == null)
            {
                MessageBox.Show("Not found Selected Order");
                return;
            }

            PagePresenter.Content = new OrderEditor(OrderId);
            txtTitle.Text = "ORDER/Order Detail/Edit Order";
            gCurrentMenu = txtTitle.Text;
        }

        private void OpenQuotation_SelectedHistoryCommand(int SalesId)
        {
            PagePresenter.Content = new QuotationEditor(SalesId);
            txtTitle.Text = "ORDER/Quotation Detail/Edit Quotation";
            gCurrentMenu = txtTitle.Text;
        }



        private void Menu_ItemClick(object sender, RadRoutedEventArgs e)
        {

            MessageBoxResult lRetBox = MessageBoxResult.None;
            RadMenuItem menuItem = (e.OriginalSource as RadMenuItem);

            string concatinatedName = GetMenuItemExpandedName(menuItem);

            var lScreen = lDataContext.Screens.Where(p => p.ScreenPath == concatinatedName.ToUpper() && p.Usable == true);


            if (!concatinatedName.ToUpper().Contains("LOGOUT"))
            {
                if (lScreen.Count() > 0)
                {
                    var lAccessPage = UserScreens.Where(p => p.ScreenPath == concatinatedName.ToUpper());

                    if (lAccessPage.Count() <= 0)
                    {
                        MessageBox.Show("Access Page Error : Not allowed to access [" + concatinatedName + "]");
                        return;
                    }
                }
            }
        
            

            if (!concatinatedName.ToUpper().Contains("REPORT"))
            {
                if (CloseCommand != null)
                {
                    lRetBox = CloseCommand(concatinatedName);                                      
                }

                if (lRetBox == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            foreach (Window l in MainWindow.GetWindow(this).OwnedWindows)
            {
                l.Close();
            }

            
            //Delegate.RemoveAll(MainPage.CloseCommand, MainPage.CloseCommand);

            OpenMenu(concatinatedName);

        }


        private void OpenMenu(string menePath)
        {

            System.Windows.Window lAppWin = Models.CommonFunction.GetApplicationWindow();

            SunSeven.Reports.ReportViewer lRptViewer;

            switch (menePath.ToUpper())
            {
                case "ORDER/ORDER DETAIL/NEW ORDER":
                    PagePresenter.Content = new OrderEditor();
                    txtTitle.Text = menePath;
                    break;
                case "ORDER/ORDER DETAIL/OPEN ORDER":

                    RadWindow lHSWin = new OpenOrder();

                    lHSWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

                    OpenOrder.selectedOrderCommand -= OpenOrder_SelectedOrderCommand;
                    OpenOrder.selectedOrderCommand += OpenOrder_SelectedOrderCommand;

                    if (lAppWin != null)
                        lHSWin.Owner = lAppWin;

                    lHSWin.Show();


                    break;
                case "ORDER/ORDER DETAIL/ORDER HISTORY":
                    OrderHistory lOrderHistoryWin = new OrderHistory();

                    OrderHistory.selectedOrderHistoryCommand -= OpenOrder_SelectedHistoryCommand;
                    OrderHistory.selectedOrderHistoryCommand += OpenOrder_SelectedHistoryCommand;
                    PagePresenter.Content = lOrderHistoryWin;

                    txtTitle.Text = menePath;
                    break;

                case "ORDER/QUOTATION DETAIL/NEW QUOTATION":
                    PagePresenter.Content = new QuotationEditor();
                    txtTitle.Text = menePath;
                    break;

                case "ORDER/QUOTATION DETAIL/OPEN QUOTATION":

                    RadWindow lHSSalesWin = new OpenQuotation("QUOTATION");

                    lHSSalesWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

                    OpenQuotation.selectedSalesCommand -= OpenQuotation_selectedSalesCommand;
                    OpenQuotation.selectedSalesCommand += OpenQuotation_selectedSalesCommand;

                    if (lAppWin != null)
                        lHSSalesWin.Owner = lAppWin;

                    lHSSalesWin.ShowDialog();


                    break;
                case "ORDER/QUOTATION DETAIL/OPEN MASTER QUOTATION":

                    RadWindow lHSMasterSalesWin = new OpenQuotation("MASTER");


                    lHSMasterSalesWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

                    OpenQuotation.selectedSalesCommand -= OpenQuotation_selectedSalesCommand;
                    OpenQuotation.selectedSalesCommand += OpenQuotation_selectedSalesCommand;

                    if (lAppWin != null)
                        lHSMasterSalesWin.Owner = lAppWin;

                    lHSMasterSalesWin.ShowDialog();

                    break;

                case "ORDER/QUOTATION DETAIL/QUOTATION HISTORY":
                    QuotationHistory lQuotationHistoryWin = new QuotationHistory();

                    QuotationHistory.selectedQuotationHistoryCommand -= OpenQuotation_SelectedHistoryCommand;
                    QuotationHistory.selectedQuotationHistoryCommand += OpenQuotation_SelectedHistoryCommand;

                    PagePresenter.Content = lQuotationHistoryWin;

                    txtTitle.Text = menePath;
                    break;

                case "SUPPLY/SUPPLY DETAIL/NEW SUPPLY":
                    PagePresenter.Content = new SupplyEditor();
                    txtTitle.Text = menePath;
                    break;

                case "SUPPLY/SUPPLY DETAIL/OPEN SUPPLY":

                    RadWindow lSupplyWin = new OpenSupply();

                    lSupplyWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

                    OpenSupply.selectedSupplyCommand -= OpenSupply_selectedSupplyCommand;
                    OpenSupply.selectedSupplyCommand += OpenSupply_selectedSupplyCommand;

                    if (lAppWin != null)
                        lSupplyWin.Owner = lAppWin;

                    lSupplyWin.Show();


                    break;

                case "SUPPLY/SUPPLY DETAIL/SUPPLY HISTORY":
                    SupplyHistory lSupplyHistoryWin = new SupplyHistory();

                    //OrderHistory.selectedOrderHistoryCommand -= OpenOrder_SelectedHistoryCommand;
                    //OrderHistory.selectedOrderHistoryCommand += OpenOrder_SelectedHistoryCommand;
                    PagePresenter.Content = lSupplyHistoryWin;

                    txtTitle.Text = menePath;
                    break;


                case "PRODUCT/PRODUCT DETAIL/PRODUCT EDITOR":
                    PagePresenter.Content = new ProductEditor();

                    txtTitle.Text = menePath;
                    break;
                case "PRODUCT/CATEGORY/CATEGORY":
                    PagePresenter.Content = new Configuration();
                    txtTitle.Text = menePath;

                    break;

                case "REPORT/ORDER/ORDER REPORT":

                    lRptViewer = new Reports.ReportViewer(1);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();

                    break;
                case "REPORT/ORDER/ORDER BY CUSTOMER":
                    lRptViewer = new Reports.ReportViewer(1);


                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();
                    break;


                case "REPORT/PRODUCT/PRODUCT DELIVERY LIST":

                    lRptViewer = new Reports.ReportViewer(6);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();
                    break;

                case "REPORT/PRODUCT/PRODUCT DELIVERY LIST 2":

                    lRptViewer = new Reports.ReportViewer(9);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();
                    break;

                case "REPORT/ORDER/CUSTOMER ORDER SUM":

                    lRptViewer = new Reports.ReportViewer(7);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();
                    break;


                case "REPORT/PRODUCT/PRODUCT SUM":

                    lRptViewer = new Reports.ReportViewer(8);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();
                    break;


                case "REPORT/PACKING/PACKING LIST":

                    lRptViewer = new Reports.ReportViewer(4);
                    // lRptViewerPackaging.ReportInitialize(5);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();
                    break;

                case "REPORT/PACKING/DELIVERY LIST":

                    lRptViewer = new Reports.ReportViewer(2);
                    // lRptViewerPackaging2.ReportInitialize(5);

                    if (lAppWin != null)
                        lRptViewer.Owner = lAppWin;

                    lRptViewer.ShowDialog();

                    break;

                case "ADMIN/BASE/PEOPLE":
                    PagePresenter.Content = new People();
                    txtTitle.Text = menePath;
                    break;
                case "ADMIN/CONTACT/EMPLOYEE":
                    PagePresenter.Content = new Employee();
                    txtTitle.Text = menePath;
                    break;
                case "ADMIN/CONTACT/CUSTOMER":
                    PagePresenter.Content = new Customer();
                    txtTitle.Text = menePath;
                    break;
                case "ADMIN/CONTACT/SUPPLIER":
                    PagePresenter.Content = new Suppliers();
                    txtTitle.Text = menePath;
                    break;
                case "ADMIN/CONFIGURATION/CONFIGURATION":
                    PagePresenter.Content = new Configuration();
                    txtTitle.Text = menePath;
                    break;
                case "ADMIN/CONFIGURATION/SCAN INVOICE":
                    PagePresenter.Content = new ScanEditor();

                    ScanEditor.scannedOrderCommand -= ScanEditor_scannedOrderCommand;
                    ScanEditor.scannedOrderCommand += ScanEditor_scannedOrderCommand;

                    txtTitle.Text = menePath;
                    break;                    
                case "SETTINGS/LOGOUT":
                    ((SunSeven.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new SunSeven.Views.LogInPage();
                    break;
                case "SETTINGS/ROLE":
                    PagePresenter.Content = new Security();
                    txtTitle.Text = menePath;
                    break;
                case "SETTINGS/SUPPORT":
                    break;
                case "SETTINGS/RESET SCANNER":
                    InitializeScanner();
                    break;
                case "CLOSE":
                    PagePresenter.Content = null;
                    break;
                default:
                    break;

            }
        }

        private static string GetMenuItemExpandedName(RadMenuItem menuItem)
        {
            string concatinatedName = string.Empty;
            while (menuItem != null)
            {
                string name = GetMenuItemName(menuItem);
                if (!string.IsNullOrEmpty(name))
                {
                    concatinatedName = name + (concatinatedName == string.Empty ? string.Empty : "/" + concatinatedName);
                }

                menuItem = menuItem.Parent as RadMenuItem;
            }

            return concatinatedName;
        }


        private static string GetMenuItemName(RadMenuItem menuItem)
        {
            string name = null;
            if (menuItem.Tag != null)
            {
                name = Convert.ToString(menuItem.Tag, CultureInfo.InvariantCulture);
            }
            else if (menuItem.Header != null)
            {
                name = Convert.ToString(menuItem.Header, CultureInfo.InvariantCulture);
            }

            return name;
        }


        //private void PopupMenu_Click(object sender, RadRoutedEventArgs e)
        //{
        //    RadMenuItem menuItem = (e.OriginalSource as RadMenuItem);
        //    string concatinatedName = GetMenuItemExpandedName(menuItem);
        //}

    }
}
