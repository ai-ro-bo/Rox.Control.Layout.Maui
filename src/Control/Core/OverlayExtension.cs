using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Rox
{
    public static class OverlayExtension
    {
        #region PaddingOverride

        /// <summary>
        /// Child property setter for the PaddingOverride attached property.
        /// </summary>
        /// <typeparam name="TView">The type of View that the specified child implements.</typeparam>
        /// <param name="view">The child view for which to apply the attached property value.</param>
        /// <param name="paddingOverride">The value to apply to the child view attached property.</param>
        /// <returns>A copy of the child view for which this attched property has been applied.</returns>
        public static TView PaddingOverride<TView>(this TView view, Thickness paddingOverride)
            where TView : View
        {
            OverlayLayout.SetPaddingOverride(view, paddingOverride);

            return view;
        }

        #endregion

        #region CalculatePaddingPoint

        ///// <summary>
        ///// Calculates a new point based on a specified padding.
        ///// </summary>
        ///// <param name="padding">The padding to be applied.</param>
        ///// <param name="x">The point on the X axis to apply the specified padding.</param>
        ///// <param name="y">The point on the Y axis to apply the specified padding.</param>
        ///// <returns>Returns the calculated point based on a specified padding.</returns>
        //public static Point CalculatePaddingPoint(this Thickness padding, double x, double y)
        //{
        //    double contentX = x - padding.Left;
        //    double contentY = y - padding.Top;

        //    return new Point(contentX, contentY);
        //}

        #endregion

        #region CalculatePaddingSize

        ///// <summary>
        ///// Calculates a new size based on a specified padding.
        ///// </summary>
        ///// <param name="padding">The padding to be applied.</param>
        ///// <param name="width">The measure on the X axis to apply the specified padding.</param>
        ///// <param name="height">The measure on the Y axis to apply the specified padding.</param>
        ///// <returns>Returns the Calculated size based on a specified padding.</returns>
        //public static Size CalculatePaddingSize(this Thickness padding, double width, double height)
        //{
        //    double contentWidth = width + padding.HorizontalThickness;
        //    double contentHeight = height + padding.VerticalThickness;

        //    return new Size(contentWidth, contentHeight);
        //}

        #endregion
    }
}