using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Utilities
{
    /// <summary>
    /// Json helper
    /// </summary>
    public class JsonHelper
    {
        readonly string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        protected string FilePath { get; set; }

        public JsonHelper(string fileName)
        {
            FilePath = $"{currentDirectory}\\..\\..\\..\\TestTaskTravel\\Jsons\\{fileName}"; 
        }

        /// <summary>
        /// Serialize data to Json
        /// </summary>
        public void Serialize<T>(DataCollectionClass<T> jsonValue) =>
           File.WriteAllText(FilePath, JsonConvert.SerializeObject(jsonValue, Formatting.Indented));

        /// <summary>
        /// Deserialize data from Json
        /// </summary>
        public DataCollectionClass<T> Deserialize<T>() => JsonConvert.DeserializeObject<DataCollectionClass<T>>(File.ReadAllText(FilePath));
    
}
}
