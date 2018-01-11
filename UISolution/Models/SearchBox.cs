using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace UISolution.Models
{
    public interface IHighlightable
	{
		bool IsHighlighted { get; set; }
	}

     public class ResultBoxItem : ContentControl, IHighlightable
	{
		public bool IsHighlighted
		{
			get { return (bool)GetValue(IsHighlightedProperty); }
			set { SetValue(IsHighlightedProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsHighlighted.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsHighlightedProperty =
			DependencyProperty.Register("IsHighlighted", typeof(bool), typeof(ResultBoxItem), new PropertyMetadata(false, OnIsHighlightedChanged));

		private static void OnIsHighlightedChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			ResultBoxItem resultBoxItem = (ResultBoxItem)sender;
			ResultBox resultBox = resultBoxItem.ParentResultBox;
			resultBox.NotifyHighlightedChanged(resultBoxItem, args);
		}

		internal ResultBox ParentResultBox
		{
			get
			{
				return ItemsControl.ItemsControlFromItemContainer(this) as ResultBox;
			}
		}

		static ResultBoxItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ResultBoxItem), new FrameworkPropertyMetadata(typeof(ResultBoxItem)));
		}

		protected override void OnMouseEnter(MouseEventArgs e)
		{
			this.IsHighlighted = true;
		}

		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			this.IsHighlighted = true;
			this.ParentResultBox.NotifyResultSelected(this);
		}
	}
}

    public class ResultBox : ItemsControl
    {
        public int HighlightedIndex
        {
            get { return (int)GetValue(HighlightedIndexProperty); }
            set { SetValue(HighlightedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightedIndexProperty =
            DependencyProperty.Register("HighlightedIndex", typeof(int), typeof(ResultBox), new PropertyMetadata(-1, OnHighlightedIndexChanged, CoerceHighlightedIndex));

        private static object CoerceHighlightedIndex(DependencyObject d, object value)
        {
            ResultBox resultBox = (ResultBox)d;
            int index = (int)value;
            if (index < -1)
            {
                index = -1;
            }
            if (index >= resultBox.Items.Count)
            {
                index = resultBox.Items.Count - 1;
            }
            if (index >= 0)
            {
                resultBox.HighlightedItem = resultBox.Items[index];
            }
            else
            {
                resultBox.HighlightedItem = null;
            }
            return index;
        }

        private static void OnHighlightedIndexChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
        }

        internal void NotifyHighlightedChanged(ResultBoxItem item, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue && !this.ignoreHighlightNotification)
            {
                this.HighlightedItem = this.ItemContainerGenerator.ItemFromContainer(item);
            }
        }

        public object HighlightedItem
        {
            get { return (object)GetValue(HighlightedItemProperty); }
            set { SetValue(HighlightedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightedItemProperty =
            DependencyProperty.Register("HighlightedItem", typeof(object), typeof(ResultBox), new UIPropertyMetadata(null, OnHighlightedItemChanged, CoerceHighlihgtedItem));


        private static object CoerceHighlihgtedItem(DependencyObject d, object value)
        {
            ResultBox resultBox = (ResultBox)d;
            if (resultBox.Items.Contains(value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        private bool ignoreHighlightNotification;
        private static void OnHighlightedItemChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ResultBox resultBox = (ResultBox)sender;
            IHighlightable oldItem = resultBox.ItemContainerGenerator.ContainerFromItem(args.OldValue) as IHighlightable;
            if (oldItem != null)
            {
                oldItem.IsHighlighted = false;
            }
            IHighlightable newItem = resultBox.ItemContainerGenerator.ContainerFromItem(args.NewValue) as IHighlightable;
            if (newItem != null)
            {
                resultBox.ignoreHighlightNotification = true;
                newItem.IsHighlighted = true;
                resultBox.ignoreHighlightNotification = false;
            }
            resultBox.HighlightedIndex = resultBox.Items.IndexOf(args.NewValue);
        }

        static ResultBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResultBox), new FrameworkPropertyMetadata(typeof(ResultBox)));
        }

        public void ScrollIntoView(object item)
        {
            FrameworkElement o = this.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
            if (o != null)
            {
                o.BringIntoView();
            }
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ResultBoxItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ResultBoxItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            (element as IHighlightable).IsHighlighted = item == this.HighlightedItem;
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
        }

        public event SearchSelectionEventHandler SearchSelection;

        internal void NotifyResultSelected(ResultBoxItem resultBoxItem)
        {
            if (this.SearchSelection != null)
            {
                this.SearchSelection.Invoke(this, new SearchSelectionEventArgs(this.ItemContainerGenerator.ItemFromContainer(resultBoxItem)));
            }
        }
    }

    public class SearchBox : Control
    {
        public object ResultEmptyContent
        {
            get { return (object)GetValue(ResultEmptyContentProperty); }
            set { SetValue(ResultEmptyContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultEmptyContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultEmptyContentProperty =
            DependencyProperty.Register("ResultEmptyContent", typeof(object), typeof(SearchBox), null);

        public DataTemplate ResultEmptyContentTemplate
        {
            get { return (DataTemplate)GetValue(ResultEmptyContentTemplateProperty); }
            set { SetValue(ResultEmptyContentTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultEmptyContentTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultEmptyContentTemplateProperty =
            DependencyProperty.Register("ResultEmptyContentTemplate", typeof(DataTemplate), typeof(SearchBox), null);

        // TODO: Add attributes on stlye properties marking the target type
        public Style ResultListBoxStyle
        {
            get { return (Style)GetValue(ResultListBoxStyleProperty); }
            set { SetValue(ResultListBoxStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultListBoxStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultListBoxStyleProperty =
            DependencyProperty.Register("ResultListBoxStyle", typeof(Style), typeof(SearchBox), null);

        public Style ResultItemContainerStyle
        {
            get { return (Style)GetValue(ResultItemContainerStyleProperty); }
            set { SetValue(ResultItemContainerStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultItemContainerStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultItemContainerStyleProperty =
            DependencyProperty.Register("ResultItemContainerStyle", typeof(Style), typeof(SearchBox), null);

        public StyleSelector ResultItemContainerStyleSelector
        {
            get { return (StyleSelector)GetValue(ResultItemContainerStyleSelectorProperty); }
            set { SetValue(ResultItemContainerStyleSelectorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultItemContainerStyleSelector.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultItemContainerStyleSelectorProperty =
            DependencyProperty.Register("ResultItemContainerStyleSelector", typeof(StyleSelector), typeof(SearchBox), null);

        public DataTemplate ResultItemTemplate
        {
            get { return (DataTemplate)GetValue(ResultItemTemplateProperty); }
            set { SetValue(ResultItemTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultItemTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultItemTemplateProperty =
            DependencyProperty.Register("ResultItemTemplate", typeof(DataTemplate), typeof(SearchBox), null);

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(SearchBox), new UIPropertyMetadata(String.Empty, OnSearchTextChanged));

        private static void OnSearchTextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((SearchBox)sender).OnSearchTextChanged(args);
        }

        private void OnSearchTextChanged(DependencyPropertyChangedEventArgs args)
        {
            if (this.collectionViewSource != null && this.collectionViewSource.View != null)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (this.collectionViewSource != null)
                    {
                        this.collectionViewSource.View.Refresh();
                        if (this.searchList != null)
                        {
                            this.searchList.HighlightedIndex = 0;
                        }
                    }
                }), DispatcherPriority.Background);
            }
        }

        public IEnumerable Source
        {
            get { return (IEnumerable)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(IEnumerable), typeof(SearchBox), new PropertyMetadata(null, OnSourceChanged));

        private static void OnSourceChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((SearchBox)sender).OnSourceChanged(args);
        }

        private void OnSourceChanged(DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue is IEnumerable)
            {
                this.collectionViewSource = new CollectionViewSource();
                this.collectionViewSource.Source = args.NewValue;
                this.collectionViewSource.Filter += OnCollectionViewSourceFilter;
                this.PropagateGroupDescriptionsToCollectionView();
                this.View = this.collectionViewSource.View;
            }
            else
            {
                this.collectionViewSource = null;
                this.View = null;
            }
        }

        public ICollectionView View
        {
            get { return (ICollectionView)GetValue(ViewProperty); }
            private set { SetValue(ViewProperty, value); }
        }

        // TODO: Make read only
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(ICollectionView), typeof(SearchBox), null);

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            private set { SetValue(IsOpenProperty, value); }
        }

        // TODO: Make read only
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(SearchBox), new PropertyMetadata(false, OnIsOpenChanged));

        private static void OnIsOpenChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((SearchBox)sender).OnIsOpenChanged(args);
        }

        private void OnIsOpenChanged(DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                Mouse.Capture(this, CaptureMode.SubTree);
            }
            else
            {
                Mouse.Capture(null);
                this.SearchText = String.Empty;
            }
        }

        static SearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchBox), new FrameworkPropertyMetadata(typeof(SearchBox)));
            IsTabStopProperty.OverrideMetadata(typeof(SearchBox), new FrameworkPropertyMetadata(false));
            EventManager.RegisterClassHandler(typeof(SearchBox), Keyboard.KeyDownEvent, new RoutedEventHandler(OnHandledKeyDown), true);
        }

        private static void OnHandledKeyDown(object sender, RoutedEventArgs e)
        {
            ((SearchBox)sender).OnHandledKeyDown(e as KeyEventArgs);
        }

        private CollectionViewSource collectionViewSource;
        private TextBox searchBox;
        private ResultBox searchList;

        private ObservableCollection<GroupDescription> groupDescriptions;
        public ObservableCollection<GroupDescription> GroupDescriptions
        {
            get
            {
                return this.groupDescriptions;
            }
        }

        private ObservableCollection<GroupStyle> resultGroupStyle;
        public ObservableCollection<GroupStyle> ResultGroupStyle
        {
            get
            {
                return this.resultGroupStyle;
            }
        }

        public SearchBox()
        {
            this.IsMouseCaptureWithinChanged += OnIsMouseCaptureWithinChanged;
            this.IsKeyboardFocusWithinChanged += OnIsKeyboardFocusWithinChanged;
            this.groupDescriptions = new ObservableCollection<GroupDescription>();
            this.GroupDescriptions.CollectionChanged += new NotifyCollectionChangedEventHandler(OnGroupDescriptionsCollectionChanged);
            this.resultGroupStyle = new ObservableCollection<GroupStyle>();
            this.ResultGroupStyle.CollectionChanged += new NotifyCollectionChangedEventHandler(OnResultGroupStyleCollectionChanged);
        }

        private void OnResultGroupStyleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.PropagateResultGroupStyleToSearchList();
        }

        private void OnGroupDescriptionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.PropagateGroupDescriptionsToCollectionView();
        }

        private void PropagateResultGroupStyleToSearchList()
        {
            if (this.searchList != null)
            {
                this.searchList.GroupStyle.Clear();
                foreach (GroupStyle gs in this.ResultGroupStyle)
                {
                    this.searchList.GroupStyle.Add(gs);
                }
            }
        }

        private void PropagateGroupDescriptionsToCollectionView()
        {
            if (this.collectionViewSource != null)
            {
                this.collectionViewSource.GroupDescriptions.Clear();
                foreach (GroupDescription gd in this.GroupDescriptions)
                {
                    this.collectionViewSource.GroupDescriptions.Add(gd);
                }
            }
        }

        private void OnIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
            {
                this.IsOpen = false;
            }
        }

        private void OnIsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsOpen && !(bool)e.NewValue)
            {
                Mouse.Capture(this, CaptureMode.SubTree);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.searchBox != null)
            {
                this.searchBox.GotFocus -= OnSearchBoxGotFocus;
            }
            this.searchBox = this.GetTemplateChild("PART_SearchBox") as TextBox;
            if (this.searchBox != null)
            {
                this.searchBox.GotFocus += OnSearchBoxGotFocus;
            }

            if (this.searchList != null)
            {
                this.searchList.SearchSelection -= OnResultListSearchSelection;
            }
            this.searchList = this.GetTemplateChild("PART_SearchList") as ResultBox;
            if (this.searchList != null)
            {
                this.PropagateResultGroupStyleToSearchList();
                this.searchList.SearchSelection += OnResultListSearchSelection;
                this.searchList.HighlightedIndex = 0;
            }
        }

        private void OnResultListSearchSelection(object sender, SearchSelectionEventArgs e)
        {
            this.OnSearchSelection();
        }

        private void OnSearchListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.OnSearchSelection();
        }

        protected void OnSearchBoxGotFocus(object sender, RoutedEventArgs e)
        {
            this.IsOpen = true;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (e.OriginalSource == this && this.IsOpen)
            {
                this.IsOpen = false;
                this.Focus();
                e.Handled = true;
            }
        }

        private void OnHandledKeyDown(KeyEventArgs e)
        {
            if (this.IsOpen && (!e.Handled || (e.Handled && e.OriginalSource == this.searchBox)))
            {
                if (this.searchList != null)
                {
                    switch (e.Key)
                    {
                        case Key.Up:
                            this.searchList.HighlightedIndex = Math.Max(0, this.searchList.HighlightedIndex - 1);
                            this.searchList.ScrollIntoView(searchList.HighlightedItem);
                            break;
                        case Key.Down:
                            this.searchList.HighlightedIndex++;
                            this.searchList.ScrollIntoView(searchList.HighlightedItem);
                            break;
                        case Key.PageUp:
                            this.searchList.HighlightedIndex = Math.Max(0, this.searchList.HighlightedIndex - 10);
                            this.searchList.ScrollIntoView(searchList.HighlightedItem);
                            break;
                        case Key.PageDown:
                            this.searchList.HighlightedIndex += 10;
                            this.searchList.ScrollIntoView(searchList.HighlightedItem);
                            break;
                        case Key.Enter:
                            this.OnSearchSelection();
                            break;
                    }
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.IsOpen && !e.Handled && e.Key == Key.Escape)
            {
                this.IsOpen = false;
                if (this.searchBox != null)
                {
                    this.searchBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        private void OnCollectionViewSourceFilter(object sender, FilterEventArgs e)
        {
            if (this.Filter != null)
            {
                this.Filter.Invoke(this, new SearchFilterEventArgs(this.SearchText, e));
            }
        }

        private void OnSearchSelection()
        {
            if (this.SearchSelection != null && this.searchList != null && this.searchList.HighlightedItem != null)
            {
                this.SearchSelection.Invoke(this, new SearchSelectionEventArgs(this.searchList.HighlightedItem));
                this.IsOpen = false;
                this.Focus();
            }
        }

        public event SearchFilterEventHandler Filter;

        public event SearchSelectionEventHandler SearchSelection;
    }
}
