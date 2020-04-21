using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.DataMaps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreateDate)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnType("VARCHAR(1024)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.Property(p => p.Quantity)
               .IsRequired();

            builder.Property(p => p.LastUpdateDate)
               .IsRequired()
               .HasColumnType("DATETIME");

            //Relacionamento 1 p N
            builder.HasOne(c => c.Category).WithMany(p => p.Products);

        }
    }
}
