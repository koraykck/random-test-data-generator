using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public object Exception { get; set; }
    }
}
