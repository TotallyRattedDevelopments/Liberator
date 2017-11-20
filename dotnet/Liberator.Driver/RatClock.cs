using OpenQA.Selenium.Support.UI;
using System;

namespace Liberator.Driver
{
    /// <summary>
    /// Provides an implementation of the IClock class for RatDriver
    /// </summary>
    public sealed class RatClock : IClock
    {
        /// <summary>
        /// Used to verify whether the event has executed within a set time period
        /// </summary>
        /// <param name="otherDateTime">The expected end to the event execution</param>
        /// <returns>Whether the event has completed in the specified time period</returns>
        public bool IsNowBefore(DateTime otherDateTime)
        {
            var value = otherDateTime.CompareTo(DateTime.Now);
            return value > 0;
        }

        /// <summary>
        /// Sets the delay amount for the test
        /// </summary>
        /// <param name="delay">The delay time to set</param>
        /// <returns>The time of the expected end to the timed event</returns>
        public DateTime LaterBy(TimeSpan delay)
        {
            return DateTime.Now.Add(delay);
        }

        /// <summary>
        /// Gets the current time
        /// </summary>
        public DateTime Now
        {
            get { return DateTime.Now.ToUniversalTime(); }
        }
    }
}
