using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceHelpers
{
    public abstract class BaseServiceHelper<T> where T : BaseService
    {
        protected T Service { get; set; }
    }
}
