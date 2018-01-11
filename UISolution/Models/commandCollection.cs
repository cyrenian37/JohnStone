using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.DataForm;

namespace SunSeven.Models
{
    public class commandCollection
    {
        SunSeven.DataSource.JSDataContext lDataContext;
        public ICommand deleteCommand { get; set; }
        public ICommand deletingCommand { get; set; }
        public ICommand homeCommand { get; set; }
        public commandCollection()
        {
            lDataContext = new CommonFunction().JSDataContext();
            this.deleteCommand = new DelegateCommand(OnDeleteCommandExecuted);
            this.deletingCommand = new DelegateCommand(OnDeletingCommandExecuted);
            //this.homeCommand = new DelegateCommand(OnHomeCommandExecuted);

        }


        //private void OnHomeCommandExecuted(object id)
        //{
        //    ((UISolution.MainWindow)System.Windows.Application.Current.MainWindow).contentControl.Content = new SunSeven.Views.HomeMenu(Convert.ToInt16(id));

        //}

        private void OnDeletingCommandExecuted(object selectedItem)
        {
            System.ComponentModel.CancelEventArgs lItem = selectedItem as System.ComponentModel.CancelEventArgs;

            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (MessageBox.Show(lWindows, "Global Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                lItem.Cancel = true;
            }

        }
        private void OnDeleteCommandExecuted(object selectedItem)
        {

            switch (selectedItem.GetType().Name)
            {
                case "HSPerson":

                    //DataSource.Person lDeletItem = lDataContext.Persons.SingleOrDefault(p => p.Id == (selectedItem as HSPerson).Id);

                    //if (lDeletItem != null)
                    //{
                    //    lDataContext.Persons.DeleteOnSubmit(lDeletItem);

                    //    try
                    //    {
                    //        lDataContext.SubmitChanges();
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex);
                    //        // Provide for exceptions.
                    //    }
                    //}
                    break;
                case "HSEmployee":
                    break;

                case "HSCustomer":
                    break;
            }
            ItemDeletedEventArgs lItem = selectedItem as Telerik.Windows.Controls.Data.DataForm.ItemDeletedEventArgs;



        }
    }
}
