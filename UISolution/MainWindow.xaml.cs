using SunSeven.Views;
using System;
using System.Windows;

namespace SunSeven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            this.contentControl.Content = new LogInPage();

           // DataSource.JSDataContext lDataContext = new Models.CommonFunction().JSDataContext();


            //this.Title =  Models.CommonFunction.GetCompanyName();

            this.Title = Models.CommonFunction.GetCompanyInfo().CompanyName;
            this.Title += " (" + Environment.MachineName + ") - Version : " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (MainPage.activeScanner != null)
                if (MainPage.activeScanner.DeviceEnabled)
                {
                    MainPage.activeScanner.Release();
                    MainPage.activeScanner.DeviceEnabled = false;
                    MainPage.activeScanner.Close();
                }

            // MessageBox.Show("Window Closed");
        }
    }
}
