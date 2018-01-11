using SunSeven.DataSource;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SunSeven.Models
{
    public class CommonFunction
    {
        private static string _companyName = "";
        private static Window _applicationWindow = null;
        private static DataSource.CompanyInfo lCompanyInfo = null;
        public static ObservableCollection<JSProduct> productSet;

        public DataSource.JSDataContext JSDataContext()
        {
            //System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            return new DataSource.JSDataContext(SunSeven.Properties.Settings.Default.JSConnectionString);
        }


        public static ObservableCollection<JSProduct> GetProductList()
        {

            if (productSet == null)
            {
                int? defaultUnitId = 0;
                SunSeven.DataSource.JSDataContext lDataContext = lDataContext = new CommonFunction().JSDataContext();

                productSet = new ObservableCollection<JSProduct>();

                foreach (SunSeven.DataSource.Product l in lDataContext.Products)
                {
                    ObservableCollection<HSProductUnit> productUnits = new ObservableCollection<HSProductUnit>();

                    //foreach (SunSeven.DataSource.ProductUnit ll in lDataContext.ProductUnits.Where(p => p.ProductId == l.Id).OrderBy(p => p.DisplayIndex))
                    //{
                    //    productUnits.Add(new HSProductUnit
                    //    {
                    //        ProductId = ll.ProductId,
                    //        UnitId = ll.SellingUnitId,
                    //        DisplayIndex = ll.DisplayIndex,
                    //        UnitName = ll.SellingUnit.Unit
                    //    });

                    //}

                    foreach (SunSeven.DataSource.ProductUnit ll in lDataContext.ProductUnits.Where(p => p.ProductId == l.Id))
                    {
                        productUnits.Add(new HSProductUnit
                        {
                            ProductId = ll.ProductId,
                            UnitId = ll.SellingUnitId,
                            DisplayIndex = ll.DisplayIndex,
                            UnitName = ll.SellingUnit.Unit
                        });

                    }

                    if (productUnits.Count <= 0)
                        defaultUnitId = null;
                    else
                        defaultUnitId = productUnits.OrderBy(p => p.UnitId).First().UnitId;
                    //HSProductUnit lSelectedUnit = productUnits.FirstOrDefault(p => p.DisplayIndex == productUnits.Min(p2 => p2.DisplayIndex));

                    productSet.Add(new JSProduct
                    {
                        Id = l.Id,
                        Category = l.Category.Category1.Name,
                        subCategory = l.Category.Name,
                        barCode = l.BarCode,
                        ProductName = l.Name,
                        VAT = l.VatRate,
                        Description = l.Description,
                        productUnits = productUnits,
                        itemDescription = "",
                        SelectedUnitId = defaultUnitId
                        // SelectedUnit = lSelectedUnit

                    });

                }

            }

            return productSet;
        }
        public static Window GetApplicationWindow()
        {
            if (_applicationWindow == null)
            {
                _applicationWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(p => p.Title.Contains(Models.CommonFunction.GetCompanyInfo().CompanyName));

                //_applicationWindow = Window.GetWindow(lChild) as MainWindow;
            }

            return _applicationWindow;
        }

        public static string GetCompanyName()
        {

            try
            {
                if (_companyName == String.Empty)
                {
                    JSDataContext lDataContext = new CommonFunction().JSDataContext();
                    _companyName = lDataContext.CompanyInfos.Single(p => p.Id == 1).CompanyName;
                }

                return _companyName;
            }
            catch
            {
                return "Company Name not found.";
            }

        }

        public static DataSource.CompanyInfo GetCompanyInfo()
        {

            try
            {
                if (lCompanyInfo == null)
                {
                    lCompanyInfo = new DataSource.CompanyInfo();

                    JSDataContext lDataContext = new CommonFunction().JSDataContext();
                    lCompanyInfo = lDataContext.CompanyInfos.Single(p => p.Id == 1);
                }


                return lCompanyInfo;
            }
            catch
            {
                return null;
            }

        }


        public static int DeleteOrder(int? orderId)
        {
            if (orderId == null || orderId < 0) return -2;

            JSDataContext lDataContext = new CommonFunction().JSDataContext();


            try
            {
                var lItem = lDataContext.OrderItems.Where(p => p.OrderId == orderId);

                lDataContext.OrderItems.DeleteAllOnSubmit(lItem);


                var lOrder = lDataContext.Orders.SingleOrDefault(p => p.Id == orderId);
                lDataContext.Orders.DeleteOnSubmit(lOrder);

                lDataContext.Invoices.DeleteOnSubmit(lDataContext.Invoices.SingleOrDefault(p => p.Id == lOrder.InvoiceId));

                lDataContext.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return -1;
            }

            return 0;

        }

        public static int DeleteSales(int? salesId)
        {
            if (salesId == null) return -2;

            JSDataContext lDataContext = new CommonFunction().JSDataContext();


            try
            {
                var lItem = lDataContext.SalesItems.Where(p => p.SalesId == salesId);

                lDataContext.SalesItems.DeleteAllOnSubmit(lItem);


                var lOrder = lDataContext.Sales.SingleOrDefault(p => p.Id == salesId);
                lDataContext.Sales.DeleteOnSubmit(lOrder);

                lDataContext.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return -1;
            }

            return 0;

        }


        //public static void AddPriceHistory(HSOrderItem lOrderItems)
        //{
        //    JSDataContext lDataContext = new CommonFunction().JSDataContext();

        //    DataSource.PriceHistory lPriceHist = new PriceHistory();


        //    var lOrderHist = lDataContext.PriceHistories.SingleOrDefault(p => p.OrderId == lOrderItems.OrderId
        //            && p.ProductId == lOrderItems.ProductId && p.SellingUnitId == lOrderItems.SellingUnitId);

        //    lPriceHist.OrderId = lOrderItems.OrderId;
        //    lPriceHist.CustomerId = lOrderItems.CustomerId;
        //    lPriceHist.VatRate = lOrderItems.SelectedVat.Rate;
        //    lPriceHist.ProductId = lOrderItems.ProductId;
        //    lPriceHist.SellingUnitId = lOrderItems.SellingUnitId;
        //    lPriceHist.UnitPrice = lOrderItems.UnitPrice;

        //    if (lOrderHist == null)
        //    {
        //        lDataContext.PriceHistories.InsertOnSubmit(lPriceHist);
        //    }

        //    lDataContext.SubmitChanges();


        //}


        public static HSOrder PrintOrder(int? orderId)
        {
            if (orderId == null)
            {
                MessageBox.Show("Not Found Selected Order");
                return null;
            }

            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            HSOrder lEditOrder = new HSOrder();
            HSInvoice lInvoice = new HSInvoice();

            DataSource.Order lOrder = lDataContext.Orders.SingleOrDefault(p => p.Id == orderId);

            DataSource.vEmpDept lEmpDelivery = new DataSource.vEmpDept();


            //lEmpDelivery.Person = lOrder.Employee1.Person.LastName + "," + lOrder.Employee1.Person.FirstName;

            if (lOrder.Invoice.Employee != null)
                lEmpDelivery.Person = lOrder.Invoice.Employee.Person.LastName + "," + lOrder.Invoice.Employee.Person.FirstName;

            if (lOrder != null)
            {

                lEditOrder.Id = lOrder.Id;
                lEditOrder.CustomerId = lOrder.CustomerId;
                lEditOrder.SelectedCustomer = lOrder.Customer;
                lEditOrder.SelectedDeliverer = lEmpDelivery;
                lEditOrder.OrderDate = lOrder.OrderDate;
                lEditOrder.SellerId = lOrder.EmployeeId;


                if (lOrder.Invoice != null)
                {
                    lInvoice.Id = lOrder.Invoice.Id;
                    lInvoice.InvoiceNo = lOrder.Invoice.InvoiceNo;
                    lInvoice.InvoiceDate = lOrder.Invoice.InvoiceDate;
                    lInvoice.DeliveryDate = lOrder.Invoice.DeliveryDate;
                    lEditOrder.DelivererId = lOrder.Invoice.EmpDeliveryId;
                    lInvoice.Description = lOrder.Invoice.Description;
                    lEditOrder.Invoice = lInvoice;
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
                        VAT = l.VatRate.Name,
                        SelectedVat = l.VatRate,
                        Quantity = l.Quantity,
                        SellingUnitId = l.SellingUnitId,
                        Unit = l.SellingUnit.Unit,
                        SelectedSellingUnit = l.SellingUnit,
                        ProductName = l.Product.Name,
                        ProductDescription = l.Product.Description,
                        Description = l.Description
                    });
                }

            }

            return lEditOrder;
        }

        public static HSQuotation PrintSales(int salesId)
        {
            JSDataContext lDataContext = new CommonFunction().JSDataContext();

            HSQuotation lEditSales = new HSQuotation();

            DataSource.Sale lSales = lDataContext.Sales.SingleOrDefault(p => p.Id == salesId);

            if (lSales != null)
            {

                lEditSales.Id = lSales.Id;
                lEditSales.CustomerId = lSales.CustomerId.Value;
                lEditSales.SelectedCustomer = lSales.Customer;
                lEditSales.SalesDate = lSales.SalesDate;
                lEditSales.SellerId = lSales.SellerId;
                lEditSales.Description = lSales.Description;
                lEditSales.Order = lEditSales.Order;
                //lEditSales.Order = lSales;
                //lEditSales.SalesPerson = new HSEmployee { Id = lSales.Id, SelectedPerson = lSales.Employee.Person };

                lEditSales.DeleteEnabled = true;


                foreach (DataSource.SalesItem l in lSales.SalesItems)
                {
                    lEditSales.SalesItems.Add(new HSOrderItem
                    {
                        Id = l.Id,
                        CustomerId = lSales.CustomerId.Value,
                        OrderId = l.SalesId.Value,
                        ProductId = l.ProductId.Value,
                        SelectedProduct = l.Product,
                        UnitPrice = l.UnitPrice,
                        VatId = l.VatId,
                        VAT = l.VatRate.Name,
                        SelectedVat = l.VatRate,
                        Quantity = l.Quantity,
                        SellingUnitId = l.SellingUnitId,
                        Unit = l.SellingUnit.Unit,
                        SelectedSellingUnit = l.SellingUnit,
                        ProductName = l.Product.Name,
                        ProductDescription = l.Product.Description,
                        Description = l.Description
                    });
                }

            }
            return lEditSales;
        }
    }
}
