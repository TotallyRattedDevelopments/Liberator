using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liberator.Driver.Performance
{
    /// <summary>
    /// A control class for RatDriver performance metrics
    /// </summary>
    public class RatWatch
    {
        /// <summary>
        /// Contains the timings for the current analysis cycle
        /// </summary>
        public Dictionary<EnumTiming, RatTimer> Timings { get; set; }

        /// <summary>
        /// The timer currently being used
        /// </summary>
        public RatTimer CurrentTimer { get; set; }

        private Dictionary<EnumTiming, RatTimer>.ValueCollection _values;
        private IEnumerable<double> _valueList;

        /// <summary>
        /// Constructor for the RatWatch class
        /// </summary>
        public RatWatch()
        {
            Timings = new Dictionary<EnumTiming, RatTimer>();
        }

        /// <summary>
        /// Creates a new timer and starts the count
        /// </summary>
        public void StartTimer()
        {
            try
            {
                CurrentTimer = new RatTimer();
                CurrentTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to start the timer");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Stops the timer and adds it to the timings list
        /// </summary>
        /// <returns></returns>
        public TimeSpan StopTimer()
        {
            try
            {
                CurrentTimer.Stop();
                Timings.Add(EnumTiming.NotSpecified, CurrentTimer);
                return CurrentTimer.Duration;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to stop the timer");
                Console.WriteLine(ex.Message);
                return new TimeSpan(0);
            }
        }

        /// <summary>
        /// Stops the timer and adds a specified timing point type to th timings list
        /// </summary>
        /// <param name="timerType"></param>
        /// <returns></returns>
        public TimeSpan StopTimer(EnumTiming timerType)
        {
            try
            {
                CurrentTimer.Stop();
                Timings.Add(timerType, CurrentTimer);
                _values = Timings.Values;
                _valueList = _values.Where(v => true).DefaultIfEmpty().Select(v => v.Duration.TotalMilliseconds);
                return CurrentTimer.Duration;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to stop the timer");
                Console.WriteLine(ex.Message);
                return new TimeSpan(0);
            }
        }

        /// <summary>
        /// Calculates the arithmetic mean for the timings list
        /// </summary>
        /// <returns>The arithmetic mean for the timings list</returns>
        public double ArithmeticMean()
        {
            try
            {
                return Statistics.Mean(_valueList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the arithmetic mean");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// Calculates the geometric mean for the timings list
        /// </summary>
        /// <returns>The geometic mean for the timings list</returns>
        public double GeometricMean()
        {
            try
            {
                return Statistics.GeometricMean(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the geometric mean");
                Console.WriteLine(ex.Message);
                return 0d;
            }        }

        /// <summary>
        /// Calculates the harmonic mean for the timings list
        /// </summary>
        /// <returns>The harmonic mean for the timings list</returns>
        public double HarmonicMean()
        {
            try
            {
                return Statistics.HarmonicMean(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the harmonic mean");
                Console.WriteLine(ex.Message);
                return 0d;
            }        }
        
        /// <summary>
        /// Calculates the median value for the timings list
        /// </summary>
        /// <returns>The median time for the entries in the timing list</returns>
        public double Median()
        {
            try
            {
                return Statistics.Median(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the median of the sample");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// Calculates the Skewness of the values in the timings list
        /// </summary>
        /// <returns>The skewness of the timings list away from the mean</returns>
        public double Skewness()
        {
            try
            {
                return Statistics.Skewness(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the skewness of the sample");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// Caculates the standard deviation of the timings sample
        /// </summary>
        /// <returns>The standard deviation of the sample</returns>
        public double StandardDeviation()
        {
            try
            {
                return Statistics.StandardDeviation(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the standard deviation of the sample");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// Calculates the boundary for the upper quartile of the timings list
        /// </summary>
        /// <returns>The point represneting the 75th percentile</returns>
        public double UpperQuartile()
        {
            try
            {
                return Statistics.UpperQuartile(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the upper quartile of the sample");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// The variance of the timings list sample
        /// </summary>
        /// <returns>How far the timings list values are spread out from the mean</returns>
        public double Variance()
        {
            try
            {
                return Statistics.Variance(_valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the variance of the sample");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }
    }
}
