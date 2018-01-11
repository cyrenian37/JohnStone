using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{
    public class JSScreen : ViewModelBase
    {
        private SunSeven.DataSource.JSDataContext lDataContext;

        private Boolean _isDefault;
        public Boolean IsDefault
        {
            get { return _isDefault; }
            set
            {
                _isDefault = value;
                OnPropertyChanged(() => IsDefault);

                if (_isDefault)
                    this.IsSelected = _isDefault;
            }
        }

        private Boolean _isselected;
        public Boolean  IsSelected
        {
            get { return _isselected; }
            set
            {
                _isselected = value;
                OnPropertyChanged(() => IsSelected);

                if (!_isselected)
                {
                    this._isDefault = _isselected;
                    OnPropertyChanged(() => IsDefault);
                }
            }
        }

       
        public DataSource.Screen ScreenAvailable
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }
       
    }

    public class ScreenSet : ObservableCollection<JSScreen>
    {
        private SunSeven.DataSource.JSDataContext lDataContext;

        public ICommand applyCommand { get; set; }

        public int UserId { get; set; }

        public ScreenSet(int UserId)
        {
            this.UserId = UserId;

            lDataContext = new CommonFunction().JSDataContext();

            this.applyCommand = new DelegateCommand(OnApplyCommandExecuted);

            Boolean isSelected;
            Boolean isDefault;

            IQueryable<DataSource.UserScreen> lUser = lDataContext.UserScreens.Where(p => p.UserId == UserId);

            foreach (DataSource.Screen l in lDataContext.Screens.Where(p => p.ParentId != null && p.Usable == true).OrderBy(p => p.ScreenId))
            {
                isSelected = false;
                isDefault = false;

                if (lUser.Where(p => p.ScreenId == l.ScreenId).Count() > 0)
                    isSelected = true;

                var lDefault = lUser.SingleOrDefault(p => p.ScreenId == l.ScreenId && p.Default == true);
                if (lDefault != null)
                    isDefault = true;

                this.Add(new JSScreen { UserId = UserId, IsDefault = isDefault, IsSelected = isSelected, ScreenAvailable = l });
            }
        }

        private void OnApplyCommandExecuted(object id)
        {
            var luserScreen = lDataContext.UserScreens.Where(p => p.UserId == this.UserId);
            lDataContext.UserScreens.DeleteAllOnSubmit(luserScreen);

            foreach (JSScreen l in this.Where(p => p.IsSelected == true))
            {
                DataSource.UserScreen lNewScreen = new DataSource.UserScreen();
                lNewScreen.UserId = this.UserId;
                lNewScreen.ScreenId = l.ScreenAvailable.ScreenId;
                lNewScreen.Default = l.IsDefault;              
                lDataContext.UserScreens.InsertOnSubmit(lNewScreen);
            }

            try
            {
                lDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    
    }
}
