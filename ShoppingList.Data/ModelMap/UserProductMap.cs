﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingList.Models.Models;

namespace ShoppingList.Data.ModelMap
{

    public class UserProductMap : BaseModelMap<UserProduct>, IEntityTypeConfiguration<UserProduct>
    {
        public new void Configure(EntityTypeBuilder<UserProduct> builder)
        {
            base.Configure(builder);
            builder.HasOne(t => t.ProductList).WithMany(t => t.UserProducts).HasForeignKey(t => t.ProductListId);
            builder.HasIndex(t => t.ProductListId);
            builder.HasIndex(t => t.ProductId);
            builder.HasOne(t => t.Product).WithMany(t => t.UserProducts).HasForeignKey(t => t.ProductId);
        }
    }

}
