using SunSeven;
using System.Threading;
using System.Windows;

namespace UISolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string MutexName = "##||ThisApp||##";
        // declare the mutex
        private readonly Mutex _mutex;
        // overload the constructor
        bool createdNew;
        public App()
        {
            // overloaded mutex constructor which outs a boolean
            // telling if the mutex is new or not.
            // see http://msdn.microsoft.com/en-us/library/System.Threading.Mutex.aspx

            _mutex = new Mutex(true, MutexName, out createdNew);
            if (!createdNew)
            {
                // if the mutex already exists, notify and quit
                MessageBox.Show("Application is already running");
                Application.Current.Shutdown(0);
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!createdNew) return;
            // overload the OnStartup so that the main window 
            // is constructed and visible
            MainWindow mw = new MainWindow();
            //SunSeven.Views.ScanEditor mw = new SunSeven.Views.ScanEditor();
            
            mw.Show();

        }
    }
}
