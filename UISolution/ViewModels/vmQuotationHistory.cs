using SunSeven.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SunSeven.ViewModels
{

    public class vmQuotationHistory : ViewModelBase
    {

        private ObservableCollection<HSQuotationHistory> _quotationHistories = null;

        private DateTime? _startDT;
        private DateTime? _endDT;
        private int? _type;
        private Boolean _isBusy;


        SunSeven.DataSource.JSDataContext lDataContext;
        public ICommand searchCommand { get; set; }

        public vmQuotationHistory()
        {
            lDataContext = new CommonFunction().JSDataContext();
            this.searchCommand = new DelegateCommand(OnSearchCommandExecuted);
            this.StartDT = DateTime.Today.AddDays(-1);
            this.EndDT = DateTime.Today.AddDays(1).AddSeconds(-1);

            this.Type = 0;
        }

        public vmQuotationHistory(int? Type)
        {
            lDataContext = new CommonFunction().JSDataContext();

            this.searchCommand = new DelegateCommand(OnSearchCommandExecuted);

            this.StartDT = DateTime.Today.AddDays(-1);
            this.EndDT = DateTime.Today.AddDays(1).AddSeconds(-1);
            this.Type = Type;

            this.IsBusy = true;
            LoadingAsyncStart();

        }

        public ObservableCollection<HSQuotationHistory> QuotationHistories
        {
            get
            {
                return _quotationHistories;
            }
            set
            {
                _quotationHistories = value;
                OnPropertyChanged(() => QuotationHistories);
            }
        }


        public DateTime? StartDT
        {
            get
            {
                return _startDT;
            }
            set
            {
                _startDT = value;
                OnPropertyChanged(() => StartDT);
            }
        }

        public DateTime? EndDT
        {
            get
            {
                return _endDT;
            }
            set
            {
                _endDT = value;
                OnPropertyChanged(() => EndDT);
            }
        }

        public int? Type { get; set; }

        private void OnSearchCommandExecuted(object id)
        {

            this.IsBusy = true;
            this.Type = null;

            LoadingAsyncStart();

        }

        private async void LoadingAsyncStart()
        {
            var lReturn = await LoadingAsync();

            this.IsBusy = lReturn;

        }

        private Task<Boolean> LoadingAsync()
        {
            return Task.Factory.StartNew(() => LoadingEnded());
        }

        private Boolean LoadingEnded()
        {
            ObservableCollection<HSQuotationHistory> quotationHistorySet = new ObservableCollection<HSQuotationHistory>();

            var lquotationHistory = lDataContext.quotationHistory(this.StartDT, this.EndDT, this.Type);



            foreach (DataSource.quotationHistoryResult l in lquotationHistory)
            {
                quotationHistorySet.Add(new HSQuotationHistory
                {
                    SalesId = l.Id,
                    Master = l.Master.Value,
                    SalesDate = l.SalesDate,
                    Description = l.Description,
                    CustomerDetail = l.Customer,
                    SalesPerson = l.SalesPerson,
                    TotalPrice = l.inclVAT,
                    TotalVAT = l.totalVAT

                });
            }

            QuotationHistories = quotationHistorySet;


            return false;
        }

        public Boolean IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }



    }
}
