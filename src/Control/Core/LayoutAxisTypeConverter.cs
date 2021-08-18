using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui.Controls.Xaml;

namespace Rox
{
    /// <summary>
    /// Type converter for a LayoutAxis which represents either a X or Y axis.
    /// </summary>
    [TypeConversion(typeof(LayoutAxis))]
    public class LayoutAxisTypeConverter
        : TypeConverter
    {
        #region Convert

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                string[] axisArray = stringValue.Split(',');
                if (axisArray.Length == 2 &&
                    double.TryParse(axisArray[0], NumberStyles.Number, culture, out double point) &&
                    double.TryParse(axisArray[1], NumberStyles.Number, culture, out double measure))
                {
                    return new LayoutAxis(point, measure);
                }
            }

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(LayoutAxis)));
        }

        #endregion
    }
}