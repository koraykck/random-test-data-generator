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
							   ObjectId = 2,
							   Name = "Name",
							   Description = "English names",
							   Key = "name",
							   CreatedDate = DateTime.Now,
							   CreatedBy = 0,
							   GeneratorType = "db"
						   },
			new RandomDataType
			{
				ObjectId = 3,
				Name = "Country",
				Description = "Countries",
				Key = "country",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "db"
			},
			new RandomDataType
			{
				ObjectId = 4,
				Name = "Last Name",
				Description = "English last names",
				Key = "last-name",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "db"
			},
			new RandomDataType
			{
				ObjectId = 5,
				Name = "Mail",
				Description = "Mail",
				Key = "mail",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "code"
			},
			new RandomDataType
			{
				ObjectId = 6,
				Name = "City",
				Description = "City",
				Key = "city",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "db"
			},
			new RandomDataType
			{
				ObjectId = 7,
				Name = "Boolean",
				Description = "Boolean",
				Key = "boolean",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "code"
			},
			new RandomDataType
			{
				ObjectId = 8,
				Name = "String",
				Description = "String",
				Key = "string",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "code"
			},
			new RandomDataType
			{
				ObjectId = 9,
				Name = "Number",
				Description = "Number",
				Key = "integer",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "code"
			},
			new RandomDataType
			{
				ObjectId = 10,
				Name = "Datetime",
				Description = "Datetime",
				Key = "datetime",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "code"
			},
			new RandomDataType
			{
				ObjectId = 11,
				Name = "Guid",
				Description = "Guid",
				Key = "guid",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "code"
			},
			new RandomDataType
			{
				ObjectId = 12,
				Name = "Gender",
				Description = "Gender",
				Key = "gender",
				CreatedDate = DateTime.Now,
				CreatedBy = 0,
				GeneratorType = "db"
			}
			);
        }
    }
}
