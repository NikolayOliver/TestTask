using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Getter data from app.config
    /// </summary>
    public static class Configuration
    {
        public static string GetVariable(string variable, string defaultValue = "")
        {
            return ConfigurationManager.AppSettings[variable] ?? defaultValue;
        }

        public static string BaseUrl => GetVariable("BaseUrl");

        public static string User => GetVariable("User");

        public static string Password => GetVariable("Password");

        public static int Timeout => int.Parse(GetVariable("Timeout"));
    }
}
