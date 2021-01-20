using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTravel.Models
{
    public class ListResponseModel<T>
        where T : MainModel
    {
        [JsonProperty("Model", NullValueHandling = NullValueHandling.Ignore)]
        T Model { get; set; }
        public List<T> DataCollection { get; set; }

        public ListResponseModel(T model)
        {
            this.Model = model;
        }
    }
}
