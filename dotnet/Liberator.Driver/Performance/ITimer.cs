using System;

namespace Liberator.Driver.Performance
{
    /// <summary>
    /// Root interface for timer implementations
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// Start time of the timer
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// End time for the timer
        /// </summary>
        DateTime EndTime { get; set; }

        /// <summary>
        /// Duration for the timer instance
        /// </summary>
        TimeSpan Duration { get; set; }

        /// <summary>
        /// Start the timer
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the timer
        /// </summary>
        void Stop();
    }
}
