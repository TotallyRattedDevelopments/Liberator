using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
        public List<Tuple<EnumTiming, RatTimer>> Timings { get; set; }

        /// <summary>
        /// The timer currently being used
        /// </summary>
        public RatTimer CurrentTimer { get; set; }

        /// <summary>
        /// Constructor for the RatWatch class
        /// </summary>
        public RatWatch()
        {
            Timings = new List<Tuple<EnumTiming, RatTimer>>();
        }

        /// <summary>
        /// Adds the timings from an existing watch to a new one.
        /// </summary>
        /// <param name="ratWatch">Existing watch.</param>
        public RatWatch(RatWatch ratWatch)
        {
            Timings = ratWatch.Timings;
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
                Timings.Add(new Tuple<EnumTiming, RatTimer>(EnumTiming.NotSpecified, CurrentTimer));
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
                Timings.Add(new Tuple<EnumTiming, RatTimer>(timerType, CurrentTimer));
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
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The arithmetic mean for the timings list</returns>
        public double ArithmeticMean([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.Mean(valueList);
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
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The geometic mean for the timings list</returns>
        public double GeometricMean([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.GeometricMean(valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the geometric mean");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// Calculates the harmonic mean for the timings list
        /// </summary>
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The harmonic mean for the timings list</returns>
        public double HarmonicMean([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.HarmonicMean(valueList);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to calculate the harmonic mean");
                Console.WriteLine(ex.Message);
                return 0d;
            }
        }

        /// <summary>
        /// Calculates the median value for the timings list
        /// </summary>
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The median time for the entries in the timing list</returns>
        public double Median([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.Median(valueList);

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
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The skewness of the timings list away from the mean</returns>
        public double Skewness([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.Skewness(valueList);

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
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The standard deviation of the sample</returns>
        public double StandardDeviation([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.StandardDeviation(valueList);

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
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>The point represneting the 75th percentile</returns>
        public double UpperQuartile([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.UpperQuartile(valueList);

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
        /// <param name="enumTiming">Type of timing point</param>
        /// <returns>How far the timings list values are spread out from the mean</returns>
        public double Variance([DefaultParameterValue(EnumTiming.NotSpecified)]EnumTiming enumTiming)
        {
            try
            {
                IEnumerable<double> valueList =
                    Timings.Where(v => v.Item1 == enumTiming)
                    .DefaultIfEmpty()
                    .Select(v => v.Item2.Duration.TotalMilliseconds);

                return Statistics.Variance(valueList);

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
