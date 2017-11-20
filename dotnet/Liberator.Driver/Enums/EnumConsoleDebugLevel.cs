namespace Liberator.Driver.Enums
{
    /// <summary>
    /// Level of debugging to use during testing
    /// </summary>
    public enum EnumConsoleDebugLevel
    {
        /// <summary>
        /// No level specified
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Human readable text
        /// </summary>
        Human = 1,

        /// <summary>
        /// Includes the exception message
        /// </summary>
        Message = 2,

        /// <summary>
        /// Includes the whole stack trace
        /// </summary>
        StackTrace = 3
    }
}
