using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RandomData : BaseEntity
    {
        public int TypeId { get; set; }

        public string Value { get; set; } = string.Empty;

        public int? DependentRandomDataId { get; set; }

        [ForeignKey("TypeId")]
        public  RandomDataType Type { get; set; }

        [ForeignKey("DependentRandomDataId")]
        public RandomData? DependentRandomData { get; set; }
    }
}
