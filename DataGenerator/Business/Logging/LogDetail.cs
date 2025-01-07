using DataAccess.Context;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logging
{
    public class LogDetail
    {
        [Key]
        public int Id { get; set; }
        public object RequestMethod { get; set; }
        public object Controller { get; set; }
        public object Action { get; set; }
        public object UserName { get; set; }
        public string IpAddress { get; set; }
        public object RequestPath { get; set; }
        public object RequestQueryString { get; set; }

        public object RequestForm { get; set; }
        public object RequestReadAsString { get; set; }
        public object Response { get; set; }
        public object Url { get; set; }
        public object Duration { get; set; }

        public void PushProperty()
        {
            foreach (PropertyInfo info in GetType().GetProperties())
            {
                var value = info.GetValue(this, null);
                LogContext.PushProperty(info.Name, value);
            }
        }
    }
}
