using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;

namespace UISolution.Models
{
    public class SiteMap : ViewModelBase, ISupportInitialize
    {
        private bool isBusy;
        private string busyContent;
        private Random random = new Random();

        public SiteMap()
        {
            this._Pages = new ObservableCollection<SitePage>();
        }



        public bool IsBusy
        {
            get { return this.isBusy; }
            set
            {
                if (this.isBusy != value)
                {
                    this.isBusy = value;
                    this.OnPropertyChanged(() => this.IsBusy);

                    if (this.isBusy)
                    {
                        var backgroundWorker = new BackgroundWorker();
                        backgroundWorker.DoWork += this.OnBackgroundWorkerDoWork;
                        backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
                        backgroundWorker.RunWorkerAsync();
                    }
                }
            }
        }

        public string BusyContent
        {
            get { return this.busyContent; }
            set
            {
                if (this.busyContent != value)
                {
                    this.busyContent = value;
                    this.OnPropertyChanged(() => this.BusyContent);
                }
            }
        }

        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            backgroundWorker.DoWork -= this.OnBackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted -= OnBackgroundWorkerRunWorkerCompleted;

            InvokeOnUIThread(() =>
            {
                this.IsBusy = false;
               
            });
        }

        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = null;
        }



        private SitePage _SelectedPage;
        public SitePage SelectedPage
        {
            get
            {
                return this._SelectedPage;
            }
            set
            {
                if (this._SelectedPage != value)
                {
                    this._SelectedPage = value;
                    this.OnPropertyChanged("SelectedPage");
                }
            }
        }

        private ObservableCollection<SitePage> _Pages;
        public ObservableCollection<SitePage> Pages
        {
            get
            {
                return this._Pages;
            }
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            this.SelectedPage = this.Pages.FirstOrDefault();
        }
    }
}
