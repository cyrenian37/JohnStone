using SunSeven.DataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{

    public class HSProductUnit : ViewModelBase
    {

        private int _productId;
        private int _unitId;
        private int? _displayIndex;
        private string _unitName;

        public int ProductId
        {
            get
            {

                return _productId;
            }
            set
            {
                _productId = value;

                this.OnPropertyChanged(() => this.ProductId);
                this.OnPropertyChanged(() => this.UnitName);
            }
        }

        public int UnitId
        {
            get
            {

                return _unitId;
            }
            set
            {
                _unitId = value;

                this.OnPropertyChanged(() => this.UnitId);
            }
        }

        public int? DisplayIndex
        {
            get
            {

                return _displayIndex;
            }
            set
            {
                _displayIndex = value;

                this.OnPropertyChanged(() => this.DisplayIndex);
            }
        }

        public string UnitName
        {
            get
            {
                return _unitName;               
            }
            set
            {
                _unitName = value;
                this.OnPropertyChanged(() => this.UnitName);
            }
        }
    }






    public class HSProduct : ViewModelBase, IEditableObject
    {
        private int? _categoryId;
        private int _subcategoryId;
        private int? _supplierId;
        private int? _vatId;
        private string _barCode;
        private string _description;
        private int? _sellingUnitId;
        private string _name;



        private DataSource.Supplier _supplier;
        private DataSource.VatRate _selectedVat;


        private DataSource.Category _selectedCategory;
        private DataSource.Category _selectedSubCategory;

        private IQueryable<DataSource.Category> _subCategories;

        private ObservableCollection<HSProductUnit> _productUnits;

        backupPeopleData backupData;

        private JSDataContext lDataContext;


        public HSProduct()
        {
            lDataContext = new CommonFunction().JSDataContext();
            _productUnits = new ObservableCollection<HSProductUnit>();
        }


        public int? CategoryId
        {
            get
            {

                return _categoryId;
            }
            set
            {
                _categoryId = value;

                this.OnPropertyChanged(() => this.CategoryId);
            }
        }

        public DataSource.Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;

                try
                {
                    SubCategories = lDataContext.Categories.Where(p => p.ParentId == SelectedCategory.Id);

                    this.OnPropertyChanged(() => this.SelectedCategory);
                    this.OnPropertyChanged(() => this.SubCategories);
                }
                catch
                { }

            }
        }

        public int SubCategoryId
        {
            get
            {

                return _subcategoryId;
            }
            set
            {
                _subcategoryId = value;

                this.OnPropertyChanged(() => this.SubCategoryId);
            }
        }

        public DataSource.Category SelectedSubCategory
        {
            get
            {
                return _selectedSubCategory;
            }
            set
            {
                _selectedSubCategory = value;
                this.OnPropertyChanged(() => this.SelectedSubCategory);

            }
        }


        public IQueryable<DataSource.Category> SubCategories
        {
            get
            {
                return _subCategories;
            }
            set
            {
                _subCategories = value;

                this.OnPropertyChanged(() => this.SubCategories);
            }

        }


        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Product Name is required")]
        public string Name
        {
            get
            {

                return _name;
            }
            set
            {
                _name = value;

                this.OnPropertyChanged(() => this.Name);
            }

        }


        public int? VatId
        {
            get
            {

                return _vatId;
            }
            set
            {
                _vatId = value;

                this.OnPropertyChanged(() => this.VatId);
                this.OnPropertyChanged(() => this.SelectedVat);
            }

        }

        public DataSource.VatRate SelectedVat
        {
            get
            {
                if (this.VatId != null)
                    _selectedVat = lDataContext.VatRates.Single(p => p.Id == this.VatId);
                return _selectedVat;
            }
            //set
            //{
            //    _selectedVat = value;

            //    this.OnPropertyChanged(() => this.SelectedVat);
            //}
        }
        public int? SupplierId
        {
            get
            {
                return _supplierId;
            }
            set
            {
                _supplierId = value;
                this.OnPropertyChanged(() => this.SupplierId);
            }
        }




        public DataSource.Supplier Supplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                _supplier = value;
                this.OnPropertyChanged(() => this.Supplier);
            }
        }



        public string BarCode
        {
            get
            {
                return _barCode;
            }
            set
            {
                _barCode = value;
                this.OnPropertyChanged(() => this.BarCode);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                this.OnPropertyChanged(() => this.Description);
            }
        }

        public int? SellingUnitId
        {
            get
            {
                return _sellingUnitId;
            }
            set
            {
                _sellingUnitId = value;
                this.OnPropertyChanged(() => this.SellingUnitId);
            }
        }


        public ObservableCollection<HSProductUnit> ProductUnits
        {
            get
            {
                return _productUnits;
            }
            set
            {
                _productUnits = value;

            }
        }

        public struct backupPeopleData
        {
            internal int subCategoryId;
            internal int? supplierId;
            internal int? vatId;
            internal string barCode;
            internal string description;
            internal string name;
            
        }



        public void BeginEdit()
        {
            this.backupData.subCategoryId = this.SubCategoryId;
            this.backupData.supplierId = this.SupplierId;
            this.backupData.barCode = this.BarCode;
            this.backupData.description = this.Description;
            this.backupData.vatId = this.VatId;
            this.backupData.name = this.Name;
           
        }

        public void CancelEdit()
        {
            this.SubCategoryId = this.backupData.subCategoryId;
            this.SupplierId = this.backupData.supplierId;
            this.BarCode = this.backupData.barCode;
            this.Description = this.backupData.description;
            this.VatId = this.backupData.vatId;
            this.Name = this.backupData.name;
           
            this._productUnits = new ObservableCollection<HSProductUnit>();

            foreach (SunSeven.DataSource.ProductUnit l in lDataContext.ProductUnits.Where(p => p.ProductId == this.Id))
            {
                this._productUnits.Add(new HSProductUnit
                {

                    ProductId = l.ProductId,
                    UnitId = l.SellingUnitId,
                    UnitName = l.SellingUnit.Unit 
                });

            }
        }

        public void EndEdit()
        {
            DataSource.Product lUpdate = lDataContext.Products.SingleOrDefault(p => p.Id == this.Id);


            if (lUpdate == null)
            {
                DataSource.Product newItem = new DataSource.Product
                {
                    //Id = this.Id,
                    CategoryId = this.SubCategoryId,
                    BarCode = this.BarCode,
                    Description = this.Description,
                    SupplierId = this.SupplierId,
                    VatRateId = this.VatId,
                    Name = this.Name

                };
                // Add the new object to the Orders collection.
                lDataContext.Products.InsertOnSubmit(newItem);

                // Submit the change to the database.
                try
                {
                    lDataContext.SubmitChanges();

                    this.Id = newItem.Id;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

            }
            else
            {
                lUpdate.CategoryId = this.SubCategoryId;
                lUpdate.BarCode = this.BarCode;
                lUpdate.Description = this.Description;
                lUpdate.SupplierId = this.SupplierId;
                lUpdate.VatRateId = this.VatId;
                lUpdate.Name = this.Name;
                

                try
                {
                    lDataContext.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }

            // Remove all units belonging to this product
            var lProdUnits = from p in lDataContext.ProductUnits where p.ProductId == this.Id select p;

            lDataContext.ProductUnits.DeleteAllOnSubmit(lProdUnits);

            try
            {
                lDataContext.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            int displayIndex = 0;

            foreach (HSProductUnit l in this.ProductUnits)
            {
                DataSource.ProductUnit lnewProdUnit = new DataSource.ProductUnit
                {
                    ProductId = this.Id,
                    SellingUnitId = l.UnitId,                    
                    DisplayIndex = displayIndex++
                };

                lDataContext.ProductUnits.InsertOnSubmit(lnewProdUnit);

                l.UnitName = lDataContext.SellingUnits.Single(p => p.Id == l.UnitId).Unit;
            }

            try
            {
                lDataContext.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            

            //this.OnPropertyChanged(() => this.ProductUnits);
            //if (this.SupplierId != null)
            //    this.Supplier = lDataContext.Suppliers.Single<DataSource.Supplier>(p => p.Id == this.SupplierId);
            //this.OnPropertyChanged(() => this.Supplier);


            // update Product list in ProductWin.xaml
            //Thinking...... 
            //Models.CommonFunction.productSet = null;
            //Models.CommonFunction.GetProductList();
        }
    }


}
