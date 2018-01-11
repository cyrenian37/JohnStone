using Telerik.Windows.Controls;

namespace SunSeven.ViewModels
{
    public class PopularControl : ViewModelBase
    {
        private string displayName;
        private string displayImage;
        private int displayPage;

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                if (value != this.displayName)
                {
                    this.displayName = value;
                    this.OnPropertyChanged(() => this.DisplayName);
                }
            }
        }

        public string DisplayImage
        {
            get
            {
                return this.displayImage;
            }
            set
            {
                if (value != this.displayImage)
                {
                    this.displayImage = value;
                    this.OnPropertyChanged(() => this.displayImage);
                }
            }
        }

        public int DisplayPage
        {
            get
            {
                return this.displayPage;
            }
            set
            {
                if (value != this.displayPage)
                {
                    this.displayPage = value;
                    this.OnPropertyChanged(() => this.displayPage);
                }
            }
        }
    }
}
