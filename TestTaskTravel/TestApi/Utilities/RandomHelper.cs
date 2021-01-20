using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Utilities
{
    /// <summary>
    /// Random helper
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// Generates random int value
        /// </summary>
        public static int GetRandomInt(int minValue = 0, int maxValue = 1000) => new Random().Next(minValue, maxValue);

        /// <summary>
        /// Generates random Guid value
        /// </summary>
        public static string GetRandomGuid() => Guid.NewGuid().ToString("N");
    }
}
