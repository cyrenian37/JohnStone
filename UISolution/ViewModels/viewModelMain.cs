using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.Models;

namespace SunSeven.ViewModels
{
    public class viewModelMain : ViewModelBase, ISupportInitialize
    {
        public viewModelMain()
        {
            this._NavigationItems = new ObservableCollection<NavigationItem>();
        }



        private NavigationItem _SelectedItem;
        public NavigationItem SelectedItem
        {
            get
            {
                return this._SelectedItem;
            }
            set
            {
                if (this._SelectedItem != value)
                {
                    this._SelectedItem = value;
                    this.OnPropertyChanged(() => this.SelectedItem);
                }
            }
        }

        private ObservableCollection<NavigationItem> _NavigationItems;
        public ObservableCollection<NavigationItem> NavigationItems
        {
            get
            {
                return this._NavigationItems;
            }
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            this.SelectedItem = this.NavigationItems.FirstOrDefault();
        }


    }



}
