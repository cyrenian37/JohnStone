using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TransitionControl;


namespace SunSeven.Models
{
    public class NavigationItem : ViewModelBase
    {
        private string _DisplayName;
        public string DisplayName
        {
            get
            {
                return this._DisplayName;
            }
            set
            {

                if (value != this._DisplayName)
                {
                    this._DisplayName = value;
                    this.OnPropertyChanged(() => this.DisplayName);
                }
            }
        }

        private ImageSource _Image;
        public ImageSource Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if ((object)(this._Image) != (object)value)
                {
                    this._Image = value;
                    this.OnPropertyChanged("Image");
                }
            }
        }

        private string _ColorBrush;
        public string ColorBrush
        {
            get
            {
                return this._ColorBrush;
            }
            set
            {

                if (value != this._ColorBrush)
                {
                    this._ColorBrush = value;
                    this.OnPropertyChanged(() => this.ColorBrush);
                }
            }
        }

        private ImageSource _BigImage;
        public ImageSource BigImage
        {
            get
            {
                return this._BigImage;
            }
            set
            {
                if ((object)(this._BigImage) != (object)value)
                {
                    this._BigImage = value;
                    this.OnPropertyChanged("BigImage");
                }
            }
        }

        private TransitionProvider _Transition;
        public TransitionProvider Transition
        {
            get
            {
                return this._Transition;
            }
            set
            {
                if ((object)(this._Transition) != (object)value)
                {
                    this._Transition = value;
                    this.OnPropertyChanged("Transition");
                }
            }
        }
    }
}
