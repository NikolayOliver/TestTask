using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Utilities
{
    /// <summary>
    /// Data collection for serialize/deserialize
    /// </summary>
    public class DataCollectionClass<T>
    {
        public List<T> DataCollection { get; set; }
    }
}
