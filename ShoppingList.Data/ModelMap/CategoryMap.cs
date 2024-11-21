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

    public class CategoryMap : BaseModelMap<Category>, IEntityTypeConfiguration<Category>
    {
        public new void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Name).IsRequired();
            builder.HasMany(t => t.Products).WithOne(t => t.Category).HasForeignKey(t => t.CategoryId);
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }

}
