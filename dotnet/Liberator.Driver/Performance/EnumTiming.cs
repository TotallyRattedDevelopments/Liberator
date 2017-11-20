namespace Liberator.Driver.Performance
{
    /// <summary>
    /// Enumeraion of timing points for performance metrics
    /// </summary>
    public enum EnumTiming
    {
        /// <summary>
        /// Timing point not specified
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Generic timing point
        /// </summary>
        GenericTiming = 1,

        /// <summary>
        /// Timing point for instance creation
        /// </summary>
        Instantiation = 2,

        /// <summary>
        /// Page load timing point
        /// </summary>
        PageLoad = 3
    }
}
