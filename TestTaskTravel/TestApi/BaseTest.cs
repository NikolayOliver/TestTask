using Core;
using Core.ServiceHelpers;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Utilities;

namespace TestApi
{
    public abstract class BaseTest
    {
        protected JsonHelper JsonHelper { get; set; }
        protected string FilePath { get; set; }

        [TestInitialize]
        public void Intitialize()
        {
            Log.Info($"Using BaseApiUrl: {Configuration.BaseUrl}");
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
