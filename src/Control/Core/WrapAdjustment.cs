namespace Rox
{
    /// <summary>
    /// WrapActualAdjustment definition that represents the method of which to calculate the actual counts.
    /// </summary>
    public enum WrapActualAdjustment
    {
        /// <summary>
        /// Do not adjust the StartIndex.
        /// </summary>
        None = 0,

        /// <summary>
        /// Adjust the VisibleCount so that the dimensions start at the StartIndex.
        /// </summary>
        StartIndex = 1,

        /// <summary>
        /// Adjust the StartIndex so the maximum possible dimensions are visible according to VisibleCount.
        /// </summary>
        VisibleCount = 2
    }
}