using System.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics;

namespace Rox
{
    /// <summary>
    /// The OverlayLayout allows you to add child views which will be overlayed in the content layout.
    /// </summary>
    public class OverlayLayout
        : Layout<View>,
        IElementConfiguration<OverlayLayout>
    {
        #region Construct

        private readonly Lazy<PlatformConfigurationRegistry<OverlayLayout>> PlatformConfigurationRegistry;

        /// <summary>
        /// Constructs an OverlayLayout that allows you to add child views which will be overlayed in the content layout.
        /// </summary>
        public OverlayLayout()
        {
            PlatformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<OverlayLayout>>(() => new PlatformConfigurationRegistry<OverlayLayout>(this));
        }

        /// <summary>
        /// Returns a platform element configuration for the specified platform.
        /// </summary>
        /// <typeparam name="T">Type of referenced IConfigPlatform.</typeparam>
        /// <returns>A platform element configuration for the specified platform.</returns>
        public IPlatformElementConfiguration<T, OverlayLayout> On<T>()
            where T : IConfigPlatform
        {
            return PlatformConfigurationRegistry.Value.On<T>();
        }

        #endregion

        #region Attached-PaddingOverride

        /// <summary>
        /// The bindable property for the PaddingOverride attached property.
        /// </summary>
        public static readonly BindableProperty PaddingOverrideProperty = BindableProperty.CreateAttached(
            nameof(OverlayExtension.PaddingOverride),
            typeof(Thickness),
            typeof(OverlayLayout),
            new Thickness(0));

        /// <summary>
        /// Gets the value of the PaddingOverride attached property for the specified child view if set otherwise the default value.
        /// </summary>
        /// <param name="bindable">The OverlayLayout child view for which the attached property is being requested.</param>
        /// <returns>Returns the value of the PaddingOverride attached property for the specified child view if set otherwise the default value.</returns>
        public static Thickness GetPaddingOverride(BindableObject bindable) =>
            (Thickness)bindable.GetValue(PaddingOverrideProperty);

        /// <summary>
        /// Sets the value of the PaddingOverride attached property for the specified child view.
        /// </summary>
        /// <param name="bindable">The OverlayLayout child view for which the attached property is being set.</param>
        /// <param name="value">The value to set for the PaddingOverride attached property.</param>
        public static void SetPaddingOverride(BindableObject bindable, Thickness value) =>
            bindable.SetValue(PaddingOverrideProperty, value);

        #endregion

        #region ItemPropertyChanged

        ///<inheritdoc />
        protected override void OnAdded(View view)
        {
            base.OnAdded(view);

            view.PropertyChanged += OnItemPropertyChanged;
        }

        ///<inheritdoc />
        protected override void OnRemoved(View view)
        {
            base.OnRemoved(view);

            view.PropertyChanged -= OnItemPropertyChanged;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OverlayExtension.PaddingOverride))
            {
                //Note: Attached property changed

                InvalidateLayout();
            }
        }

        #endregion

        #region Calculate Layout

        /// <summary>
        /// Calculates the OverlayContent for the specified width and height.
        /// </summary>
        /// <param name="controlWidth">The width to use when calculating the layout.</param>
        /// <param name="controlHeight">The height to use when calculating the layout.</param>
        /// <param name="buildContent">Specifies whether to build and return the content objects which are only required for layout.</param>
        /// <returns>Returns the calculated OverlayContent for the specified width and height.</returns>
        protected virtual OverlayContent CalculateContent(double controlWidth, double controlHeight, bool buildContent = false)
        {
            //Note: Remove Padding from Control and reassign to each Item considering PaddingOverride

            double contentWidth = controlWidth + Padding.HorizontalThickness;
            double contentHeight = controlHeight + Padding.VerticalThickness;
            Size contentSize = new Size(contentWidth, contentHeight);

            //Note: Initialise content property values

            double minimumHeight = 0;
            double minimumWidth = 0;
            IList<OverlayItem> items = buildContent ? new List<OverlayItem>() : null;

            //Note: Check for visible views

            View[] itemViews = Children.Where(predicateView => predicateView.IsVisible).ToArray();

            if (itemViews.Length > 0)
            {
                //Note: Iterate child views

                foreach (View itemView in itemViews)
                {
                    //Note: Control.Padding reassigned for each Item considering PaddingOverride

                    Thickness itemPadding;
                    if (itemView.IsSet(PaddingOverrideProperty))
                    {
                        itemPadding = GetPaddingOverride(itemView);
                    }
                    else
                    {
                        itemPadding = Padding;
                    }

                    //Note: Remove applicable Padding from item

                    double itemMeasureWidth = contentSize.Width - itemPadding.HorizontalThickness;
                    double itemMeasureHeight = contentSize.Height - itemPadding.VerticalThickness;
                    Size itemMeasureSize = new Size(itemMeasureWidth, itemMeasureHeight);

                    //Note: Measure Item

                    SizeRequest itemSizeRequest = itemView.Measure(itemMeasureSize.Width, itemMeasureSize.Height);

                    double itemWidth = itemSizeRequest.Request.Width;
                    double itemHeight = itemSizeRequest.Request.Height;

                    //Note: Add current Item if building content

                    if (buildContent)
                    {
                        OverlayItem item = new OverlayItem(itemView, itemWidth, itemView.MinimumWidthRequest, itemView.WidthRequest, itemHeight, itemView.MinimumHeightRequest, itemView.HeightRequest, itemPadding);
                        items.Add(item);
                    }

                    //Note: Set content minimums

                    minimumWidth = Math.Max(minimumWidth, itemWidth);
                    minimumHeight = Math.Max(minimumHeight, itemHeight);
                }
            }

            return new OverlayContent(items, contentSize, new Size(minimumWidth, minimumHeight));
        }

        /// <summary>
        /// Calculates the layout point on the X axis for the specified item.
        /// </summary>
        /// <param name="contentX">The X point of the content.</param>
        /// <param name="contentWidth">The width measure of the content.</param>
        /// <param name="paddingLeft">The left/X padding measure of the item.</param>
        /// <param name="horizontalAlignment">The horizontal alignment of the item.</param>
        /// <param name="itemWidth">The width measure of the item.</param>
        /// <returns>Returns the calculated layout point on the X axis for the specified item.</returns>
        protected virtual LayoutAxis CalculateLayoutItemXAxis(double contentX, double contentWidth, double paddingLeft, double paddingWidth, LayoutOptions horizontalLayoutOptions, double itemWidth, double itemMinimumWidth, double itemMaximumWidth)
        {
            //Note: Padding.HorizontalThickness is not required as Item has PaddingSize already applied

            //Note: Expand is redundant in OverlayLayout set to contentWidth

            return LayoutExtension.CalculateLayoutItemAxis(contentX, contentWidth, contentWidth, paddingLeft, paddingWidth, horizontalLayoutOptions, itemWidth, itemMinimumWidth, itemMaximumWidth);
        }

        /// <summary>
        /// Calculates the layout point on the Y axis for the specified item.
        /// </summary>
        /// <param name="contentY">The Y point of the content.</param>
        /// <param name="contentHeight">The height measure of the content.</param>
        /// <param name="paddingTop">The top padding measure of the item.</param>
        /// <param name="verticalAlignment">The vertical alignment of the item.</param>
        /// <param name="itemHeight">The height measure of the item.</param>
        /// <returns>Returns the calculated layout point on the Y axis for the specified item.</returns>
        protected virtual LayoutAxis CalculateLayoutItemYAxis(double contentY, double contentHeight, double paddingTop, double paddingHeight, LayoutOptions verticalLayoutOptions, double itemHeight, double itemMinimumHeight, double itemMaximumHeight)
        {
            //Note: Padding.HorizontalThickness is not required as Item has PaddingSize already applied

            //Note: Expand is redundant in OverlayLayout set to contentHeight

            return LayoutExtension.CalculateLayoutItemAxis(contentY, contentHeight, contentHeight, paddingTop, paddingHeight, verticalLayoutOptions, itemHeight, itemMinimumHeight, itemMaximumHeight);
        }

        #endregion

        #region Perform Layout

        ///<inheritdoc />
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            double internalWidth = double.IsPositiveInfinity(widthConstraint) ? double.PositiveInfinity : Math.Max(0, widthConstraint);
            double internalHeight = double.IsPositiveInfinity(heightConstraint) ? double.PositiveInfinity : Math.Max(0, heightConstraint);

            //Note: Calculate the OverlayContent based on the specified width and height

            OverlayContent content = CalculateContent(internalWidth, internalHeight);

            //Note: Set the content minimum size as the both the request size and the minimum size.

            SizeRequest sizeRequest = new SizeRequest(new Size(content.MinimumSize.Width, content.MinimumSize.Height), new Size(content.MinimumSize.Width, content.MinimumSize.Height));

            return sizeRequest;
        }

        ///<inheritdoc />
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            //Note: Calculate the OverlayContent based on the specified width and height

            OverlayContent content = CalculateContent(width, height, true);

            //Note: Calculate only the padding offset point as the padding size is included in Item.

            double contentX = x - Padding.Left;
            double contentY = y - Padding.Top;

            foreach (OverlayItem item in content.Items)
            {
                //Note: Calculate the LayoutAxis for the current item on the X axis and Y axis including PaddingSize which is already applied to OverlayItem

                LayoutAxis layoutAxisX = CalculateLayoutItemXAxis(contentX, content.Size.Width, item.Padding.Left, item.Padding.HorizontalThickness, item.View.HorizontalOptions, item.Width, item.MinimumWidth, item.MaximumWidth);
                LayoutAxis layoutAxisY = CalculateLayoutItemYAxis(contentY, content.Size.Height, item.Padding.Top, item.Padding.VerticalThickness, item.View.VerticalOptions, item.Height, item.MinimumHeight, item.MaximumWidth);

                //Note: Calculate the Rectangle based on the specified LayoutAxis coordinates

                Rectangle itemRectangle = new Rectangle(layoutAxisX.Point, layoutAxisY.Point, layoutAxisX.Measure, layoutAxisY.Measure);

                //Note: Layout the current child view in this content

                LayoutChildIntoBoundingRegion(item.View, itemRectangle);
            }
        }

        #endregion

        #region Internal

        /// <summary>
        /// Internal object that represents a child view in a content layout.
        /// </summary>
        protected class OverlayItem
        {
            /// <summary>
            /// Constructs a new content item object with the given properties.
            /// </summary>
            /// <param name="view">The child view for this item.</param>
            /// <param name="size">The size of the child view for this item.</param>
            /// <param name="padding">The padding of the child view for this item.</param>
            public OverlayItem(View view, double width, double minimumWidth, double maximumWidth, double height, double minimumHeight, double maximumHeight, Thickness padding)
            {
                View = view;
                Width = width;
                MinimumWidth = minimumWidth;
                MaximumWidth = maximumWidth;
                Height = height;
                MinimumHeight = minimumHeight;
                MaximumHeight = maximumHeight;
                Padding = padding;
            }

            /// <summary>
            /// Get the child view for this item.
            /// </summary>
            public View View { get; }

            public double Width { get; }

            public double MinimumWidth { get; }

            public double MaximumWidth { get; }

            public double Height { get; }

            public double MinimumHeight { get; }

            public double MaximumHeight { get; }

            /// <summary>
            /// Gets the padding offset point of the child view for this item.
            /// </summary>
            public Thickness Padding { get; }
        }

        /// <summary>
        /// Internal object that represents a content layout.
        /// </summary>
        protected class OverlayContent
        {
            /// <summary>
            /// Constructs a new content layout object with the given properties.
            /// </summary>
            /// <param name="items">The child view representations of this content layout.</param>
            /// <param name="size">The width and height of this content layout.</param>
            /// <param name="minimumSize">The minimum width and minimum height of this content layout.</param>
            public OverlayContent(IList<OverlayItem> items, Size size, Size minimumSize)
            {
                Items = items;
                Size = size;
                MinimumSize = minimumSize;
            }

            /// <summary>
            /// The child view representations of this content layout.
            /// </summary>
            public IList<OverlayItem> Items { get; }

            /// <summary>
            /// The width and height of this content layout.
            /// </summary>
            public Size Size { get; }

            /// <summary>
            /// The minimum width and minimum height of this content layout.
            /// </summary>
            public Size MinimumSize { get; }
        }

        #endregion
    }
}