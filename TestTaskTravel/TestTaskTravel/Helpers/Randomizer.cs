using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTravel.Helpers
{
    public class Randomizer
    {
        public static int GetRandomInt(int minValue = 0, int maxValue = 1000) => new Random().Next(minValue, maxValue);
        public static string GetRandomGuid() => Guid.NewGuid().ToString("N");
    }
}
