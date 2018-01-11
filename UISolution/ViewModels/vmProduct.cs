using SunSeven.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;


namespace SunSeven.ViewModels
{

    public class vmProduct : ViewModelBase
    {

        private ICollectionView hsCollection = null;

        SunSeven.DataSource.JSDataContext lDataContext;
        private ObservableCollection<DataSource.SellingUnit> _unitSet;
        private ObservableCollection<DataSource.VatRate> _vatSet;
        private ObservableCollection<DataSource.Category> _rootCategories;
        private ObservableCollection<DataSource.Category> _categories;

        public ObservableCollection<DataSource.SellingUnit> UnitSet
        {
            get
            {
                return _unitSet;
            }
            set
            {
                _unitSet = value;
                OnPropertyChanged(() => UnitSet);
            }
        }
        public ObservableCollection<DataSource.VatRate> VATSet
        {
            get
            {
                return _vatSet;
            }
            set
            {
                _vatSet = value;
                OnPropertyChanged(() => VATSet);
            }
        }

        public ObservableCollection<DataSource.Category> RootCategories
        {
            get
            {
                return _rootCategories;
            }
            set
            {
                _rootCategories = value;
                OnPropertyChanged(() => RootCategories);
            }
        }

        public ObservableCollection<DataSource.Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                OnPropertyChanged(() => Categories);
            }
        }

        public vmProduct()
        {
            lDataContext = new CommonFunction().JSDataContext();

            _unitSet = new ObservableCollection<DataSource.SellingUnit>();

            foreach (DataSource.SellingUnit l in lDataContext.SellingUnits)
            {
                _unitSet.Add(new DataSource.SellingUnit { Id = l.Id, Unit = l.Unit });
            }

            _vatSet = new ObservableCollection<DataSource.VatRate>();

            foreach (DataSource.VatRate l in lDataContext.VatRates)
            {
                _vatSet.Add(new DataSource.VatRate { Id = l.Id, Name = l.Name });
            }

            _rootCategories = new ObservableCollection<DataSource.Category>();

            foreach (DataSource.Category l in lDataContext.Categories.Where(p => p.ParentId == null))
            {
                _rootCategories.Add(new DataSource.Category { Id = l.Id, Name = l.Name, ParentId = l.ParentId });
            }

            _categories = new ObservableCollection<DataSource.Category>();

            foreach (DataSource.Category l in lDataContext.Categories.Where(p => p.ParentId != null))
            {
                _categories.Add(new DataSource.Category { Id = l.Id, Name = l.Name, ParentId = l.ParentId });
            }
        }

        //public IQueryable<DataSource.Category> RootCategories
        //{
        //    get
        //    {
        //        return lDataContext.Categories.Where(p => p.ParentId == null);
        //    }
        //}

        //public IQueryable<DataSource.Category> Categories
        //{
        //    get
        //    {
        //        return lDataContext.Categories.Where(p => p.ParentId != null);
        //    }
        //}

        public ICollectionView Products
        {
            get
            {
                if (this.hsCollection == null)
                {
                    ObservableCollection<HSProduct> lhsCollection = new ObservableCollection<HSProduct>();

                    foreach (SunSeven.DataSource.Product l in lDataContext.Products)
                    {
                        ObservableCollection<HSProductUnit> productUnits = new ObservableCollection<HSProductUnit>();

                        foreach (SunSeven.DataSource.ProductUnit ll in lDataContext.ProductUnits.Where(p => p.ProductId == l.Id).OrderBy(p => p.DisplayIndex))
                        {
                            productUnits.Add(new HSProductUnit
                            {

                                ProductId = ll.ProductId,
                                UnitId = ll.SellingUnitId,
                                DisplayIndex = ll.DisplayIndex,
                                UnitName = ll.SellingUnit.Unit 
                            });

                        }

                        lhsCollection.Add(new HSProduct
                        {
                            Id = l.Id,
                            CategoryId = l.Category.ParentId,
                            SubCategoryId = l.CategoryId,
                            SupplierId = l.SupplierId,
                            VatId = l.VatRateId,
                            BarCode = l.BarCode,
                            Description = l.Description,
                            Supplier = l.Supplier,
                            SelectedCategory = lDataContext.Categories.Single(p => p.Id == l.Category.ParentId),
                            SelectedSubCategory = l.Category,
                            SellingUnitId = 1,
                            Name = l.Name,
                            ProductUnits = productUnits                            
                            //SelectedVat = l.VatRate,

                        });
                    }

                    this.hsCollection = new QueryableCollectionView(lhsCollection);
                }

                // this.hsCollection = new QueryableCollectionView(CommonFunction.GetProductList());
                return this.hsCollection;
            }
        }
    }
}
