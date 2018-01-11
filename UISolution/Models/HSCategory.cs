using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.DataSource;


namespace SunSeven.Models
{
    public class HSCategory : ViewModelBase, IEditableObject
    {

        private int _id;
        private int? _parentId;
        private string _parentName;
        private string _categoryName;
        private ObservableCollection<HSCategory> _subCategory;

        SunSeven.DataSource.JSDataContext lDataContext;

        public HSCategory()
        {
            lDataContext = new CommonFunction().JSDataContext();
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

        public int? ParentId
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value;
                this.OnPropertyChanged(() => this.ParentId);

            }
        }


        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                this.OnPropertyChanged(() => this.CategoryName);

            }
        }


        public ObservableCollection<HSCategory> Subcategory
        {
            get
            {
                if (this._subCategory == null)
                {
                    _subCategory = new ObservableCollection<HSCategory>();

                    try
                    {
                        var lsub = lDataContext.Categories.Where(p => p.ParentId == this.Id);

                        foreach (SunSeven.DataSource.Category l in lsub)
                        {

                            _subCategory.Add(new HSCategory
                            {
                                Id = l.Id,
                                ParentId = l.ParentId,
                                CategoryName = l.Name
                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }

                }
                return _subCategory;
            }
            set
            {
                _subCategory = value;
                this.OnPropertyChanged(() => this.Subcategory);

            }
        }

        public void BeginEdit()
        {
            //throw new System.NotImplementedException();
        }

        public void CancelEdit()
        {
            //throw new System.NotImplementedException();
        }

        public void EndEdit()
        {

            DataSource.Category lUpdateItem = lDataContext.Categories.SingleOrDefault(p => p.Id == this.Id);

            if (lUpdateItem == null)
            {

                DataSource.Category lNewItem = new DataSource.Category
                {
                    Name = this.CategoryName,
                    ParentId = this.ParentId
                };

                // Add the new object to the Orders collection.
                lDataContext.Categories.InsertOnSubmit(lNewItem);

                // Submit the change to the database.
                try
                {
                    lDataContext.SubmitChanges();

                    this.Id = lNewItem.Id;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            else
            {
                lUpdateItem.Name = this.CategoryName;

                lDataContext.SubmitChanges();
            }
        }
    }
}
