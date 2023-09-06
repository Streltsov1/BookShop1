using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class ClientConfigs : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(64);
            builder.Property(x => x.Surname)
                   .HasMaxLength(64);
            builder.Property(x => x.Phone)
                   .HasMaxLength(12);
            builder.HasMany(x => x.Sales)
                   .WithOne(x => x.Client)
                   .HasForeignKey(x => x.ClientId);
            builder.HasMany(x => x.DeferredBooks)
                   .WithOne(x => x.Client)
                   .HasForeignKey(x => x.ClientId);
        }
    }
}
