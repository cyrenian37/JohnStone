using SoftArcs.WPFSmartLibrary.MVVMCommands;
using SoftArcs.WPFSmartLibrary.MVVMCore;
using SoftArcs.WPFSmartLibrary.SmartUserControls;
using SunSeven.DataSource;
using SunSeven.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SunSeven.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields

        List<User> userList;

        private readonly string userImagesPath = @"\Images\Users";

        JSDataContext lContext;
        #endregion // Fields

        #region Constructors

        public LoginViewModel()
        {
            if (ViewModelHelper.IsInDesignModeStatic == false)
            {
                this.initializeAllCommands();

                lContext = new CommonFunction().JSDataContext();

                //+ This is only neccessary if you want to display the appropriate image while typing the user name.
                //+ If you want a higher security level you wouldn't do this here !
                //! Remember : ONLY for demonstration purposes I have used a local Collection
                this.getAllUser();
            }
        }

        #endregion // Constructors

        #region Public Properties

        public string UserName
        {
            get { return GetValue(() => UserName); }
            set
            {
                SetValue(() => UserName, value);

                this.UserImageSource = this.getUserImagePath();
            }
        }

        public User SelectedUser
        {
            get;
            set;
        }
        public string Password
        {
            get { return GetValue(() => Password); }
            set { SetValue(() => Password, value); }
        }

        public string UserImageSource
        {
            get { return GetValue(() => UserImageSource); }
            set { SetValue(() => UserImageSource, value); }
        }

        #endregion // Public Properties

        #region Submit Command Handler

        public ICommand SubmitCommand { get; private set; }

        private void ExecuteSubmit(object commandParameter)
        {
            var accessControlSystem = commandParameter as SmartLoginOverlay;

            if (accessControlSystem != null)
            {
                if (this.validateUser(this.UserName, this.Password) == true)
                {
                    accessControlSystem.Unlock();

                    ((SunSeven.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new SunSeven.Views.MainPage(this.SelectedUser);
                }
                else
                {
                    accessControlSystem.ShowWrongCredentialsMessage();
                }
            }
        }

        private bool CanExecuteSubmit(object commandParameter)
        {
            return !string.IsNullOrEmpty(this.Password);
        }

        #endregion // Submit Command Handler

        #region Private Methods

        private void initializeAllCommands()
        {
            this.SubmitCommand = new ActionCommand(this.ExecuteSubmit, this.CanExecuteSubmit);
        }

        private void getAllUser()
        {
            //+ Here you would implement code, which will get all user from a database,
            //+ a webservice or from somewhere else (if you want to display the right image)
            //! Remember : ONLY for demonstration purposes I have used a local Collection

            this.userList = new List<User>();

            try
            {

                foreach (DataSource.Security l in lContext.Securities)
                {
                    this.userList.Add(new User
                    {
                        Id = l.Id,
                        UserName = l.UserName,
                        Password = l.Password,
                        UserRole = l.Role,
                        UserImage = l.Image,
                        Employee = l.Employee,
                        ImageSourcePath = Path.Combine(userImagesPath, "UserIn2.PNG"),
                        AccessLevel = l.AccessLevel 
                    });


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //this.userList = new List<User>()
            //                     {
            //                         new User() { UserName="Admin", Password="passme",
            //                                         ImageSourcePath = Path.Combine( userImagesPath, "user_icon.png") },
            //                        new User() { UserName="sunchil", Password="passme",
            //                                         ImageSourcePath = Path.Combine( userImagesPath, "SunChil.jpg") },
            //                        new User() { UserName="eunlyong", Password="passme",
            //                                         ImageSourcePath = Path.Combine( userImagesPath, "EunLyong.jpg") },
            //                     };
        }

        private bool validateUser(string username, string password)
        {
            //+ Here you would implement code, which will get the validation for the given credentials
            //+ from a database, a webservice or from somewhere else
            //! Remember : ONLY for demonstration purposes I have used a local Collection

            User validatedUser = null;
            try
            {
                validatedUser = this.userList.FirstOrDefault(user => user.UserName.Equals(username) && user.Password.Equals(password));

                this.SelectedUser = validatedUser;
                //   return validatedUser != null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return validatedUser != null;

        }

        private string getUserImagePath()
        {
            User currentUser = this.userList.FirstOrDefault(user => user.UserName.Equals(this.UserName));

            if (currentUser != null)
            {
                return currentUser.ImageSourcePath;
            }

            return String.Empty;
        }

        #endregion
    }
}
