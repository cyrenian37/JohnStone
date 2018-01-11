using Microsoft.PointOfService;
using SunSeven.DataSource;
using SunSeven.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace SunSeven.Views
{
    /// <summary>
    /// Interaction logic for newOrder.xaml
    /// </summary>
    public partial class OrderEditor : UserControl
    {
        //private PosExplorer devExplorer;
        private Scanner activeScanner;

        //public delegate void closeWindowHander(int Action);

        //static public event closeWindowHander closeWindowCommand;


        public OrderEditor()
        {
            InitializeComponent();
            this.DataContext = new HSOrder();
           
            MainPage.CloseCommand -= MainPage_CloseCommand;
            MainPage.CloseCommand += MainPage_CloseCommand;

            this.comboStatus.IsEnabled = false;

            this.comboStatus.IsEnabled = true;
            this.comboCustomer.IsEnabled = true;

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.comboStatus.IsEnabled = false;
                this.comboCustomer.IsEnabled = false;
            }

            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            
            //comboDelivery.ItemsSource = new ViewModels.vmEmployee().DeliveryPerson.Where(p=>p.DateOut == null);
            //comboEmployee.ItemsSource = new ViewModels.vmEmployee().SalesPerson.Where(p => p.DateOut == null);

            ObservableCollection<DataSource.vEmpDept> DeliveryPerson = new ObservableCollection<vEmpDept>();
            ObservableCollection<DataSource.vEmpDept> SalesPerson = new ObservableCollection<vEmpDept>();

            foreach (var l in lDataContext.EmployeeAtWork(null, "Delivery"))
            {
                DeliveryPerson.Add(new vEmpDept { Id = l.Id, FirstName = l.FirstName, LastName = l.LastName, Person = l.Person, Department = l.Department });
            }

            foreach (var l in lDataContext.EmployeeAtWork(null, "Sales"))
            {
                SalesPerson.Add(new vEmpDept { Id = l.Id, FirstName = l.FirstName, LastName = l.LastName, Person = l.Person, Department = l.Department });
            }

            comboDelivery.ItemsSource = DeliveryPerson;
            comboEmployee.ItemsSource = SalesPerson;

        }

        public OrderEditor(int? OrderId)
        {

            InitializeComponent();


            MainPage.CloseCommand -= MainPage_CloseCommand;
            MainPage.CloseCommand += MainPage_CloseCommand;


            this.comboStatus.IsEnabled = true;
            this.comboCustomer.IsEnabled = true;

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                this.comboStatus.IsEnabled = false;
                this.comboCustomer.IsEnabled = false;
            }


            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            HSOrder lEditOrder = new HSOrder();
            HSInvoice lInvoice = new HSInvoice();

            //comboDelivery.ItemsSource = new ViewModels.vmEmployee().DeliveryPerson;

            DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.Id == OrderId);

            if (lOrder != null)
            {

                lEditOrder.Id = lOrder.Id;
                lEditOrder.CustomerId = lOrder.CustomerId;
                lEditOrder.SelectedCustomer = lOrder.Customer;
                lEditOrder.OrderDate = lOrder.OrderDate;
                lEditOrder.SellerId = lOrder.EmployeeId;

                lEditOrder.Description = lOrder.Description;


                if (lOrder.Invoice != null)
                {
                    lInvoice.Id = lOrder.Invoice.Id;
                    lInvoice.InvoiceNo = lOrder.Invoice.InvoiceNo;
                    lInvoice.InvoiceDate = lOrder.Invoice.InvoiceDate;
                    lInvoice.DeliveryDate = lOrder.Invoice.DeliveryDate;
                    lEditOrder.DelivererId = lOrder.Invoice.EmpDeliveryId;
                    lInvoice.Description = lOrder.Invoice.Description;
                    lEditOrder.Invoice = lInvoice;
                    lInvoice.InvoiceStatusId = lOrder.Invoice.Status;
                }

                lEditOrder.DeleteEnabled = true;
                if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
                {
                    lEditOrder.DeleteEnabled = false;
                }


                foreach (DataSource.OrderItem l in lOrder.OrderItems)
                {
                    lEditOrder.OrderItems.Add(new HSOrderItem
                    {
                        Id = l.Id,
                        CustomerId = lOrder.CustomerId,
                        OrderId = l.OrderId,
                        SalesStatusId = l.SalesStatusId,
                        ProductId = l.ProductId,
                        SelectedProduct = l.Product,
                        UnitPrice = l.UnitPrice,
                        VatId = l.VatId,
                        SelectedVat = l.VatRate,
                        Quantity = l.Quantity,
                        SellingUnitId = l.SellingUnitId,
                        SelectedSellingUnit = l.SellingUnit,
                        ProductName = l.Product.Name,
                        ProductDescription = l.Product.Description,
                        VAT = l.VatRate.Name,
                        Unit = l.SellingUnit.Unit,
                        Description = l.Description
                    });
                }

                this.DataContext = lEditOrder;


                ObservableCollection<DataSource.vEmpDept> DeliveryPerson = new ObservableCollection<vEmpDept>();
                ObservableCollection<DataSource.vEmpDept> SalesPerson = new ObservableCollection<vEmpDept>();

                foreach (var l in lDataContext.EmployeeAtWork(lOrder.Invoice.EmpDeliveryId, "Delivery"))
                {
                    DeliveryPerson.Add(new vEmpDept { Id = l.Id, FirstName = l.FirstName, LastName = l.LastName, Person = l.Person, Department = l.Department });
                }

                foreach (var l in lDataContext.EmployeeAtWork(lOrder.EmployeeId, "Sales"))
                {
                    SalesPerson.Add(new vEmpDept { Id = l.Id, FirstName = l.FirstName, LastName = l.LastName, Person = l.Person, Department = l.Department });
                }

                comboDelivery.ItemsSource = DeliveryPerson;
                comboEmployee.ItemsSource = SalesPerson;
            }
        }

        private MessageBoxResult MainPage_CloseCommand(string PageId)
        {
            MessageBoxResult lBoxResult = MessageBoxResult.None;

            if (MainPage.lCurrentUser.UserRole.Name == "Read Only")
            {
                return MessageBoxResult.None;
            }                

            HSOrder lEdit = DataContext as HSOrder;

            if (PageId.ToUpper().Contains("OPEN ORDER"))
            {
                if (lEdit.CustomerId > 0)
                {
                    lBoxResult = MessageBox.Show("Please Save changes..", "Confirm Order", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            else
            {
                if (lEdit.CustomerId > 0)
                {
                    lBoxResult = MessageBox.Show(" Yes : Save and Close\n No : Close without Save\n Cancel : Cancel Close", "Confirm Order"
                        , MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                }
            }

            if (lBoxResult == MessageBoxResult.Yes)
            {
                if (lEdit.CustomerId > 0)
                {
                    lEdit.SaveOrder();
                }

            }

            //MainPage.CloseCommand -= MainPage_CloseCommand;
           
            return lBoxResult;
        }

    
        private void gridOrderItem_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        {


            Window lWindows = Models.CommonFunction.GetApplicationWindow();

            if (lWindows == null)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete",
                       MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
            else
            {
                if (MessageBox.Show(lWindows, "Are you sure you want to delete?", "Delete",
                           MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }


        private void gridOrderItem_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            foreach (HSOrderItem l in e.Items)
            {
                if (l.Id < 0) continue;

                try
                {
                    DataSource.OrderItem lItem = lDataContext.OrderItems.SingleOrDefault<DataSource.OrderItem>(p => p.Id == l.Id);

                    lDataContext.OrderItems.DeleteOnSubmit(lItem);
                    lDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void gridOrderItem_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            if (e.EditAction == GridViewEditAction.Cancel) return;

            HSOrder lOrder = comboCustomer.SelectedItem as HSOrder;

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainPage.CloseCommand -= MainPage_CloseCommand;
          
        }



    }
}