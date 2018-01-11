using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for SalesMain.xaml
    /// </summary>
    public partial class SalesMain : UserControl, INotifyPropertyChanged
    {
        private int progressValue;
        private DispatcherTimer progressTimer;
        public event PropertyChangedEventHandler PropertyChanged;

        public SalesMain()
        {
            InitializeComponent();

            this.DataContext = this;
            this.progressTimer = new DispatcherTimer();
            this.progressTimer.Interval = TimeSpan.FromSeconds(0.1);
            this.progressTimer.Tick += new EventHandler(this.progressTimer_Tick);
        }

         public int ProgressValue
        {
            get
            {
                return this.progressValue;
            }
            set
            {
                if (this.progressValue == value)
                    return;
                this.progressValue = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ProgressValue"));
            }
        }

        //private void showIndicatorButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.progressTimer.Start();
        //    this.ProgressValue = 0;
        //    this.busyIndicator.IsBusy = true;
        //}
        private void progressTimer_Tick(object sender, EventArgs e)
        {
            this.ProgressValue++;
            if (this.ProgressValue == 10)
            {
                this.progressTimer.Stop();
                this.busyIndicator.IsBusy = false;
            }
        }

        public SalesMain(int pMenu)
        {
            InitializeComponent();

            this.DataContext = this;
            this.progressTimer = new DispatcherTimer();
            this.progressTimer.Interval = TimeSpan.FromSeconds(0.1);
            this.progressTimer.Tick += new EventHandler(this.progressTimer_Tick);
        
         
            switch (pMenu)
            {
                case 1:
                    txtTitle.Text = "Sales Editor";
                    transition.Content = new SalesEditor();
                    radioEditor.IsChecked = true;
                    radioHist.IsChecked = false;
                    break;

                case 2:
                  
                    txtTitle.Text = "Sales History";
                    transition.Content = new SalesHistory();  
                    radioEditor.IsChecked = false;
                    radioHist.IsChecked = true;
                    break;
            }
            

        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new UISolution.Views.HomeMenu(1);
        }


        private void btnSalesEditor_Click(object sender, RoutedEventArgs e)
        {
            this.progressTimer.Start();
            this.ProgressValue = 0;
            this.busyIndicator.IsBusy = true;

            txtTitle.Text = "Sales Editor";
            transition.Content = new SalesEditor();
        }

        private void btnSalesHisotry_Click(object sender, RoutedEventArgs e)
        {
            this.progressTimer.Start();
            this.ProgressValue = 0;
            this.busyIndicator.IsBusy = true;
            txtTitle.Text = "Sales History";
            transition.Content = new SalesHistory();
        }

        private void radioEditor_Checked(object sender, RoutedEventArgs e)
        {
            

            try
            {
                this.progressTimer.Start();
                this.ProgressValue = 0;
                this.busyIndicator.IsBusy = true;

                if ((e.Source as RadioButton).IsChecked.Value)
                {
                    txtTitle.Text = "Sales Editor";
                    transition.Content = new SalesEditor();
                }
                else
                {
                    txtTitle.Text = "Sales History";
                    transition.Content = new SalesHistory();
                }
            }
            catch
            { }
        }

        private void radioHist_Checked(object sender, RoutedEventArgs e)
        {


            try
            {
                this.progressTimer.Start();
                this.ProgressValue = 0;
                this.busyIndicator.IsBusy = true;

                if ((e.Source as RadioButton).IsChecked.Value)
                {
                    txtTitle.Text = "Sales History";
                    transition.Content = new SalesHistory();
                  
                }
                else
                {
                    txtTitle.Text = "Sales Editor";
                    transition.Content = new SalesEditor();
                }
            }
            catch
            { }
        }
    }

}
