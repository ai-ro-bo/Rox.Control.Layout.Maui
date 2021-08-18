using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Rox
{
    /// <summary>
    /// Contains extension methods used by views during the measure and layout cycles.
    /// </summary>
    public static class LayoutExtension
    {
        #region CalculateLayoutSizeRequest

        /// <summary>
        /// Calculates the layout request size and minimum size for the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation of the layout.</param>
        /// <param name="fitMeasure">The fit measure of the content.</param>
        /// <param name="flowMeasure">The flow measure of the content.</param>
        /// <param name="fitMinimumMeasure">The fit minimum measure of the content.</param>
        /// <param name="flowMinimumMeasure">The flow minimum measure of the content.</param>
        /// <returns>Returns the calculated layout request size and minimum size for the specified orientation.</returns>
        public static SizeRequest CalculateLayoutSizeRequest(this LayoutOrientation orientation, double fitMeasure, double flowMeasure, double fitMinimumMeasure, double flowMinimumMeasure)
        {
            SizeRequest sizeRequest;
            if (orientation == LayoutOrientation.Horizontal)
            {
                sizeRequest = new SizeRequest(
                    new Size(fitMeasure, flowMeasure),
                    new Size(fitMinimumMeasure, flowMinimumMeasure));
            }
            else
            {
                sizeRequest = new SizeRequest(
                    new Size(flowMeasure, fitMeasure),
                    new Size(flowMinimumMeasure, fitMinimumMeasure));
            }
            return sizeRequest;
        }

        #endregion

        #region CalculateLayoutRectangle

        /// <summary>
        /// Calculates the layout rectangle for the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation of the layout.</param>
        /// <param name="x">The point on the X axis of the layout.</param>
        /// <param name="y">The point on the Y axis of the layout.</param>
        /// <param name="width">The width measure on the X axis of the layout.</param>
        /// <param name="height">The height measure on the Y axis of the layout.</param>
        /// <returns>Returns the calculated layout rectangle for the specified orientation.</returns>
        public static LayoutRectangle CalculateLayoutRectangle(this LayoutOrientation orientation, double x, double y, double width, double height)
        {
            double fitPoint;
            double flowPoint;
            double fitMeasure;
            double flowMeasure;

            if (orientation == LayoutOrientation.Horizontal)
            {
                fitPoint = x;
                flowPoint = y;
                fitMeasure = width;
                flowMeasure = height;
            }
            else
            {
                fitPoint = y;
                flowPoint = x;
                fitMeasure = height;
                flowMeasure = width;
            }

            LayoutRectangle layoutRectangle = new LayoutRectangle(fitPoint, flowPoint, fitMeasure, flowMeasure);

            return layoutRectangle;
        }

        #endregion

        #region CalculateLayoutNativeRectangle

        /// <summary>
        /// Calculates the layout native rectangle for the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation of the layout.</param>
        /// <param name="fitAxis">The fit axis point and measure of the layout.</param>
        /// <param name="flowAxis">The flow axis point and measure of the layout.</param>
        /// <returns>Returns the calculated layout native rectangle for the specified orientation.</returns>
        public static Rectangle CalculateLayoutNativeRectangle(this LayoutOrientation orientation, LayoutAxis fitAxis, LayoutAxis flowAxis)
        {
            return orientation.CalculateLayoutNativeRectangle(fitAxis.Point, flowAxis.Point, fitAxis.Measure, flowAxis.Measure);
        }

        /// <summary>
        /// Calculates the layout native rectangle for the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation of the layout.</param>
        /// <param name="fitPoint">The point on the fit axis of the layout.</param>
        /// <param name="flowPoint">The point on the flow axis of the layout.</param>
        /// <param name="fitMeasure">The measure of the fit axis of the layout.</param>
        /// <param name="flowMeasure">The measure of the flow axis of the layout.</param>
        /// <returns>Returns the calculated layout native rectangle for the specified orientation.</returns>
        public static Rectangle CalculateLayoutNativeRectangle(this LayoutOrientation orientation, double fitPoint, double flowPoint, double fitMeasure, double flowMeasure)
        {
            double x;
            double y;
            double width;
            double height;

            if (orientation == LayoutOrientation.Horizontal)
            {
                x = fitPoint;
                y = flowPoint;
                width = fitMeasure;
                height = flowMeasure;
            }
            else
            {
                x = flowPoint;
                y = fitPoint;
                width = flowMeasure;
                height = fitMeasure;
            }

            Rectangle rectangle = new Rectangle(x, y, width, height);

            return rectangle;
        }

        #endregion

        #region CalculateLayoutDimensionAxis

        /// <summary>
        /// Calculates the Axis coordinates for a dimension.
        /// </summary>
        /// <param name="controlPoint">The X/Y of the parent control.</param>
        /// <param name="controlMeasure">The Height/Width of the parent control.</param>
        /// <param name="containerMeasure">The Height/Width of the content/dimension.</param>
        /// <param name="currentContainerMeasure">The currently used Height/Width of the content/dimension.</param>
        /// <param name="containerExpandCount">The Count of expandable dimensions/items.</param>
        /// <param name="layoutMeasure">The Height/Width of this dimension/item.</param>
        /// <param name="layoutExpands">Specifies if this layout expands.</param>
        /// <param name="spacing">The Spacing to assign between diemsions/items.</param>
        /// <param name="fillSpacing">The Spacing to assign between dimension/items if the container is filled.</param>
        /// <param name="index">The index of this item.</param>
        /// <param name="count">The total count of items in the collection being calculated.</param>
        /// <param name="contentAlignment">The LayoutAlignment of this axis.</param>
        /// <param name="endParagraphContentAlignment">If contentAlignment=Fill then this will set the LayoutAlignment for a EndParagraph dimension.</param>
        /// <param name="endParagraph">Specifies that this Dimension is the last Dimension or preceeding a forced new Dimension.</param>
        /// <returns>The Axis coordinates calculated for the given dimension.</returns>
        public static LayoutAxis CalculateLayoutDimensionAxis(double controlPoint, double controlMeasure, double containerMeasure, double currentContainerMeasure, int containerExpandCount, double layoutMeasure, bool layoutExpands, double spacing, double fillSpacing, int index, int count, LayoutAlignment contentAlignment, LayoutAlignment endParagraphContentAlignment, bool endParagraph)
        {
            //Note: Single Item in a Dimension in Alignment.Fill will be set to Alignment.Center

            LayoutAlignment layoutAlignment;
            if (containerExpandCount > 0)
            {
                layoutAlignment = LayoutAlignment.Start;
            }
            else
            {
                if (contentAlignment == LayoutAlignment.Fill)
                {
                    if (endParagraph)
                    {
                        if (endParagraphContentAlignment == LayoutAlignment.Fill)
                        {
                            if (count == 1)
                            {
                                layoutAlignment = LayoutAlignment.Center;
                            }
                            else
                            {
                                layoutAlignment = LayoutAlignment.Fill;
                            }
                        }
                        else
                        {
                            layoutAlignment = endParagraphContentAlignment;
                        }
                    }
                    else
                    {
                        if (count == 1)
                        {
                            layoutAlignment = LayoutAlignment.Center;
                        }
                        else
                        {
                            layoutAlignment = LayoutAlignment.Fill;
                        }
                    }
                }
                else
                {
                    layoutAlignment = contentAlignment;
                }
            }

            double point;
            if (index > 0)
            {
                //Note: Not first item - current measure plus appropriate spacing

                point = currentContainerMeasure;
                if (layoutAlignment != LayoutAlignment.Fill)
                {
                    point += spacing;
                }
                else
                {
                    point += fillSpacing;
                }
            }
            else
            {
                //Note: Calculate initial point

                switch (layoutAlignment)
                {
                    case LayoutAlignment.End:
                        {
                            double difference = controlMeasure - containerMeasure;
                            if (difference > 0)
                            {
                                point = controlPoint + difference;
                            }
                            else
                            {
                                point = controlPoint;
                            }
                            break;
                        }
                    case LayoutAlignment.Center:
                        {
                            double difference = controlMeasure - containerMeasure;
                            if (difference > 0)
                            {
                                point = controlPoint + (difference / 2);
                            }
                            else
                            {
                                point = controlPoint;
                            }
                            break;
                        }
                    case LayoutAlignment.Fill:
                    case LayoutAlignment.Start:
                    default:
                        {
                            point = controlPoint;
                            break;
                        }
                }
            }

            double measure;
            if (layoutExpands)
            {
                measure = layoutMeasure + ((controlMeasure - containerMeasure) / containerExpandCount);
            }
            else
            {
                measure = layoutMeasure;
            }

            return new LayoutAxis(point, measure);
        }

        #endregion

        #region CalculateLayoutItemAxis

        /// <summary>
        /// Calculates the layout point on the specified axis for the specified item.
        /// </summary>
        /// <param name="contentPoint">The axis point of the content.</param>
        /// <param name="contentExpandMeasure">The axis measure of the content if expanded.</param>
        /// <param name="contentMeasure">The axis measure of the content.</param>
        /// <param name="paddingOffset">The padding offset point of the item.</param>
        /// <param name="paddingMeasure">The padding measure of the item.</param>
        /// <param name="itemAlignment">The layout alignment of the item.</param>
        /// <param name="itemMeasure">The axis measure of the item.</param>
        /// <returns>Returns the calculated layout point on the specified axis for the specified item.</returns>
        public static LayoutAxis CalculateLayoutItemAxis(double contentPoint, double contentExpandMeasure, double contentMeasure, double paddingOffset, double paddingMeasure, LayoutOptions itemLayoutOptions, double itemMeasure, double itemMinimumMeasure, double itemMaximumMeasure)
        {
            double point = contentPoint + paddingOffset;
            double newContentMeasure;
            if (itemLayoutOptions.Expands)
            {
                newContentMeasure = Math.Max(contentExpandMeasure, contentMeasure);
            }
            else
            {
                point += Math.Max((contentExpandMeasure - contentMeasure) / 2, 0d);
                newContentMeasure = contentMeasure;
            }

            double measure;
            switch (itemLayoutOptions.Alignment)
            {
                case LayoutAlignment.Start:
                    {
                        measure = itemMeasure;
                        break;
                    }
                case LayoutAlignment.End:
                    {
                        measure = itemMeasure;
                        point += newContentMeasure - itemMeasure - paddingMeasure;
                        break;
                    }
                case LayoutAlignment.Center:
                    {
                        measure = itemMeasure;
                        point += (newContentMeasure - itemMeasure - paddingMeasure) / 2;
                        break;
                    }
                case LayoutAlignment.Fill:
                default:
                    {
                        measure = newContentMeasure - paddingMeasure;
                        break;
                    }
            }

            //Note: Clamp measure to minimum and maximum

            if (itemMinimumMeasure > 0) measure = Math.Max(measure, itemMinimumMeasure);
            if (itemMaximumMeasure > 0) measure = Math.Min(measure, itemMaximumMeasure);

            return new LayoutAxis(point, measure);
        }

        #endregion
    }
}