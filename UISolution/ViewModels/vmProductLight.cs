using SunSeven.Models;
using System.Collections.ObjectModel;
using System.Linq;


namespace SunSeven.ViewModels
{

    public class vmProductLight
    {

        SunSeven.DataSource.JSDataContext lDataContext;
        ObservableCollection<JSProduct> _productCollection;

        public vmProductLight()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }
        public ObservableCollection<JSProduct> Products
        {
            get
            {
            //    if (_productCollection == null)
            //    {
            //        _productCollection = new ObservableCollection<JSProduct>();

            //        foreach (SunSeven.DataSource.Product l in lDataContext.Products)
            //        {
            //            ObservableCollection<HSProductUnit> productUnits = new ObservableCollection<HSProductUnit>();

            //            foreach (SunSeven.DataSource.ProductUnit ll in lDataContext.ProductUnits.Where(p => p.ProductId == l.Id).OrderBy(p => p.DisplayIndex))
            //            {
            //                productUnits.Add(new HSProductUnit
            //                {
            //                    ProductId = ll.ProductId,
            //                    UnitId = ll.SellingUnitId,
            //                    DisplayIndex = ll.DisplayIndex
            //                });

            //            }

            //            _productCollection.Add(new JSProduct
            //            {
            //                Id = l.Id,
            //                Category = l.Category.Category1.Name,
            //                subCategory = l.Category.Name,
            //                barCode = l.BarCode,
            //                productnName = l.Name,
            //                VAT = l.VatRate,
            //                Description = l.Description,
            //                productUnits = productUnits,
            //                itemDescription = ""

            //            });
            //        }
            //    }

            //    return _productCollection;

             return SunSeven.Models.CommonFunction.GetProductList();

            }
        }
    }
}
