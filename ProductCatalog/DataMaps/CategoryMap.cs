using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.DataMaps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            
            builder.HasKey(c => c.Id);

            builder.Property("Title")
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("VARCHAR(120)");
        }
    }
}
