using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskTravel.Models;

namespace TestTaskTravel.DeserializeSerialize
{
    public class CommonClass<T> where T : MainModel
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        string curr = AppDomain.CurrentDomain.BaseDirectory;
        public T Model { get; set; }
        protected string FilePath => $"{currentDirectory}\\..\\..\\..\\TestTaskTravel\\Jsons\\{Model.GetFileName()}";

        public CommonClass()
        {
            Model = (T)Activator.CreateInstance(typeof(T));
        }

        public void Serialize(ListResponseModel<T> jsonValue) =>
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(jsonValue, Formatting.Indented));


        public ListResponseModel<T> Deserialize() => JsonConvert.DeserializeObject<ListResponseModel<T>>(File.ReadAllText(FilePath));
    }
}
