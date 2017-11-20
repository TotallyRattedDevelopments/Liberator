using System;

namespace Liberator.Driver.Performance
{
    /// <summary>
    /// Timer for RatDriver
    /// </summary>
    public class RatTimer : ITimer
    {
        /// <summary>
        /// Start time for the timer
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time for the timer
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Duration for the timer instance
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Constructor for the RatTimer class
        /// </summary>
        public RatTimer()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            Duration = new TimeSpan(0, 0, 0, 0, 0);
        }

        /// <summary>
        /// Starts the time and resets the duration
        /// </summary>
        public void Start()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            Duration = new TimeSpan(0, 0, 0, 0, 0);
        }

        /// <summary>
        /// Stops the timer and calculates the duration
        /// </summary>
        public void Stop()
        {
            EndTime = DateTime.Now;
            Duration = EndTime - StartTime;
        }
    }
}
