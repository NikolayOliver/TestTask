using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public abstract class BaseService
    {
        public IRestClient Client { get; set; } = SessionManager.RestClient;
        public IRestRequest Request { get; set; } = SessionManager.RestRequest;
    }
}
