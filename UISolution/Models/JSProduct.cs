using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace SunSeven.Models
{
    public class JSProduct : ViewModelBase
    {
        private HSProductUnit _selectedUnit;
        private int? _selectedUnitId;

        public JSProduct()
        {
            this.productUnits = new ObservableCollection<HSProductUnit>();
        }
        public int Id { get; set; }
        public string Category { get; set; }
        public string subCategory { get; set; }


        public string categoryName
        {
            get { return this.Category + "-" + this.subCategory; }

        }
        public string ProductName { get; set; }
        public string itemDescription { get; set; }

        public string barCode { get; set; }

        public DataSource.VatRate VAT { get; set; }
        public string Description { get; set; }

        //public HSProductUnit SelectedUnit
        //{
        //    get
        //    {
        //        return _selectedUnit;
        //    }
        //    set
        //    {
        //        _selectedUnit = value;
        //        OnPropertyChanged(() => SelectedUnit);
        //    }
        //}

        public int? SelectedUnitId
        {
            get
            {
                return _selectedUnitId;
            }
            set
            {
                _selectedUnitId = value;
                OnPropertyChanged(() => SelectedUnitId);
            }
        }
        public ObservableCollection<HSProductUnit> productUnits
        {
            get;
            set;
        }
    }
}
