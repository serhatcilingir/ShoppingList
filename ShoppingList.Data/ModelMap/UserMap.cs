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


    public class UserMap : BaseModelMap<User>, IEntityTypeConfiguration<User>
    {
        public new void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Name).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.Role).IsRequired();
            builder.Property(t => t.Password).IsRequired();
            builder.HasMany(t => t.ProductLists).WithOne(t => t.User).HasForeignKey(t => t.UserId);
        }
    }

}
