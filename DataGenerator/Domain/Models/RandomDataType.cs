using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RandomDataType : BaseEntity
    {
        public  string Name { get; set; }
        public  string Description { get; set; } = string.Empty;
        public string Key { get; set; }
        public string? GeneratorType { get; set; }

    }
}
