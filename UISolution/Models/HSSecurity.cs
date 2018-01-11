using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{

    public class HSSecurity : ViewModelBase
    {
        private int _id;
        private string _userName;
        private string _passWord;
        private int? _empId;
        private int _roleId;
        private string _defaultPage;
        private int? _pageId;
        

        SunSeven.DataSource.JSDataContext lDataContext;
        public ICommand screenCommand { get; set; }

        public HSSecurity()
        {
            lDataContext = new CommonFunction().JSDataContext();
            this.screenCommand = new DelegateCommand(OnScreenCommandExecuted);
            //this.screenCommand.CanExecuteChanged += ScreenCommand_CanExecuteChanged;
        }

     

        private void OnScreenCommandExecuted(object btn)
        {

            Window lWindows = Models.CommonFunction.GetApplicationWindow();
            RadWindow screenWin = new Views.ScreenSelection(this.Id);

            screenWin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            //var location = lWindows.PointToScreen(new Point(0, 0));
            //screenWin.Left = location.X;
            //screenWin.Top = location.Y - screenWin.Height;

            if (lWindows != null)
                screenWin.Owner = lWindows;

            screenWin.ShowDialog();
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }

        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(() => UserName);
            }

        }

        public string Password
        {
            get
            {
                return _passWord;
            }
            set
            {
                _passWord = value;
                OnPropertyChanged(() => Password);
            }

        }

        public int? EmployeeId
        {
            get
            {
                return _empId;
            }
            set
            {
                _empId = value;
                this.OnPropertyChanged(() => this.EmployeeId);
               
            }

        }

        public int RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                _roleId = value;
                this.OnPropertyChanged(() => this.RoleId);

            }

        }

        public int? PageId
        {
            get
            {
                return _pageId;
            }
            set
            {
                _pageId = value;
            }
        }

        public string DefaultPage
        {
            get
            {
                return _defaultPage;
            }
            set
            {
                _defaultPage = value;
            }
        }

        public int? AccessLevel
        {
            get;
            set;
        }

       
    }

}
