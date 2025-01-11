using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Configurations
{
 
    public class RandomDataTypeConfiguration : IEntityTypeConfiguration<RandomDataType>
    {
        public void Configure(EntityTypeBuilder<RandomDataType> builder)
        {
            builder.HasData(
                new RandomDataType
                {
                    ObjectId = 1,
                    Name = "Name",
                    Description = "English names",
                    Key = "name",
                },
                new RandomDataType
                {
                    ObjectId = 2,
                    Name = "Country",
                    Description = "All countries in the world",
                    Key = "country",
                }
            );
        }
    }
}
