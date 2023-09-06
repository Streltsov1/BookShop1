using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class GoodsConfigs : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.Property(x => x.Discount).IsRequired(false);
            builder.HasMany(x => x.Sales)
                   .WithOne(x => x.Goods)
                   .HasForeignKey(x => x.GoodsId);
            builder.HasMany(x => x.DeferredBooks)
                   .WithOne(x => x.Goods)
                   .HasForeignKey(x => x.GoodsId);
            //builder.HasCheckConstraint("Number", "Number => 0");
            //builder.HasCheckConstraint("Cost", "Cost > 0");
            //builder.HasCheckConstraint("Price", "Price > 0");
            //builder.HasCheckConstraint("Discount", "Discount => 0 and Discount <= 100");
        }
    }
}
