using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberator.Excellerator
{
    internal static class Extensions
    {
        /// <summary>
        /// Calculates the excel column number
        /// </summary>
        /// <param name="name">The column address</param>
        /// <returns>The column number</returns>
        public static int ToOneBasedIndex(this String name)
        {
            return name.ToUpper().Aggregate(0, (column, letter) => 26 * column + letter - 'A' + 1);
        }
    }
}
