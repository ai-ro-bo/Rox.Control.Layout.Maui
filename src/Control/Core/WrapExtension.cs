using Microsoft.Maui.Controls;

namespace Rox
{
    public static class WrapExtension
    {
        #region SpacingOverride

        /// <summary>
        /// Child property setter for the SpacingOverride attached property.
        /// </summary>
        /// <typeparam name="TView">The type of View that the specified child implements.</typeparam>
        /// <param name="view">The child view for which to apply the attached property value.</param>
        /// <param name="spacingOverride">The value to apply to the child view attached property.</param>
        /// <returns>A copy of the child view for which this attached property has been applied.</returns>
        public static TView SpacingOverride<TView>(this TView view, double spacingOverride)
            where TView : View
        {
            WrapLayout.SetSpacingOverride(view, spacingOverride);

            return view;
        }

        #endregion

        #region ForceNewDimension

        /// <summary>
        /// Child property setter for the ForceNewDimension attached property.
        /// </summary>
        /// <typeparam name="TView">The type of View that the specified child implements.</typeparam>
        /// <param name="view">The child view for which to apply the attached property value.</param>
        /// <param name="forceNewDimension">The value to apply to the child view attached property.</param>
        /// <returns>A copy of the child view for which this attached property has been applied.</returns>
        public static TView ForceNewDimension<TView>(this TView view, bool forceNewDimension)
            where TView : View
        {
            WrapLayout.SetForceNewDimension(view, forceNewDimension);

            return view;
        }

        #endregion
    }
}