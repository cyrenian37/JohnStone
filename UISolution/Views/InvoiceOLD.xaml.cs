using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using UISolution.ViewModels;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Invoice : UserControl
    {
        private int rootPageNo;

        private int progressValue;
        private DispatcherTimer progressTimer;
        public event PropertyChangedEventHandler PropertyChanged;

        public Invoice()
        {
            InitializeComponent();

            DataContext = new vmInvoice();
        }

        public Invoice(int pageNo)
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


 

    }
}
