namespace Rox
{
    /// <summary>
    /// LayoutOrientationReverse definition which represents whether the horizontal and/or vertical axis should be reversed.
    /// </summary>
    [Flags]
    public enum LayoutOrientationReverse
    {
        /// <summary>
        /// Do not reverse either the horizontal or vertical axis.
        /// </summary>
        None = 0,

        /// <summary>
        /// Reverse the horizontal axis.
        /// </summary>
        Horizontal = 1,

        /// <summary>
        /// Reverse the vertical axis.
        /// </summary>
        Vertical = 2,

        /// <summary>
        /// Reverse both the horizontal or vertical axis.
        /// </summary>
        Both = 3
    }
}