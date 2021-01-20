using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Session manager
    /// </summary>
    public static class SessionManager
    {
        public static IRestClient RestClient
        {
            get
            {
                var client = new RestClient(Configuration.BaseUrl)
                {
                    Timeout = Configuration.Timeout,
                    Authenticator = new HttpBasicAuthenticator(Configuration.User, Configuration.Password)
            };
                return client;
            }
        }

        public static IRestRequest RestRequest
        {
            get
            {
                var request = new RestRequest
                {
                    Timeout = Configuration.Timeout
                };

                return request;
            }
        }
    }
}
