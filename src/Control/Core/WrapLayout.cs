using System.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics;

namespace Rox
{
    /// <summary>
    /// The WrapLayout allows you to add child controls and it will calculate a wrapping layout for a given measure.
    /// </summary>
    public class WrapLayout
        : Layout<View>,
        IElementConfiguration<WrapLayout>
    {
        #region Construct

        private readonly Lazy<PlatformConfigurationRegistry<WrapLayout>> PlatformConfigurationRegistry;

        /// <summary>
        /// Constructs a WrapLayout that allows you to add child controls and it will calculate a wrapping layout for a given measure.
        /// </summary>
        public WrapLayout()
        {
            PlatformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<WrapLayout>>(() => new PlatformConfigurationRegistry<WrapLayout>(this));
        }

        /// <summary>
        /// Returns a platform element configuration for the specified platform.
        /// </summary>
        /// <typeparam name="T">Type of referenced IConfigPlatform.</typeparam>
        /// <returns>A platform element configuration for the specified platform.</returns>
        public IPlatformElementConfiguration<T, WrapLayout> On<T>()
            where T : IConfigPlatform
        {
            return PlatformConfigurationRegistry.Value.On<T>();
        }

        #endregion

        #region Orientation

        /// <summary>
        /// The bindable property for the Orientation property.
        /// </summary>
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
            nameof(Orientation),
            typeof(LayoutOrientation),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).OrientationValidateValue((WrapLayout)bindable, (LayoutOrientation)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).OrientationPropertyChanged((WrapLayout)bindable, (LayoutOrientation)oldValue, (LayoutOrientation)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).OrientationPropertyChanging((WrapLayout)bindable, (LayoutOrientation)oldValue, (LayoutOrientation)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).OrientationCoerceValue((WrapLayout)bindable, (LayoutOrientation)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).OrientationDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The Orientation of the layout.
        /// </summary>
        public LayoutOrientation Orientation
        {
            get => (LayoutOrientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the Orientation value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool OrientationValidateValue(WrapLayout wrapLayout, LayoutOrientation value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void OrientationPropertyChanged(WrapLayout wrapLayout, LayoutOrientation oldValue, LayoutOrientation newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void OrientationPropertyChanging(WrapLayout wrapLayout, LayoutOrientation oldValue, LayoutOrientation newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual LayoutOrientation OrientationCoerceValue(WrapLayout wrapLayout, LayoutOrientation value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual LayoutOrientation OrientationDefaultValueCreator(WrapLayout wrapLayout) =>
            LayoutOrientation.Horizontal;

        #endregion

        #region OrientationReverse

        /// <summary>
        /// The bindable property for the OrientationReverse property.
        /// </summary>
        public static readonly BindableProperty OrientationReverseProperty = BindableProperty.Create(
            nameof(OrientationReverse),
            typeof(LayoutOrientationReverse),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).OrientationReverseValidateValue((WrapLayout)bindable, (LayoutOrientationReverse)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).OrientationReversePropertyChanged((WrapLayout)bindable, (LayoutOrientationReverse)oldValue, (LayoutOrientationReverse)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).OrientationReversePropertyChanging((WrapLayout)bindable, (LayoutOrientationReverse)oldValue, (LayoutOrientationReverse)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).OrientationReverseCoerceValue((WrapLayout)bindable, (LayoutOrientationReverse)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).OrientationReverseDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// Determines if either or both axis are reversed in the layout.
        /// </summary>
        public LayoutOrientationReverse OrientationReverse
        {
            get => (LayoutOrientationReverse)GetValue(OrientationReverseProperty);
            set => SetValue(OrientationReverseProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the OrientationReverse value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool OrientationReverseValidateValue(WrapLayout wrapLayout, LayoutOrientationReverse value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void OrientationReversePropertyChanged(WrapLayout wrapLayout, LayoutOrientationReverse oldValue, LayoutOrientationReverse newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void OrientationReversePropertyChanging(WrapLayout wrapLayout, LayoutOrientationReverse oldValue, LayoutOrientationReverse newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual LayoutOrientationReverse OrientationReverseCoerceValue(WrapLayout wrapLayout, LayoutOrientationReverse value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual LayoutOrientationReverse OrientationReverseDefaultValueCreator(WrapLayout wrapLayout) =>
            LayoutOrientationReverse.None;

        #endregion

        #region HorizontalContentAlignment

        /// <summary>
        /// The bindable property for the HorizontalContentAlignment property.
        /// </summary>
        public static readonly BindableProperty HorizontalContentAlignmentProperty = BindableProperty.Create(
            nameof(HorizontalContentAlignment),
            typeof(LayoutAlignment),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).HorizontalContentAlignmentValidateValue((WrapLayout)bindable, (LayoutAlignment)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).HorizontalContentAlignmentPropertyChanged((WrapLayout)bindable, (LayoutAlignment)oldValue, (LayoutAlignment)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).HorizontalContentAlignmentPropertyChanging((WrapLayout)bindable, (LayoutAlignment)oldValue, (LayoutAlignment)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).HorizontalContentAlignmentCoerceValue((WrapLayout)bindable, (LayoutAlignment)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).HorizontalContentAlignmentDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The layout alignment of the control on the X axis.
        /// </summary>
        public LayoutAlignment HorizontalContentAlignment
        {
            get => (LayoutAlignment)GetValue(HorizontalContentAlignmentProperty);
            set => SetValue(HorizontalContentAlignmentProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the HorizontalContentAlignment value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool HorizontalContentAlignmentValidateValue(WrapLayout wrapLayout, LayoutAlignment value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void HorizontalContentAlignmentPropertyChanged(WrapLayout wrapLayout, LayoutAlignment oldValue, LayoutAlignment newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void HorizontalContentAlignmentPropertyChanging(WrapLayout wrapLayout, LayoutAlignment oldValue, LayoutAlignment newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual LayoutAlignment HorizontalContentAlignmentCoerceValue(WrapLayout wrapLayout, LayoutAlignment value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual LayoutAlignment HorizontalContentAlignmentDefaultValueCreator(WrapLayout wrapLayout) =>
            LayoutAlignment.Start;

        #endregion

        #region HorizontalSpacing

        /// <summary>
        /// The bindable property for the HorizontalSpacing property.
        /// </summary>
        public static readonly BindableProperty HorizontalSpacingProperty = BindableProperty.Create(
            nameof(HorizontalSpacing),
            typeof(double),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).HorizontalSpacingValidateValue((WrapLayout)bindable, (double)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).HorizontalSpacingPropertyChanged((WrapLayout)bindable, (double)oldValue, (double)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).HorizontalSpacingPropertyChanging((WrapLayout)bindable, (double)oldValue, (double)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).HorizontalSpacingCoerceValue((WrapLayout)bindable, (double)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).HorizontalSpacingDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The spacing measure between controls on the X axis.
        /// </summary>
        public double HorizontalSpacing
        {
            get => (double)GetValue(HorizontalSpacingProperty);
            set => SetValue(HorizontalSpacingProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the HorizontalSpacing value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool HorizontalSpacingValidateValue(WrapLayout wrapLayout, double value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void HorizontalSpacingPropertyChanged(WrapLayout wrapLayout, double oldValue, double newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void HorizontalSpacingPropertyChanging(WrapLayout wrapLayout, double oldValue, double newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual double HorizontalSpacingCoerceValue(WrapLayout wrapLayout, double value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual double HorizontalSpacingDefaultValueCreator(WrapLayout wrapLayout) =>
            8d;

        #endregion

        #region VerticalContentAlignment

        /// <summary>
        /// The bindable property for the VerticalContentAlignment property.
        /// </summary>
        public static readonly BindableProperty VerticalContentAlignmentProperty = BindableProperty.Create(
            nameof(VerticalContentAlignment),
            typeof(LayoutAlignment),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).VerticalContentAlignmentValidateValue((WrapLayout)bindable, (LayoutAlignment)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).VerticalContentAlignmentPropertyChanged((WrapLayout)bindable, (LayoutAlignment)oldValue, (LayoutAlignment)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).VerticalContentAlignmentPropertyChanging((WrapLayout)bindable, (LayoutAlignment)oldValue, (LayoutAlignment)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).VerticalContentAlignmentCoerceValue((WrapLayout)bindable, (LayoutAlignment)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).VerticalContentAlignmentDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The layout alignment of the control on the Y axis.
        /// </summary>
        public LayoutAlignment VerticalContentAlignment
        {
            get => (LayoutAlignment)GetValue(VerticalContentAlignmentProperty);
            set => SetValue(VerticalContentAlignmentProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the VerticalContentAlignment value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool VerticalContentAlignmentValidateValue(WrapLayout wrapLayout, LayoutAlignment value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void VerticalContentAlignmentPropertyChanged(WrapLayout wrapLayout, LayoutAlignment oldValue, LayoutAlignment newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void VerticalContentAlignmentPropertyChanging(WrapLayout wrapLayout, LayoutAlignment oldValue, LayoutAlignment newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual LayoutAlignment VerticalContentAlignmentCoerceValue(WrapLayout wrapLayout, LayoutAlignment value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual LayoutAlignment VerticalContentAlignmentDefaultValueCreator(WrapLayout wrapLayout) =>
            LayoutAlignment.Start;

        #endregion

        #region VerticalSpacing

        /// <summary>
        /// The bindable property for the VerticalSpacing property.
        /// </summary>
        public static readonly BindableProperty VerticalSpacingProperty = BindableProperty.Create(
            nameof(VerticalSpacing),
            typeof(double),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).VerticalSpacingValidateValue((WrapLayout)bindable, (double)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).VerticalSpacingPropertyChanged((WrapLayout)bindable, (double)oldValue, (double)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).VerticalSpacingPropertyChanging((WrapLayout)bindable, (double)oldValue, (double)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).VerticalSpacingCoerceValue((WrapLayout)bindable, (double)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).VerticalSpacingDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The spacing measure between controls on the Y axis.
        /// </summary>
        public double VerticalSpacing
        {
            get => (double)GetValue(VerticalSpacingProperty);
            set => SetValue(VerticalSpacingProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the VerticalSpacing value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool VerticalSpacingValidateValue(WrapLayout wrapLayout, double value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void VerticalSpacingPropertyChanged(WrapLayout wrapLayout, double oldValue, double newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void VerticalSpacingPropertyChanging(WrapLayout wrapLayout, double oldValue, double newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual double VerticalSpacingCoerceValue(WrapLayout wrapLayout, double value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual double VerticalSpacingDefaultValueCreator(WrapLayout wrapLayout) =>
            8d;

        #endregion

        #region EndParagraphContentAlignment

        /// <summary>
        /// The bindable property for the EndParagraphContentAlignment property.
        /// </summary>
        public static readonly BindableProperty EndParagraphContentAlignmentProperty = BindableProperty.Create(
            nameof(EndParagraphContentAlignment),
            typeof(LayoutAlignment),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).EndParagraphContentAlignmentValidateValue((WrapLayout)bindable, (LayoutAlignment)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).EndParagraphContentAlignmentPropertyChanged((WrapLayout)bindable, (LayoutAlignment)oldValue, (LayoutAlignment)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).EndParagraphContentAlignmentPropertyChanging((WrapLayout)bindable, (LayoutAlignment)oldValue, (LayoutAlignment)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).EndParagraphContentAlignmentCoerceValue((WrapLayout)bindable, (LayoutAlignment)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).EndParagraphContentAlignmentDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The layout alignment to apply to an end of paragraph dimension.
        /// </summary>
        public LayoutAlignment EndParagraphContentAlignment
        {
            get => (LayoutAlignment)GetValue(EndParagraphContentAlignmentProperty);
            set => SetValue(EndParagraphContentAlignmentProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the EndParagraphContentAlignment value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool EndParagraphContentAlignmentValidateValue(WrapLayout wrapLayout, LayoutAlignment value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void EndParagraphContentAlignmentPropertyChanged(WrapLayout wrapLayout, LayoutAlignment oldValue, LayoutAlignment newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void EndParagraphContentAlignmentPropertyChanging(WrapLayout wrapLayout, LayoutAlignment oldValue, LayoutAlignment newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual LayoutAlignment EndParagraphContentAlignmentCoerceValue(WrapLayout wrapLayout, LayoutAlignment value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual LayoutAlignment EndParagraphContentAlignmentDefaultValueCreator(WrapLayout wrapLayout) =>
            LayoutAlignment.Fill;

        #endregion

        #region StartIndex

        /// <summary>
        /// The bindable property for the StartIndex property.
        /// </summary>
        public static readonly BindableProperty StartIndexProperty = BindableProperty.Create(
            nameof(StartIndex),
            typeof(int),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).StartIndexValidateValue((WrapLayout)bindable, (int)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).StartIndexPropertyChanged((WrapLayout)bindable, (int)oldValue, (int)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).StartIndexPropertyChanging((WrapLayout)bindable, (int)oldValue, (int)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).StartIndexCoerceValue((WrapLayout)bindable, (int)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).StartIndexDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The start index of the first visible dimension.
        /// </summary>
        public int StartIndex
        {
            get => (int)GetValue(StartIndexProperty);
            set => SetValue(StartIndexProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the Orientation value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool StartIndexValidateValue(WrapLayout wrapLayout, int value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void StartIndexPropertyChanged(WrapLayout wrapLayout, int oldValue, int newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void StartIndexPropertyChanging(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual int StartIndexCoerceValue(WrapLayout wrapLayout, int value) =>
            value > 0 ? value : 0;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual int StartIndexDefaultValueCreator(WrapLayout wrapLayout) =>
            0;

        #endregion

        #region VisibleCount

        /// <summary>
        /// The bindable property for the VisibleCount property.
        /// </summary>
        public static readonly BindableProperty VisibleCountProperty = BindableProperty.Create(
            nameof(VisibleCount),
            typeof(int),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).VisibleCountValidateValue((WrapLayout)bindable, (int)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).VisibleCountPropertyChanged((WrapLayout)bindable, (int)oldValue, (int)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).VisibleCountPropertyChanging((WrapLayout)bindable, (int)oldValue, (int)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).VisibleCountCoerceValue((WrapLayout)bindable, (int)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).VisibleCountDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The count of dimensions that should be visible.
        /// </summary>
        public int VisibleCount
        {
            get => (int)GetValue(VisibleCountProperty);
            set => SetValue(VisibleCountProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the VisibleCount value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool VisibleCountValidateValue(WrapLayout wrapLayout, int value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void VisibleCountPropertyChanged(WrapLayout wrapLayout, int oldValue, int newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void VisibleCountPropertyChanging(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual int VisibleCountCoerceValue(WrapLayout wrapLayout, int value) =>
            value > 0 ? value : -1;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual int VisibleCountDefaultValueCreator(WrapLayout wrapLayout) =>
            -1;

        #endregion

        #region MaximumCount

        /// <summary>
        /// The bindable property for the MaximumCount property.
        /// </summary>
        public static readonly BindableProperty MaximumCountProperty = BindableProperty.Create(
            nameof(MaximumCount),
            typeof(int),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).MaximumCountValidateValue((WrapLayout)bindable, (int)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).MaximumCountPropertyChanged((WrapLayout)bindable, (int)oldValue, (int)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).MaximumCountPropertyChanging((WrapLayout)bindable, (int)oldValue, (int)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).MaximumCountCoerceValue((WrapLayout)bindable, (int)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).MaximumCountDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The maximum count of items that can appear in one dimension.
        /// </summary>
        public int MaximumCount
        {
            get => (int)GetValue(MaximumCountProperty);
            set => SetValue(MaximumCountProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the MaximumCount value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool MaximumCountValidateValue(WrapLayout wrapLayout, int value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void MaximumCountPropertyChanged(WrapLayout wrapLayout, int oldValue, int newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void MaximumCountPropertyChanging(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual int MaximumCountCoerceValue(WrapLayout wrapLayout, int value) =>
            value > 0 ? value : -1;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual int MaximumCountDefaultValueCreator(WrapLayout wrapLayout) =>
            -1;

        #endregion

        #region ActualAdjustment

        /// <summary>
        /// The bindable property for the ActualAdjustment property.
        /// </summary>
        public static readonly BindableProperty ActualAdjustmentProperty = BindableProperty.Create(
            nameof(ActualAdjustment),
            typeof(WrapActualAdjustment),
            typeof(WrapLayout),
            validateValue: (bindable, value) => ((WrapLayout)bindable).ActualAdjustmentValidateValue((WrapLayout)bindable, (WrapActualAdjustment)value),
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualAdjustmentPropertyChanged((WrapLayout)bindable, (WrapActualAdjustment)oldValue, (WrapActualAdjustment)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualAdjustmentPropertyChanging((WrapLayout)bindable, (WrapActualAdjustment)oldValue, (WrapActualAdjustment)newValue),
            coerceValue: (bindable, value) => ((WrapLayout)bindable).ActualAdjustmentCoerceValue((WrapLayout)bindable, (WrapActualAdjustment)value),
            defaultValueCreator: (bindable) => ((WrapLayout)bindable).ActualAdjustmentDefaultValueCreator((WrapLayout)bindable));

        /// <summary>
        /// The adjustment method to apply when calculating the actual get properties.
        /// </summary>
        public WrapActualAdjustment ActualAdjustment
        {
            get => (WrapActualAdjustment)GetValue(ActualAdjustmentProperty);
            set => SetValue(ActualAdjustmentProperty, value);
        }

        /// <summary>
        /// Overridable method to validate the ActualAdjustment value when set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout that this value will be validated for.</param>
        /// <param name="value">The requested value to be validated.</param>
        /// <returns>Returns true if a valid value is being set.</returns>
        protected virtual bool ActualAdjustmentValidateValue(WrapLayout wrapLayout, WrapActualAdjustment value) =>
            true;

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualAdjustmentPropertyChanged(WrapLayout wrapLayout, WrapActualAdjustment oldValue, WrapActualAdjustment newValue) =>
            wrapLayout.InvalidateLayout();

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualAdjustmentPropertyChanging(WrapLayout wrapLayout, WrapActualAdjustment oldValue, WrapActualAdjustment newValue)
        {
        }

        /// <summary>
        /// Coerces the value of the property that is being set.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is to be coerced.</param>
        /// <param name="value">The value of the property being set that is to be coerced.</param>
        /// <returns>Returns the coerced value of the property that is being set.</returns>
        protected virtual WrapActualAdjustment ActualAdjustmentCoerceValue(WrapLayout wrapLayout, WrapActualAdjustment value) =>
            value;

        /// <summary>
        /// Creates the default value for the bindable property.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose bindable property requires the default value.</param>
        /// <returns>Returns the default value for the bindable property.</returns>
        protected virtual WrapActualAdjustment ActualAdjustmentDefaultValueCreator(WrapLayout wrapLayout) =>
            WrapActualAdjustment.StartIndex;

        #endregion

        #region ActualStartIndex

        private static readonly BindablePropertyKey ActualStartIndexPropertyKey = BindableProperty.CreateReadOnly(
            nameof(ActualStartIndex),
            typeof(int),
            typeof(WrapLayout),
            0,
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualStartIndexPropertyChanged((WrapLayout)bindable, (int)oldValue, (int)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualStartIndexPropertyChanging((WrapLayout)bindable, (int)oldValue, (int)newValue));

        /// <summary>
        /// The bindable property for the ActualStartIndex get property.
        /// </summary>
        public static readonly BindableProperty ActualStartIndexProperty = ActualStartIndexPropertyKey.BindableProperty;

        /// <summary>
        /// Gets the index of the first dimension that is visible.
        /// </summary>
        public int ActualStartIndex
        {
            get => (int)GetValue(ActualStartIndexProperty);
            private set => SetValue(ActualStartIndexPropertyKey, value);
        }

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualStartIndexPropertyChanged(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualStartIndexPropertyChanging(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        #endregion

        #region ActualVisibleCount

        private static readonly BindablePropertyKey ActualVisibleCountPropertyKey = BindableProperty.CreateReadOnly(
            nameof(ActualVisibleCount),
            typeof(int),
            typeof(WrapLayout),
            0,
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualVisibleCountPropertyChanged((WrapLayout)bindable, (int)oldValue, (int)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualVisibleCountPropertyChanging((WrapLayout)bindable, (int)oldValue, (int)newValue));

        /// <summary>
        /// The bindable property for the ActualVisibleCount get property.
        /// </summary>
        public static readonly BindableProperty ActualVisibleCountProperty = ActualVisibleCountPropertyKey.BindableProperty;

        /// <summary>
        /// Gets the count of dimensions that are visible.
        /// </summary>
        public int ActualVisibleCount
        {
            get => (int)GetValue(ActualVisibleCountProperty);
            private set => SetValue(ActualVisibleCountPropertyKey, value);
        }

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualVisibleCountPropertyChanged(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualVisibleCountPropertyChanging(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        #endregion

        #region ActualCount

        private static readonly BindablePropertyKey ActualCountPropertyKey = BindableProperty.CreateReadOnly(
            nameof(ActualCount),
            typeof(int),
            typeof(WrapLayout),
            0,
            propertyChanged: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualCountPropertyChanged((WrapLayout)bindable, (int)oldValue, (int)newValue),
            propertyChanging: (bindable, oldValue, newValue) => ((WrapLayout)bindable).ActualCountPropertyChanging((WrapLayout)bindable, (int)oldValue, (int)newValue));

        /// <summary>
        /// The bindable property for the ActualCount get property.
        /// </summary>
        public static readonly BindableProperty ActualCountProperty = ActualCountPropertyKey.BindableProperty;

        /// <summary>
        /// Gets the total count of dimensions whether they are visible or not.
        /// </summary>
        public int ActualCount
        {
            get => (int)GetValue(ActualCountProperty);
            private set => SetValue(ActualCountPropertyKey, value);
        }

        /// <summary>
        /// Occurs when the value of the property has changed.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value has changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualCountPropertyChanged(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        /// <summary>
        /// Occurs when the value of the property is going to change.
        /// </summary>
        /// <param name="wrapLayout">The WrapLayout whose property value is going to change.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected virtual void ActualCountPropertyChanging(WrapLayout wrapLayout, int oldValue, int newValue)
        {
        }

        #endregion

        #region Attached-SpacingOverride

        //Note: There is no override for DefaultValueCreator as is static and bindable is childItem and childItem.Parent is null at creation

        /// <summary>
        /// The bindable property for the SpacingOverride attached property.
        /// </summary>
        public static readonly BindableProperty SpacingOverrideProperty = BindableProperty.CreateAttached(
            nameof(WrapExtension.SpacingOverride),
            typeof(double),
            typeof(WrapLayout),
            0d);

        /// <summary>
        /// Gets the value of the SpacingOverride attached property for the specified child view if set otherwise the default value.
        /// </summary>
        /// <param name="bindable">The WrapLayout child view for which the attached property is being requested.</param>
        /// <returns>Returns the value of the SpacingOverride attached property for the specified child view if set otherwise the default value.</returns>
        public static double GetSpacingOverride(BindableObject bindable) =>
            (double)bindable.GetValue(SpacingOverrideProperty);

        /// <summary>
        /// Sets the value of the SpacingOverride attached property for the specified child view.
        /// </summary>
        /// <param name="bindable">The WrapLayout child view for which the attached property is being set.</param>
        /// <param name="value">The value to set for the SpacingOverride attached property.</param>
        public static void SetSpacingOverride(BindableObject bindable, double value) =>
            bindable.SetValue(SpacingOverrideProperty, value);

        #endregion

        #region Attached-ForceNewDimension

        //Note: There is no override for DefaultValueCreator as is static and bindable is childItem and childItem.Parent is null at creation

        /// <summary>
        /// The bindable property for the ForceNewDimension attached property.
        /// </summary>
        public static readonly BindableProperty ForceNewDimensionProperty = BindableProperty.CreateAttached(
            nameof(WrapExtension.ForceNewDimension),
            typeof(bool),
            typeof(WrapLayout),
            true);

        /// <summary>
        /// Gets the value of the ForceNewDimension attached property for the specified child view if set otherwise the default value.
        /// </summary>
        /// <param name="bindable">The WrapLayout child view for which the attached property is being requested.</param>
        /// <returns>Returns the value of the ForceNewDimension attached property if set otherwise returns the default value.</returns>
        public static bool GetForceNewDimension(BindableObject bindable) =>
            (bool)bindable.GetValue(ForceNewDimensionProperty);

        /// <summary>
        /// Sets the value of the ForceNewDimension attached property for the specified child view.
        /// </summary>
        /// <param name="bindable">The WrapLayout child view for which the attached property is being set.</param>
        /// <param name="value">The value to set for the ForceNewDimension attached property.</param>
        public static void SetForceNewDimension(BindableObject bindable, bool value) =>
            bindable.SetValue(ForceNewDimensionProperty, value);

        #endregion

        #region ItemPropertyChanged

        /// <inheritdoc />
        protected override void OnAdded(View view)
        {
            base.OnAdded(view);

            //HACK: Required for disabling unwanted views
            IsEnabledDictionary.Add(view.Id, view.IsEnabled);

            view.PropertyChanged += OnItemPropertyChanged;
        }

        /// <inheritdoc />
        protected override void OnRemoved(View view)
        {
            base.OnRemoved(view);

            //HACK: Required for disabling unwanted views
            IsEnabledDictionary.Remove(view.Id);

            view.PropertyChanged -= OnItemPropertyChanged;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsEnabled):
                    {
                        //HACK: Required for disabling unwanted views
                        if (!LayoutRunning)
                        {
                            if (sender is View view)
                            {
                                //Note: Change IsEnabled state collection for view

                                IsEnabledDictionary[view.Id] = view.IsEnabled;

                                //TODO: not required? was required for IsVisible
                                //InvalidateLayout();
                            }
                        }
                        break;
                    }
                case nameof(WrapExtension.SpacingOverride):
                case nameof(WrapExtension.ForceNewDimension):
                    {
                        //Note: Attached property changed

                        InvalidateLayout();
                        break;
                    }
            }
        }

        #endregion

        #region Calculate Layout

        /// <summary>
        /// Calculates the WrapContent for the specified width and height.
        /// </summary>
        /// <param name="width">The width to use when calculating the layout.</param>
        /// <param name="height">The height to use when calculating the layout.</param>
        /// <param name="buildContent">Specifies whether to build and return the content objects which are only required for layout.</param>
        /// <returns>Returns the calculated WrapContent for the specified width and height.</returns>
        protected virtual WrapContent CalculateContent(double width, double height, bool buildContent = false)
        {
            //Note: Initialise content property values

            double contentFitMeasure = 0d;
            double contentFlowMeasure = 0d;
            double contentFitMinimumMeasure = 0d;
            double contentFlowMinimumMeasure = 0d;
            int contentFlowExpandCount = 0;

            //TODO: is this used?
            double contentFlowExpandMeasure = 0d;
            double contentFlowFillMeasure = 0d;

            //Note: Initialise control get property values

            int actualStartIndex = 0;
            int actualCount = 0;
            int actualVisibleCount;
            IList<WrapDimension> actualDimensions = buildContent ? new List<WrapDimension>() : null;

            //Note: Initialise Control/Content Fit/Flow

            double controlFitMeasure;
            double controlFlowMeasure;
            bool contentIsHorizontal = Orientation == LayoutOrientation.Horizontal;
            LayoutAlignment contentFitContentAlignment;
            LayoutAlignment contentFlowContentAlignment;
            bool contentFitOrientationReverse;
            bool contentFlowOrientationReverse;
            double contentFitSpacing;
            double contentFlowSpacing;

            IList<WrapDimension> dimensions = new List<WrapDimension>();

            //Note: Assign Control/Content Fit/Flow

            if (contentIsHorizontal)
            {
                controlFitMeasure = width;
                controlFlowMeasure = height;
                contentFitContentAlignment = HorizontalContentAlignment;
                contentFlowContentAlignment = VerticalContentAlignment;
                contentFitOrientationReverse = OrientationReverse == LayoutOrientationReverse.Horizontal || OrientationReverse == LayoutOrientationReverse.Both;
                contentFlowOrientationReverse = OrientationReverse == LayoutOrientationReverse.Vertical || OrientationReverse == LayoutOrientationReverse.Both;
                contentFitSpacing = HorizontalSpacing;
                contentFlowSpacing = VerticalSpacing;
            }
            else
            {
                controlFitMeasure = height;
                controlFlowMeasure = width;
                contentFitContentAlignment = VerticalContentAlignment;
                contentFlowContentAlignment = HorizontalContentAlignment;
                contentFitOrientationReverse = OrientationReverse == LayoutOrientationReverse.Vertical || OrientationReverse == LayoutOrientationReverse.Both;
                contentFlowOrientationReverse = OrientationReverse == LayoutOrientationReverse.Horizontal || OrientationReverse == LayoutOrientationReverse.Both;
                contentFitSpacing = VerticalSpacing;
                contentFlowSpacing = HorizontalSpacing;
            }

            //Note: Check for visible views

            View[] itemViews = Children.Where(predicateView => predicateView.IsVisible).ToArray();

            if (itemViews.Length > 0)
            {
                //Note: Initialise current Dimension Fit/Flow

                IList<WrapItem> currentDimensionItems = null;
                double currentDimensionFitMeasure = 0;
                double currentDimensionFlowMeasure = 0;
                bool currentDimensionFlowExpands = false;
                int currentDimensionFitExpandCount = 0;
                double currentDimensionFitExpandMeasure = 0;
                double currentDimensionFitFillMeasure = 0;

                //Note: Iterate child views

                int currentDimensionIndex = 0;
                int currentDimensionItemIndex = 0;
                foreach (View itemView in itemViews)
                {
                    //Note: Always measure item against full control width/height as item might be on new dimension
                    //also wrapping controls like Label will vary measurement based on given width/height

                    SizeRequest itemSize;
                    if (contentIsHorizontal)
                    {
                        itemSize = itemView.Measure(controlFitMeasure, controlFlowMeasure);
                    }
                    else
                    {
                        itemSize = itemView.Measure(controlFlowMeasure, controlFitMeasure);
                    }

                    double itemHeight = itemSize.Request.Height;
                    double itemWidth = itemSize.Request.Width;

                    //Note: Assign Item Fit/Flow

                    double itemFitMeasure;
                    double itemFitMinimumMeasure;
                    double itemFitMaximumMeasure;
                    double itemFlowMeasure;
                    double itemFlowMinimumMeasure;
                    double itemFlowMaximumMeasure;
                    LayoutOptions itemFitLayoutOptions;
                    LayoutOptions itemFlowLayoutOptions;
                    if (contentIsHorizontal)
                    {
                        itemFitMeasure = itemWidth;
                        itemFitMinimumMeasure = itemView.MinimumWidthRequest;
                        itemFitMaximumMeasure = itemView.WidthRequest;
                        itemFlowMeasure = itemHeight;
                        itemFlowMinimumMeasure = itemView.MinimumHeightRequest;
                        itemFlowMaximumMeasure = itemView.HeightRequest;
                        itemFitLayoutOptions = itemView.HorizontalOptions;
                        itemFlowLayoutOptions = itemView.VerticalOptions;
                    }
                    else
                    {
                        itemFitMeasure = itemHeight;
                        itemFitMinimumMeasure = itemView.MinimumHeightRequest;
                        itemFitMaximumMeasure = itemView.HeightRequest;
                        itemFlowMeasure = itemWidth;
                        itemFlowMinimumMeasure = itemView.MinimumWidthRequest;
                        itemFlowMaximumMeasure = itemView.WidthRequest;
                        itemFitLayoutOptions = itemView.VerticalOptions;
                        itemFlowLayoutOptions = itemView.HorizontalOptions;
                    }

                    //Note: Check if Item has a SpacingOverride if applicable

                    double itemFitSpacing;
                    if (itemView.IsSet(SpacingOverrideProperty))
                    {
                        itemFitSpacing = GetSpacingOverride(itemView);
                    }
                    else
                    {
                        itemFitSpacing = contentFitSpacing;
                    }

                    //Note: Check if a new Dimension has been forced

                    bool forceNewDimension;
                    if (itemView.IsSet(ForceNewDimensionProperty))
                    {
                        forceNewDimension = GetForceNewDimension(itemView);
                    }
                    else
                    {
                        forceNewDimension = false;
                    }

                    //Note: Check if a new Dimension is required

                    bool newDimensionRequired;
                    double newDimensionFitMeasure = 0;
                    if (forceNewDimension ||
                        (currentDimensionIndex == 0 && currentDimensionItemIndex == 0) ||
                        (MaximumCount > 0 && MaximumCount == currentDimensionItemIndex))
                    {
                        //Note: If forceNewDimension or first Item in first Dimension or MaximumCount is reached then new Dimension is required

                        newDimensionRequired = true;
                        newDimensionFitMeasure = itemFitMeasure;
                    }
                    else
                    {
                        //Note: Check if there is enough room for Item otherwise create a new Dimension

                        double testDimensionFitMeasure = currentDimensionFitMeasure + itemFitSpacing + itemFitMeasure;
                        if (testDimensionFitMeasure > controlFitMeasure)
                        {
                            //Note: itemFitMeasure may still be greater than controlFitMeasure but we always allow first item

                            newDimensionRequired = true;
                            newDimensionFitMeasure = itemFitMeasure;
                        }
                        else
                        {
                            newDimensionRequired = false;
                            newDimensionFitMeasure = testDimensionFitMeasure;
                        }
                    }

                    if (newDimensionRequired)
                    {
                        //Note: Check if this is not the first Item in the first Dimension

                        if (!(currentDimensionIndex == 0 && currentDimensionItemIndex == 0))
                        {
                            //Note: Add current Dimension - EndParagraph is determined by if ForceNewDimension was set

                            WrapDimension dimension = new WrapDimension(currentDimensionItems, currentDimensionFitMeasure, currentDimensionFlowMeasure, currentDimensionFlowExpands, currentDimensionFitExpandCount, currentDimensionFitExpandMeasure, currentDimensionFitFillMeasure, forceNewDimension);
                            dimensions.Add(dimension);

                            currentDimensionIndex++;
                        }

                        //Note: Reset current Dimension Items

                        currentDimensionItems = new List<WrapItem>();
                        currentDimensionItemIndex = 0;

                        //Note: Reset current Dimension Fit/Flow

                        currentDimensionFitMeasure = 0;
                        currentDimensionFitExpandCount = 0;

                        //TODO: is this used?
                        currentDimensionFitExpandMeasure = 0;
                        currentDimensionFitFillMeasure = 0;

                        currentDimensionFlowMeasure = 0;
                        currentDimensionFlowExpands = false;
                    }

                    //Note: Set current Dimension Fit/Flow

                    currentDimensionFitMeasure = newDimensionFitMeasure;
                    currentDimensionFitExpandMeasure += itemFitSpacing;
                    if (itemFitLayoutOptions.Expands)
                    {
                        currentDimensionFitExpandCount += 1;
                    }
                    else
                    {
                        //TODO: is this used?
                        currentDimensionFitExpandMeasure += itemFitMeasure;
                    }
                    currentDimensionFitFillMeasure += itemFitMeasure;

                    currentDimensionFlowMeasure = Math.Max(currentDimensionFlowMeasure, itemFlowMeasure);
                    if (itemFlowLayoutOptions.Expands)
                    {
                        currentDimensionFlowExpands = true;
                    }

                    //Note: Add current Item

                    WrapItem item = new WrapItem(itemView, itemFitMeasure, itemFitMinimumMeasure, itemFitMaximumMeasure, itemFlowMeasure, itemFlowMinimumMeasure, itemFlowMaximumMeasure, itemFitLayoutOptions, itemFlowLayoutOptions, itemFitSpacing);
                    currentDimensionItems.Add(item);

                    currentDimensionItemIndex++;
                }

                //Note: Add last Dimension - EndParagraph is True

                WrapDimension lastItemDimension = new WrapDimension(currentDimensionItems, currentDimensionFitMeasure, currentDimensionFlowMeasure, currentDimensionFlowExpands, currentDimensionFitExpandCount, currentDimensionFitExpandMeasure, currentDimensionFitFillMeasure, true);
                dimensions.Add(lastItemDimension);

                //Note: Set the Content get properties considering ActualAdjustment

                actualCount = dimensions.Count;
                switch (ActualAdjustment)
                {
                    case WrapActualAdjustment.StartIndex:
                        {
                            if (StartIndex >= actualCount)
                            {
                                actualStartIndex = actualCount - 1;
                                actualVisibleCount = 1;
                            }
                            else
                            {
                                actualStartIndex = StartIndex;
                                if (VisibleCount > 0)
                                {
                                    if (actualCount < actualStartIndex + VisibleCount)
                                    {
                                        actualVisibleCount = actualCount - actualStartIndex;
                                    }
                                    else
                                    {
                                        actualVisibleCount = VisibleCount;
                                    }
                                }
                                else
                                {
                                    actualVisibleCount = actualCount - actualStartIndex;
                                }
                            }
                            break;
                        }
                    case WrapActualAdjustment.VisibleCount:
                        {
                            if (VisibleCount > 0)
                            {
                                if (actualCount < VisibleCount)
                                {
                                    actualVisibleCount = actualCount;
                                    actualStartIndex = 0;
                                }
                                else
                                {
                                    actualVisibleCount = VisibleCount;
                                    if (actualCount < StartIndex + actualVisibleCount)
                                    {
                                        actualStartIndex = actualCount - actualVisibleCount;
                                    }
                                    else
                                    {
                                        actualStartIndex = StartIndex;
                                    }
                                }
                            }
                            else
                            {
                                if (StartIndex >= actualCount)
                                {
                                    actualStartIndex = actualCount - 1;
                                    actualVisibleCount = 1;
                                }
                                else
                                {
                                    actualStartIndex = StartIndex;
                                    actualVisibleCount = actualCount - actualStartIndex;
                                }
                            }
                            break;
                        }
                    case WrapActualAdjustment.None:
                    default:
                        {
                            actualStartIndex = StartIndex;
                            if (VisibleCount > 0)
                            {
                                if (actualCount < actualStartIndex + VisibleCount)
                                {
                                    actualVisibleCount = Math.Max(actualCount - actualStartIndex, 0);
                                }
                                else
                                {
                                    actualVisibleCount = VisibleCount;
                                }
                            }
                            else
                            {
                                actualVisibleCount = Math.Max(actualCount - actualStartIndex, 0);
                            }
                            break;
                        }
                }

                //Note: Build WrapContent

                int dimensionIndex = 0;
                int actualDimensionIndex = 0;
                foreach (WrapDimension dimension in dimensions)
                {
                    //Note: Check if Dimension is included considering actualStartIndex and actualVisibleCount

                    bool includeDimension = false;
                    if (dimensionIndex >= actualStartIndex)
                    {
                        if (dimensionIndex < actualStartIndex + actualVisibleCount)
                        {
                            includeDimension = true;
                        }
                    }

                    if (includeDimension)
                    {
                        int itemIndex = 0;
                        foreach (WrapItem item in dimension.Items)
                        {
                            //Note: Set Content Fit/Flow Minimum

                            if (actualDimensionIndex == 0)
                            {
                                //Note: Visible item on first included Dimension Flow Axis

                                contentFlowMinimumMeasure = Math.Max(contentFlowMinimumMeasure, item.FlowMeasure);
                            }
                            if (itemIndex == 0)
                            {
                                //Note: First visible item on an included Dimension Fit Axis

                                contentFitMinimumMeasure = Math.Max(contentFitMinimumMeasure, item.FitMeasure);
                            }

                            itemIndex++;
                        }

                        //Note: Set Content Fit/Flow

                        if (actualDimensionIndex == 0)
                        {
                            contentFlowMeasure = dimension.FlowMeasure;
                        }
                        else
                        {
                            contentFlowMeasure += contentFlowSpacing + dimension.FlowMeasure;
                            contentFlowExpandMeasure += contentFlowSpacing;
                        }
                        if (dimension.FlowExpands)
                        {
                            contentFlowExpandCount += 1;
                        }
                        else
                        {
                            contentFlowExpandMeasure += dimension.FlowMeasure;
                        }
                        contentFlowFillMeasure += dimension.FlowMeasure;

                        //Note: Add current dimension if building content

                        if (buildContent) actualDimensions.Add(dimension);

                        actualDimensionIndex++;
                    }

                    //Note: dimension.FitMeasure is always included in calculation whether dimension is included or not

                    contentFitMeasure = Math.Max(dimension.FitMeasure, contentFitMeasure);

                    dimensionIndex++;
                }
            }

            WrapContent content = new WrapContent(actualDimensions, actualCount, actualStartIndex, contentFitContentAlignment, contentFlowContentAlignment, contentFitOrientationReverse, contentFlowOrientationReverse, contentFitMeasure, contentFlowMeasure, contentFitMinimumMeasure, contentFlowMinimumMeasure, contentFlowExpandCount, contentFlowExpandMeasure, contentFlowFillMeasure, contentFlowSpacing);

            return content;
        }

        /// <summary>
        /// Calculates the layout point on the fit axis for the specified dimension.
        /// </summary>
        /// <param name="controlFitPoint">The fit point of the control.</param>
        /// <param name="controlFitMeasure">The fit measure of the control.</param>
        /// <param name="dimensionFitMeasure">The fit measure of the dimension.</param>
        /// <param name="currentDimensionFitMeasure">The current fit measure of the items.</param>
        /// <param name="dimensionFitExpandCount">The fit expand count of the dimension.</param>
        /// <param name="itemFitMeasure">The fit measure of the dimension.</param>
        /// <param name="itemFitExpands">Specifies if the fit axis of this item expands.</param>
        /// <param name="fitSpacing">The fit spacing measure of the control.</param>
        /// <param name="fitFillSpacing">The fit fill spacing measure of the dimensions.</param>
        /// <param name="index">The index of the specified dimension.</param>
        /// <param name="count">The total count of dimensions.</param>
        /// <param name="fitContentAlignment">The fit alignment of the control.</param>
        /// <param name="endParagraphContentAlignment">The end of paragraph alignment of the control.</param>
        /// <param name="endParagraph">Specifies if this dimension is an end of paragraph dimension.</param>
        /// <returns>Returns the calculated layout point on the fit axis for the specified dimension.</returns>
        protected virtual LayoutAxis CalculateLayoutDimensionFitAxis(double controlFitPoint, double controlFitMeasure, double dimensionFitMeasure, double currentDimensionFitMeasure, int dimensionFitExpandCount, double itemFitMeasure, bool itemFitExpands, double fitSpacing, double fitFillSpacing, int index, int count, LayoutAlignment fitContentAlignment, LayoutAlignment endParagraphContentAlignment, bool endParagraph)
        {
            return LayoutExtension.CalculateLayoutDimensionAxis(controlFitPoint, controlFitMeasure, dimensionFitMeasure, currentDimensionFitMeasure, dimensionFitExpandCount, itemFitMeasure, itemFitExpands, fitSpacing, fitFillSpacing, index, count, fitContentAlignment, endParagraphContentAlignment, endParagraph);
        }

        /// <summary>
        /// Calculates the layout point on the flow axis for the specified dimension.
        /// </summary>
        /// <param name="controlFlowPoint">The flow point of the control.</param>
        /// <param name="controlFlowMeasure">The flow measure of the control.</param>
        /// <param name="contentFlowMeasure">The flow measure of the content.</param>
        /// <param name="currentContentFlowMeasure">The current flow measure of the dimensions.</param>
        /// <param name="contentFlowExpandCount">The flow expand measure of the dimension.</param>
        /// <param name="dimensionFlowMeasure">The flow measure of the dimension.</param>
        /// <param name="dimensionFlowExpands">Specifies if any child view on the flow axis of this dimension expands.</param>
        /// <param name="flowSpacing">The flow spacing measure of the control.</param>
        /// <param name="flowFillSpacing">The flow fill spacing measure of the dimensions.</param>
        /// <param name="index">The index of the specified dimension.</param>
        /// <param name="count">The total count of dimensions.</param>
        /// <param name="flowContentAlignment">The flow alignment of the control.</param>
        /// <returns>Returns the calculated layout point on the flow axis for the specified dimension.</returns>
        protected virtual LayoutAxis CalculateLayoutDimensionFlowAxis(double controlFlowPoint, double controlFlowMeasure, double contentFlowMeasure, double currentContentFlowMeasure, int contentFlowExpandCount, double dimensionFlowMeasure, bool dimensionFlowExpands, double flowSpacing, double flowFillSpacing, int index, int count, LayoutAlignment flowContentAlignment)
        {
            //Note: EndParagraph is not applicable for dimension flow axis in WrapLayout

            return LayoutExtension.CalculateLayoutDimensionAxis(controlFlowPoint, controlFlowMeasure, contentFlowMeasure, currentContentFlowMeasure, contentFlowExpandCount, dimensionFlowMeasure, dimensionFlowExpands, flowSpacing, flowFillSpacing, index, count, flowContentAlignment, LayoutAlignment.Fill, false);
        }

        /// <summary>
        /// Calculates the layout point on the fit axis for the specified item.
        /// </summary>
        /// <param name="contentFitPoint">The fit point of the content.</param>
        /// <param name="contentFitMeasure">The fit measure of the content.</param>
        /// <param name="itemFitAlignment">The fit alignment of the item.</param>
        /// <param name="itemFitMeasure">The fit measure of the item.</param>
        /// <returns>Returns the calculated layout point on the fit axis for the specified item.</returns>
        protected virtual LayoutAxis CalculateLayoutItemFitAxis(double contentFitPoint, double contentFitExpandMeasure, double contentFitMeasure, LayoutOptions itemFitLayoutOptions, double itemFitMeasure, double itemMinimumFitMeasure, double itemMaximumFitMeasure)
        {
            //Note: Padding is not applicable for item fit axis in WrapLayout

            return LayoutExtension.CalculateLayoutItemAxis(contentFitPoint, contentFitExpandMeasure, contentFitMeasure, 0d, 0d, itemFitLayoutOptions, itemFitMeasure, itemMinimumFitMeasure, itemMaximumFitMeasure);
        }

        /// <summary>
        /// Calculates the layout point on the flow axis for the specified item.
        /// </summary>
        /// <param name="contentFlowPoint">The flow point of the content.</param>
        /// <param name="contentFlowMeasure">The flow measure of the content.</param>
        /// <param name="itemFlowAlignment">The flow alignment of the item.</param>
        /// <param name="itemFlowMeasure">The flow measure of the item.</param>
        /// <returns>Returns the calculated layout point on the flow axis for the specified item.</returns>
        protected virtual LayoutAxis CalculateLayoutItemFlowAxis(double contentFlowPoint, double contentFlowExpandMeasure, double contentFlowMeasure, LayoutOptions itemFlowLayoutOptions, double itemFlowMeasure, double itemMinimumFlowMeasure, double itemMaximumFlowMeasure)
        {
            //Note: Padding is not applicable for item flow axis in WrapLayout

            return LayoutExtension.CalculateLayoutItemAxis(contentFlowPoint, contentFlowExpandMeasure, contentFlowMeasure, 0d, 0d, itemFlowLayoutOptions, itemFlowMeasure, itemMinimumFlowMeasure, itemMaximumFlowMeasure);
        }

        #endregion

        #region Perform Layout

        /// <inheritdoc />
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            double internalWidth = double.IsPositiveInfinity(widthConstraint) ? double.PositiveInfinity : Math.Max(0, widthConstraint);
            double internalHeight = double.IsPositiveInfinity(heightConstraint) ? double.PositiveInfinity : Math.Max(0, heightConstraint);

            //Note: Calculate the WrapContent based on the specified width and height

            WrapContent content = CalculateContent(internalWidth, internalHeight);

            SizeRequest sizeRequest = Orientation.CalculateLayoutSizeRequest(content.FitMeasure, content.FlowMeasure, content.FitMinimumMeasure, content.FlowMinimumMeasure);

            return sizeRequest;
        }

        //HACK: Required for disabling unwanted views
        private readonly IDictionary<Guid, bool> IsEnabledDictionary = new Dictionary<Guid, bool>();
        private bool LayoutRunning = false;

        /// <inheritdoc />
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            LayoutRunning = true;
            try
            {
                //HACK: Required for disabling unwanted views
                foreach (View view in Children.Where(predicateView => predicateView.Width > 0 && predicateView.Height > 0))
                {
                    //Note: Disable view and move offscreen

                    view.IsEnabled = false;
                    view.Layout(new Rectangle(-100000d, -100000d, -1d, -1d));
                }

                //Note: Calculate the WrapContent based on the specified width and height

                WrapContent content = CalculateContent(width, height, true);

                int dimensionCount = content.Dimensions.Count;
                if (dimensionCount > 0)
                {
                    //Note: Calculate the LayoutRectangle based on the specified rectangle coordinates

                    LayoutRectangle controlRectangle = Orientation.CalculateLayoutRectangle(x, y, width, height);

                    //Note: Calculate the Flow fill spacing and Flow expand spacing for the current dimension

                    double dimensionFlowFillSpacing = (controlRectangle.FlowMeasure - content.FlowFillMeasure) / (dimensionCount - 1);
                    double dimensionFlowExpandMeasure = (controlRectangle.FlowMeasure - content.FlowExpandMeasure) / content.FlowExpandCount;

                    //Note: Reverse the order of the dimensions based on the flow orientation if applicable

                    IEnumerable<WrapDimension> dimensions;
                    if (content.FlowOrientationReverse)
                    {
                        dimensions = content.Dimensions.Reverse();
                    }
                    else
                    {
                        dimensions = content.Dimensions;
                    }

                    //Note: Iterate the calculated dimensions

                    double currentDimensionFlowMeasure = 0;
                    int dimensionIndex = 0;
                    foreach (WrapDimension dimension in dimensions)
                    {
                        int itemCount = dimension.Items.Count;

                        //Note: Calculate the Fit fill spacing and Fit expand spacing for the current item

                        double dimensionFitFillSpacing = (controlRectangle.FitMeasure - dimension.FitFillMeasure) / (itemCount - 1);
                        double dimensionFitExpandMeasure = (controlRectangle.FitMeasure - dimension.FitExpandMeasure) / dimension.FitExpandCount;

                        bool lastDimension = dimensionCount == (dimensionIndex + 1);

                        //Note: Calculate the LayoutAxis for the current dimension on the flow axis

                        LayoutAxis dimensionFlowAxis = CalculateLayoutDimensionFlowAxis(controlRectangle.FlowPoint, controlRectangle.FlowMeasure, content.FlowMeasure, currentDimensionFlowMeasure, content.FlowExpandCount, dimension.FlowMeasure, dimension.FlowExpands, content.FlowSpacing, dimensionFlowFillSpacing, dimensionIndex, dimensionCount, content.FlowContentAlignment);

                        //Note: Calculate the current Flow measure for the current dimension

                        currentDimensionFlowMeasure = dimensionFlowAxis.Point + dimensionFlowAxis.Measure;

                        //Note: Reverse the order of the items based on the fit orientation if applicable

                        IEnumerable<WrapItem> items;
                        if (content.FitOrientationReverse)
                        {
                            items = dimension.Items.Reverse();
                        }
                        else
                        {
                            items = dimension.Items;
                        }

                        //Note: Iterate the calculated items for the current dimension

                        double currentDimensionFitMeasure = 0;
                        int itemIndex = 0;
                        foreach (WrapItem item in items)
                        {
                            //HACK: Required for disabling unwanted views
                            item.View.IsEnabled = IsEnabledDictionary[item.View.Id];

                            //Note: Calculate the LayoutAxis for the current dimension on the fit axis

                            LayoutAxis dimensionFitAxis = CalculateLayoutDimensionFitAxis(controlRectangle.FitPoint, controlRectangle.FitMeasure, dimension.FitMeasure, currentDimensionFitMeasure, dimension.FitExpandCount, item.FitMeasure, item.FitLayoutOptions.Expands, item.FitSpacing, dimensionFitFillSpacing, itemIndex, itemCount, content.FitContentAlignment, EndParagraphContentAlignment, dimension.EndParagraph);

                            //Note: Calculate the current Fit measure for the current dimension

                            currentDimensionFitMeasure = dimensionFitAxis.Point + dimensionFitAxis.Measure;

                            //Note: Calculate the LayoutAxis for the current item on the fit axis and flow axis

                            LayoutAxis itemFitAxis = CalculateLayoutItemFitAxis(dimensionFitAxis.Point, dimensionFitAxis.Measure, item.FitMeasure, item.FitLayoutOptions, item.FitMeasure, item.FitMinimumMeasure, item.FitMaximumMeasure);
                            LayoutAxis itemFlowAxis = CalculateLayoutItemFlowAxis(dimensionFlowAxis.Point, dimensionFlowAxis.Measure, dimension.FlowMeasure, item.FlowLayoutOptions, item.FlowMeasure, item.FlowMinimumMeasure, item.FlowMaximumMeasure);

                            //Note: Calculate the Rectangle based on the specified LayoutAxis coordinates

                            Rectangle itemRectangle = Orientation.CalculateLayoutNativeRectangle(itemFitAxis, itemFlowAxis);

                            //Note: Layout the current child view in this content

                            LayoutChildIntoBoundingRegion(item.View, itemRectangle);

                            itemIndex++;
                        }

                        dimensionIndex++;
                    }
                }

                //Note: Set the public get properties to cause OnPropertyChanged

                ActualStartIndex = content.ActualStartIndex;
                ActualVisibleCount = dimensionCount;
                ActualCount = content.ActualCount;
            }
            finally
            {
                LayoutRunning = false;
            }
        }

        #endregion

        #region Internal

        /// <summary>
        /// Represents a child view of the control and its layout configuration.
        /// </summary>
        protected class WrapItem
        {
            /// <summary>
            /// Constructs a WrapItem representing a child view and its configuration.
            /// </summary>
            /// <param name="view">The child view represented by this WrapItem.</param>
            /// <param name="fitMeasure">The Width (when Orientation is Horizontal) or Height (when Orientation is Vertical) measure of this child view.</param>
            /// <param name="flowMeasure">The Height (when Orientation is Horizontal) or Width (when Orientation is Vertical) measure of this child view.</param>
            /// <param name="fitLayoutOptions">The HorizontalLayoutOptions (when Orientation is Horizontal) or VerticalLayoutOptions (when Orientation is Vertical) of this child view.</param>
            /// <param name="flowLayoutOptions">The VerticalLayoutOptions (when Orientation is Horizontal) or HorizontalLayoutOptions (when Orientation is Vertical) of this child view.</param>
            /// <param name="fitSpacing">The HorizontalSpacing (when Orientation is Horizontal) or VerticalSpacing (when Orientation is Vertical) measure of this child view.</param>
            public WrapItem(View view, double fitMeasure, double fitMinimumMeasure, double fitMaximumMeasure, double flowMeasure, double flowMinimumMeasure, double flowMaximumMeasure, LayoutOptions fitLayoutOptions, LayoutOptions flowLayoutOptions, double fitSpacing)
            {
                View = view;
                FitMeasure = fitMeasure;
                FitMinimumMeasure = fitMinimumMeasure;
                FitMaximumMeasure = fitMaximumMeasure;
                FlowMeasure = flowMeasure;
                FlowMinimumMeasure = flowMinimumMeasure;
                FlowMaximumMeasure = flowMaximumMeasure;
                FitLayoutOptions = fitLayoutOptions;
                FlowLayoutOptions = flowLayoutOptions;
                FitSpacing = fitSpacing;
            }

            /// <summary>
            /// Gets the child view represented by this WrapItem.
            /// </summary>
            public View View { get; }

            /// <summary>
            /// Gets the Width (when Orientation is Horizontal) or Height (when Orientation is Vertical) measure of this child view.
            /// </summary>
            public double FitMeasure { get; }

            //TODO: Comments

            public double FitMinimumMeasure { get; }

            //TODO: Comments

            public double FitMaximumMeasure { get; }

            /// <summary>
            /// Gets the Height (when Orientation is Horizontal) or Width (when Orientation is Vertical) measure of this child view.
            /// </summary>
            public double FlowMeasure { get; }

            //TODO: Comments

            public double FlowMinimumMeasure { get; }

            //TODO: Comments

            public double FlowMaximumMeasure { get; }

            /// <summary>
            /// Gets the HorizontalLayoutOptions (when Orientation is Horizontal) or VerticalLayoutOptions (when Orientation is Vertical) of this child view.
            /// </summary>
            public LayoutOptions FitLayoutOptions { get; }

            /// <summary>
            /// Gets the VerticalLayoutOptions (when Orientation is Horizontal) or HorizontalLayoutOptions (when Orientation is Vertical) of this child view.
            /// </summary>
            public LayoutOptions FlowLayoutOptions { get; }

            /// <summary>
            /// Gets the HorizontalSpacing (when Orientation is Horizontal) or VerticalSpacing (when Orientation is Vertical) measure of this child view.
            /// </summary>
            public double FitSpacing { get; }
        }

        /// <summary>
        /// Represents a Row (when Orientation is Horizontal) or Column (when Orientation is Vertical) of the control and its layout configuration.
        /// </summary>
        protected class WrapDimension
        {
            /// <summary>
            /// Constructs a WrapDimension representing a Row (when Orientation is Horizontal) or Column (when Orientation is Vertical) of the control and its layout configuration.
            /// </summary>
            /// <param name="items">The child views represented by this Dimension.</param>
            /// <param name="fitMeasure">The Width (when Orientation is Horizontal) or Height (when Orientation is Vertical) measure of this Dimension.</param>
            /// <param name="flowMeasure">The Height (when Orientation is Horizontal) or Width (when Orientation is Vertical) measure of this Dimension.</param>
            /// <param name="flowExpands">Specifies if this Dimension has any child views that expand on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).</param>
            /// <param name="fitExpandCount">The count of child views that expand on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).</param>
            /// <param name="fitExpandMeasure">The expand measure of child views on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).</param>
            /// <param name="fitFillMeasure">The fill measure of child views on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).</param>
            /// <param name="endParagraph">Specifies if this Dimension represents the end of a paragraph on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).</param>
            public WrapDimension(IList<WrapItem> items, double fitMeasure, double flowMeasure, bool flowExpands, int fitExpandCount, double fitExpandMeasure, double fitFillMeasure, bool endParagraph)
            {
                Items = items;
                FitMeasure = fitMeasure;
                FlowMeasure = flowMeasure;
                FlowExpands = flowExpands;
                FitExpandCount = fitExpandCount;

                //TODO: I don't this is used anymore, no need to be calculated or passed
                FitExpandMeasure = fitExpandMeasure;

                FitFillMeasure = fitFillMeasure;
                EndParagraph = endParagraph;
            }

            /// <summary>
            /// Gets the 
            /// </summary>
            public IList<WrapItem> Items { get; }

            /// <summary>
            /// Gets the Width (when Orientation is Horizontal) or Height (when Orientation is Vertical) measure of this Dimension.
            /// </summary>
            public double FitMeasure { get; }

            /// <summary>
            /// Gets the Height (when Orientation is Horizontal) or Width (when Orientation is Vertical) measure of this Dimension.
            /// </summary>
            public double FlowMeasure { get; }

            /// <summary>
            /// Specifies if this Dimension has any child views that expand on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).
            /// </summary>
            public bool FlowExpands { get; }

            /// <summary>
            /// Gets the count of child views that expand on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).
            /// </summary>
            public int FitExpandCount { get; }

            /// <summary>
            /// Gets the expand measure of child views on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).
            /// </summary>
            public double FitExpandMeasure { get; }

            /// <summary>
            /// Gets the fill measure of child views on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).
            /// </summary>
            public double FitFillMeasure { get; }

            /// <summary>
            /// Specifies if this Dimension represents the end of a paragraph on the Horizontal axis (when Orientation is Horizontal) or Vertical axis (when Orientation is Vertical).
            /// </summary>
            public bool EndParagraph { get; private set; }
        }

        /// <summary>
        /// Represents layout configuration of child views designated to their calculated Dimension (Row and Column).
        /// </summary>
        protected class WrapContent
        {
            /// <summary>
            /// Constructs a WrapContent representing layout configuration of child views designated to their calculated Dimension (Row and Column).
            /// </summary>
            /// <param name="dimensions">Represents the layout configuration of the Rows (when Orientation is Horizontal) or Columns (when Orientation is Vertical).</param>
            /// <param name="actualCount">The actual calculated count of dimensions.</param>
            /// <param name="actualStartIndex">The actual calculated index of the first visible dimension.</param>
            /// <param name="fitContentAlignment">The HorizontalLayoutAlignment (when Orientation is Horizontal) or VerticalLayoutAlignment (when Orientation is Vertical) of this content.</param>
            /// <param name="flowContentAlignment">The VerticalLayoutAlignment (when Orientation is Horizontal) or HorizontalLayoutAlignment (when Orientation is Vertical) of this content.</param>
            /// <param name="fitOrientationReverse">Specifies if the Orientation is reversed for the horizontal axis (when Orientation is Horizontal) or the vertical axis (when Orientation is Vertical) of this content.</param>
            /// <param name="flowOrientationReverse">Specifies if the Orientation is reversed for the vertical axis (when Orientation is Horizontal) or the horizontal axis (when Orientation is Vertical) of this content.</param>
            /// <param name="fitMeasure">The width (when Orientation is Horizontal) or height (when Orientation is Vertical) measure of this content.</param>
            /// <param name="flowMeasure">The height (when Orientation is Horizontal) or width (when Orientation is Vertical) measure of this content.</param>
            /// <param name="fitMinimumMeasure">The minimum width (when Orientation is Horizontal) or minimum height (when Orientation is Vertical) measure of this content.</param>
            /// <param name="flowMinimumMeasure">The minimum height (when Orientation is Horizontal) or minimum width (when Orientation is Vertical) measure of this content.</param>
            /// <param name="flowExpandCount">The count of dimensions that expand on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).</param>
            /// <param name="flowExpandMeasure">The expand measure of dimensions on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).</param>
            /// <param name="flowFillMeasure">The fill measure of dimensions on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).</param>
            /// <param name="flowSpacing">The VerticalSpacing (when Orientation is Horizontal) or HorizontalSpacing (when Orientation is Vertical) measure of this content.</param>
            public WrapContent(IList<WrapDimension> dimensions, int actualCount, int actualStartIndex, LayoutAlignment fitContentAlignment, LayoutAlignment flowContentAlignment, bool fitOrientationReverse, bool flowOrientationReverse, double fitMeasure, double flowMeasure, double fitMinimumMeasure, double flowMinimumMeasure, int flowExpandCount, double flowExpandMeasure, double flowFillMeasure, double flowSpacing)
            {
                Dimensions = dimensions;
                ActualCount = actualCount;
                ActualStartIndex = actualStartIndex;
                FitContentAlignment = fitContentAlignment;
                FlowContentAlignment = flowContentAlignment;
                FitOrientationReverse = fitOrientationReverse;
                FlowOrientationReverse = flowOrientationReverse;
                FitMeasure = fitMeasure;
                FlowMeasure = flowMeasure;
                FitMinimumMeasure = fitMinimumMeasure;
                FlowMinimumMeasure = flowMinimumMeasure;
                FlowExpandCount = flowExpandCount;
                FlowExpandMeasure = flowExpandMeasure;
                FlowFillMeasure = flowFillMeasure;
                FlowSpacing = flowSpacing;
            }

            /// <summary>
            /// Gets the layout configuration of the Rows (when Orientation is Horizontal) or Columns (when Orientation is Vertical).
            /// </summary>
            public IList<WrapDimension> Dimensions { get; }

            /// <summary>
            /// Gets the actual calculated count of dimensions.
            /// </summary>
            public int ActualCount { get; }

            /// <summary>
            /// Gets the actual calculated index of the first dimension.
            /// </summary>
            public int ActualStartIndex { get; }

            /// <summary>
            /// Get the HorizontalLayoutAlignment (when Orientation is Horizontal) or VerticalLayoutAlignment (when Orientation is Vertical) of this content.
            /// </summary>
            public LayoutAlignment FitContentAlignment { get; }

            /// <summary>
            /// Gets the VerticalLayoutAlignment (when Orientation is Horizontal) or HorizontalLayoutAlignment (when Orientation is Vertical) of this content.
            /// </summary>
            public LayoutAlignment FlowContentAlignment { get; }

            /// <summary>
            /// Specifies if the Orientation is reversed for the horizontal axis (when Orientation is Horizontal) or the vertical axis (when Orientation is Vertical) of this content.
            /// </summary>
            public bool FitOrientationReverse { get; }

            /// <summary>
            /// Specifies if the Orientation is reversed for the vertical axis (when Orientation is Horizontal) or the horizontal axis (when Orientation is Vertical) of this content.
            /// </summary>
            public bool FlowOrientationReverse { get; }

            /// <summary>
            /// Gets the width (when Orientation is Horizontal) or height (when Orientation is Vertical) measure of this content.
            /// </summary>
            public double FitMeasure { get; }

            /// <summary>
            /// Gets the height (when Orientation is Horizontal) or width (when Orientation is Vertical) measure of this content.
            /// </summary>
            public double FlowMeasure { get; }

            /// <summary>
            /// Gets the minimum width (when Orientation is Horizontal) or minimum height (when Orientation is Vertical) measure of this content.
            /// </summary>
            public double FitMinimumMeasure { get; }

            /// <summary>
            /// Gets the minimum height (when Orientation is Horizontal) or minimum width (when Orientation is Vertical) measure of this content.
            /// </summary>
            public double FlowMinimumMeasure { get; }

            /// <summary>
            /// Gets the count of dimensions that expand on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).
            /// </summary>
            public int FlowExpandCount { get; }

            /// <summary>
            /// Gets the expand measure of dimensions on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).
            /// </summary>
            public double FlowExpandMeasure { get; }

            /// <summary>
            /// Gets the fill measure of dimensions on the Vertical axis (when Orientation is Horizontal) or Horizontal axis (when Orientation is Vertical).
            /// </summary>
            public double FlowFillMeasure { get; }

            /// <summary>
            /// Gets the VerticalSpacing (when Orientation is Horizontal) or HorizontalSpacing (when Orientation is Vertical) measure of this content.
            /// </summary>
            public double FlowSpacing { get; }
        }

        #endregion
    }
}