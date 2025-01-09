using Domain.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class AppUser : IdentityUser<int>, IEntity
    {
        public string NameSurname { get; set; }

        [Key]
        public int ObjectId { get; set; }      
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set ; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }


    }
}
