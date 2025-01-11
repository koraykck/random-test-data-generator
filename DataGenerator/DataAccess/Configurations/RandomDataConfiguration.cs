using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class RandomDataConfiguration : IEntityTypeConfiguration<RandomData>
    {
        public void Configure(EntityTypeBuilder<RandomData> builder)
        {
            builder.HasData(            
                 new RandomData
                 {
                     ObjectId = 1,
                     Value = "David",
                     TypeId = 1
                 },
        new RandomData
        {
            ObjectId = 2,
            Value = "Elizabeth",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 3,
            Value = "Michael",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 4,
            Value = "Sarah",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 5,
            Value = "James",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 6,
            Value = "Emily",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 7,
            Value = "John",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 8,
            Value = "Jessica",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 9,
            Value = "Robert",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 10,
            Value = "Ashley",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 11,
            Value = "William",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 12,
            Value = "Amanda",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 13,
            Value = "Charles",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 14,
            Value = "Sophia",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 15,
            Value = "Joseph",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 16,
            Value = "Isabella",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 17,
            Value = "Thomas",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 18,
            Value = "Olivia",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 19,
            Value = "Henry",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 20,
            Value = "Chloe",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 21,
            Value = "Daniel",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 22,
            Value = "Mia",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 23,
            Value = "Matthew",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 24,
            Value = "Ava",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 25,
            Value = "Christopher",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 26,
            Value = "Grace",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 27,
            Value = "Anthony",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 28,
            Value = "Emma",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 29,
            Value = "Andrew",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 30,
            Value = "Hannah",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 31,
            Value = "Joshua",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 32,
            Value = "Abigail",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 33,
            Value = "Ethan",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 34,
            Value = "Lily",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 35,
            Value = "Alexander",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 36,
            Value = "Samantha",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 37,
            Value = "Nicholas",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 38,
            Value = "Victoria",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 39,
            Value = "Logan",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 40,
            Value = "Zoe",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 41,
            Value = "Benjamin",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 42,
            Value = "Ella",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 43,
            Value = "Jacob",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 44,
            Value = "Natalie",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 45,
            Value = "Samuel",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 46,
            Value = "Megan",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 47,
            Value = "Gabriel",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 48,
            Value = "Sophia",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 49,
            Value = "Ryan",
            TypeId = 1
        },
        new RandomData
        {
            ObjectId = 50,
            Value = "Madison",
            TypeId = 1
        }
            );
        }
    }
}
