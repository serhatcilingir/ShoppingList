using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingList.Models.Models;

namespace ShoppingList.Data.ModelMap
{


    public class ProductMap : BaseModelMap<Product>, IEntityTypeConfiguration<Product>
    {
        public new void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Name).IsRequired();
            builder.HasOne(t => t.Category).WithMany(t => t.Products).HasForeignKey(t => t.CategoryId).IsRequired();
            builder.HasIndex(t => t.CategoryId);
            builder.HasMany(t => t.UserProducts).WithOne(t => t.Product).HasForeignKey(t => t.ProductId);
        }
    }

}
