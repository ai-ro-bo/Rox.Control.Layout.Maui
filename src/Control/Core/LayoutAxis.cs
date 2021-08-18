using System.Diagnostics;
using System.Globalization;

namespace Rox
{
    /// <summary>
    /// LayoutAxis definition that represents either a X or Y axis
    /// </summary>
    [DebuggerDisplay("Point={Point}, Measure={Measure}")]
    [System.ComponentModel.TypeConverter(typeof(LayoutAxisTypeConverter))]
    public struct LayoutAxis
    {
        #region Construct

        /// <summary>
        /// Creates a new LayoutAxis where all properties are equal to zero.
        /// </summary>
        public static LayoutAxis Zero = new LayoutAxis();

        /// <summary>
        /// Constructs a LayoutAxis representing either a X or Y axis.
        /// </summary>
        /// <param name="point">Represents either a X or Y point on a X or Y axis.</param>
        /// <param name="measure">Represents either a Width or Height measure on a X or Y axis.</param>
        public LayoutAxis(double point, double measure)
            : this()
        {
            Point = point;
            Measure = measure;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents either a X or Y point on a X or Y axis.
        /// </summary>
        public double Point { get; set; }

        /// <summary>
        /// Represents either a Width or Height measure on a X or Y axis.
        /// </summary>
        public double Measure { get; set; }

        #endregion

        #region Equality Operators

        /// <summary>
        /// Performs an equality test on the Equals method of all properties.
        /// </summary>
        /// <param name="otherLayoutAxis">The given LayoutAxis to compare against this instance.</param>
        /// <returns>True if the given LayoutAxis is the same value as this LayoutAxis instance.</returns>
        public bool Equals(LayoutAxis otherLayoutAxis) =>
            Point.Equals(otherLayoutAxis.Point) &&
            Measure.Equals(otherLayoutAxis.Measure);

        /// <summary>
        /// Performs an equality test on the == operator if the passed in Object is of type LayoutAxis.
        /// </summary>
        /// <param name="other">The given Object to compare against this LayoutAxis instance.</param>
        /// <returns>True if the given LayoutAxis is the same type and value as this LayoutAxis instance.</returns>
        public override bool Equals(object other)
        {
            bool equals = false;
            if (other is LayoutAxis otherLayoutAxis)
            {
                equals = this == otherLayoutAxis;
            }
            return equals;
        }

        /// <summary>
        /// Equality operator for a LayoutAxis which performs equality test on equality operator of all properties.
        /// </summary>
        /// <param name="layoutAxisA">The first LayoutAxis to compare.</param>
        /// <param name="layoutAxisB">The second LayoutAxis to compare against the first LayoutAxis.</param>
        /// <returns>True if the two given LayoutAxis are of the same value.</returns>
        public static bool operator ==(LayoutAxis layoutAxisA, LayoutAxis layoutAxisB) =>
            (layoutAxisA.Point == layoutAxisB.Point) &&
            (layoutAxisA.Measure == layoutAxisB.Measure);

        /// <summary>
        /// Reverse equality operator for a LayoutAxis which returns the reverse result of the equality operator.
        /// </summary>
        /// <param name="layoutAxisA">The first LayoutAxis to compare.</param>
        /// <param name="layoutAxisB">The second LayoutAxis to compare against the first LayoutAxis.</param>
        /// <returns>True if the two given LayoutAxis are not of the same value.</returns>
        public static bool operator !=(LayoutAxis layoutAxisA, LayoutAxis layoutAxisB) =>
            !(layoutAxisA == layoutAxisB);

        #endregion

        #region Overrides

        ///<inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Point.GetHashCode();
                hashCode = (hashCode * 397) ^ Measure.GetHashCode();
                return hashCode;
            }
        }

        ///<inheritdoc />
        public override string ToString() =>
            string.Format("{{Point={0} Measure={1}}}",
                Point.ToString(CultureInfo.InvariantCulture),
                Measure.ToString(CultureInfo.InvariantCulture));

        #endregion

        #region Helpers

        /// <summary>
        /// Checks if the properties of this instance are all equal to zero.
        /// </summary>
        public bool IsZero =>
            (Point == 0d) &&
            (Measure == 0d);

        /// <summary>
        /// Checks if the measure has visible content.
        /// </summary>
        public bool IsEmpty =>
            Measure <= 0d;

        /// <summary>
        /// Creates a new LayoutAxis representing this instance offset by the given measure.
        /// </summary>
        /// <param name="dMeasure">The measure to offset the X or Y axis.</param>
        /// <returns>A new LayoutAxis offset by the given measure.</returns>
        public LayoutAxis Offset(double dMeasure)
        {
            LayoutAxis layoutAxis = this;
            layoutAxis.Point += dMeasure;
            layoutAxis.Measure -= dMeasure * 2d;
            return layoutAxis;
        }

        /// <summary>
        /// Deconstructs a LayoutAxis into separate properties.
        /// </summary>
        /// <param name="point">The Point represented by this instance.</param>
        /// <param name="measure">The Measure represented by this instance.</param>
        public void Deconstruct(out double point, out double measure)
        {
            point = Point;
            measure = Measure;
        }

        #endregion
    }
}