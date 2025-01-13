using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.DTOs
{
    public class RandomDataDTO
    {
        public int TypeId { get; set; }
        public string TypeKey { get; set; }
        public string Value { get; set; }
        public string? DependentValue { get; set; }
        public int? DependentValueId { get; set; }
    }
}
