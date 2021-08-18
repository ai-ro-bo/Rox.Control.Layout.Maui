using System.Diagnostics;
using System.Globalization;

namespace Rox
{
    /// <summary>
    /// LayoutRectangle definition that represents a Fit or Flow rectangle.
    /// </summary>
    [DebuggerDisplay("FitPoint={FitPoint}, FlowPoint={FlowPoint}, FitMeasure={FitMeasure}, FlowMeasure={FlowMeasure}")]
    [System.ComponentModel.TypeConverter(typeof(LayoutRectangleTypeConverter))]
    public struct LayoutRectangle
    {
        #region Construct

        /// <summary>
        /// Creates a new LayoutRectangle where all properties are equal to zero.
        /// </summary>
        public static LayoutRectangle Zero = new LayoutRectangle();

        /// <summary>
        /// Constructs a LayoutRectangle representing either a Fit or Flow rectangle.
        /// </summary>
        /// <param name="fitPoint">Represents a Fit point on a Fit axis.</param>
        /// <param name="flowPoint">Represents a Flow point on a Flow axis.</param>
        /// <param name="fitMeasure">Represents a Fit measure on a Fit axis.</param>
        /// <param name="flowMeasure">Represents a Flow measure on a Flow axis.</param>
        public LayoutRectangle(double fitPoint, double flowPoint, double fitMeasure, double flowMeasure)
            : this()
        {
            FitPoint = fitPoint;
            FlowPoint = flowPoint;
            FitMeasure = fitMeasure;
            FlowMeasure = flowMeasure;
        }

        /// <summary>
        /// Constructs a LayoutRectangle representing either a Fit or Flow rectangle.
        /// </summary>
        /// <param name="layoutFitAxis">Represents a Fit axis.</param>
        /// <param name="layoutFlowAxis">Represents a Flow axis.</param>
        public LayoutRectangle(LayoutAxis layoutFitAxis, LayoutAxis layoutFlowAxis)
            : this(layoutFitAxis.Point, layoutFlowAxis.Point, layoutFitAxis.Measure, layoutFlowAxis.Measure)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents a Fit point on a Fit axis.
        /// </summary>
        public double FitPoint { get; set; }

        /// <summary>
        /// Represents a Flow point on a Flow axis.
        /// </summary>
        public double FlowPoint { get; set; }

        /// <summary>
        /// Represents a Fit measure on a Fit axis.
        /// </summary>
        public double FitMeasure { get; set; }

        /// <summary>
        /// Represents a Flow measure on a Flow axis.
        /// </summary>
        public double FlowMeasure { get; set; }

        #endregion

        #region Equality Operators

        /// <summary>
        /// Performs an equality test on the Equals method of all properties.
        /// </summary>
        /// <param name="otherLayoutRectangle">The given LayoutRectangle to compare against this instance.</param>
        /// <returns>True if the given LayoutRectangle is the same value as this LayoutRectangle instance.</returns>
        public bool Equals(LayoutRectangle otherLayoutRectangle)
        {
            return FitPoint.Equals(otherLayoutRectangle.FitPoint) &&
                FlowPoint.Equals(otherLayoutRectangle.FlowPoint) &&
                FitMeasure.Equals(otherLayoutRectangle.FitMeasure) &&
                FlowMeasure.Equals(otherLayoutRectangle.FlowMeasure);
        }

        /// <summary>
        /// Performs an equality test on the == operator if the passed in Object is of type LayoutRectangle.
        /// </summary>
        /// <param name="other">The given Object to compare against this LayoutRectangle instance.</param>
        /// <returns>True if the given LayoutRectangle is the same type and value as this LayoutRectangle instance.</returns>
        public override bool Equals(object other)
        {
            bool equals = false;
            if (other is LayoutRectangle otherLayoutRectangle)
            {
                equals = this == otherLayoutRectangle;
            }
            return equals;
        }

        /// <summary>
        /// Equality operator for a LayoutRectangle which performs equality test on equality operator of all properties.
        /// </summary>
        /// <param name="layoutRectangleA">The first LayoutRectangle to compare.</param>
        /// <param name="layoutRectangleB">The second LayoutRectangle to compare against the first LayoutRectangle.</param>
        /// <returns>True if the two given LayoutRectangle are of the same value.</returns>
        public static bool operator ==(LayoutRectangle layoutRectangleA, LayoutRectangle layoutRectangleB) =>
            (layoutRectangleA.FitPoint == layoutRectangleB.FitPoint) &&
            (layoutRectangleA.FlowPoint == layoutRectangleB.FlowPoint) &&
            (layoutRectangleA.FitMeasure == layoutRectangleB.FitMeasure) &&
            (layoutRectangleA.FlowMeasure == layoutRectangleB.FlowMeasure);

        /// <summary>
        /// Reverse equality operator for a LayoutRectangle which returns the reverse result of the equality operator.
        /// </summary>
        /// <param name="layoutRectangleA">The first LayoutRectangle to compare.</param>
        /// <param name="layoutRectangleB">The second LayoutRectangle to compare against the first LayoutRectangle.</param>
        /// <returns>True if the two given LayoutRectangle are not of the same value.</returns>
        public static bool operator !=(LayoutRectangle layoutRectangleA, LayoutRectangle layoutRectangleB) =>
            !(layoutRectangleA == layoutRectangleB);

        #endregion

        #region Overrides

        ///<inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = FitPoint.GetHashCode();
                hashCode = (hashCode * 397) ^ FlowPoint.GetHashCode();
                hashCode = (hashCode * 397) ^ FitMeasure.GetHashCode();
                hashCode = (hashCode * 397) ^ FlowMeasure.GetHashCode();
                return hashCode;
            }
        }

        ///<inheritdoc />
        public override string ToString() =>
            string.Format("{{FitPoint={0}, FlowPoint={1}, FitMeasure={2}, FlowMeasure={3}}}",
                FitPoint.ToString(CultureInfo.InvariantCulture),
                FlowPoint.ToString(CultureInfo.InvariantCulture),
                FitMeasure.ToString(CultureInfo.InvariantCulture),
                FlowMeasure.ToString(CultureInfo.InvariantCulture));

        #endregion

        #region Helpers

        /// <summary>
        /// Checks if the properties of this instance are all equal to zero.
        /// </summary>
        public bool IsZero =>
            (FitPoint == 0d) ||
            (FitMeasure == 0d) ||
            (FlowPoint == 0d) ||
            (FlowMeasure == 0d);

        /// <summary>
        /// Checks if the measure has visible content.
        /// </summary>
        public bool IsEmpty =>
            (FitMeasure <= 0d) ||
            (FlowMeasure <= 0d);

        /// <summary>
        /// Gets the LayoutAxis representing the Fit axis.
        /// </summary>
        /// <returns>A LayoutAxis representing the Fit axis.</returns>
        public LayoutAxis GetLayoutFitAxis() => new LayoutAxis(
            FitPoint,
            FitMeasure);

        /// <summary>
        /// Gets the LayoutAxis representing the Flow axis.
        /// </summary>
        /// <returns>A LayoutAxis representing the Flow axis.</returns>
        public LayoutAxis GetLayoutFlowAxis() => new LayoutAxis(
            FlowPoint,
            FlowMeasure);

        /// <summary>
        /// Deconstructs a LayoutRectangle into separate properties.
        /// </summary>
        /// <param name="fitPoint">The FitPoint represented by this instance.</param>
        /// <param name="flowPoint">The FlowPoint represented by this instance.</param>
        /// <param name="fitMeasure">The FitMeasure represented by this instance.</param>
        /// <param name="flowMeasure">The FlowMeasure represented by this instance.</param>
        public void Deconstruct(out double fitPoint, out double flowPoint, out double fitMeasure, out double flowMeasure)
        {
            fitPoint = FitPoint;
            flowPoint = FlowPoint;
            fitMeasure = FitMeasure;
            flowMeasure = FlowMeasure;
        }

        #endregion
    }
}