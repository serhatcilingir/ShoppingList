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

    public class BaseModelMap<T> where T : BaseModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(t => t.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
