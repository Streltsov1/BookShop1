using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class AuthorConfigs : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(64);
            builder.Property(x => x.Surname)
                   .HasMaxLength(64);
            builder.Property(x => x.Birthdate)
                   .IsRequired(false);
            //builder.HasCheckConstraint("Birthdate", "Birthdate < GETDATE()");
            builder.HasOne(x => x.Country)
                   .WithMany(x => x.Authors)
                   .HasForeignKey(x => x.CountryId);
            builder.HasMany(x => x.Books)
                   .WithOne(x => x.Author)
                   .HasForeignKey(x => x.AuthorId);
        }
    }
}
