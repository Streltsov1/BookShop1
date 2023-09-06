using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookConfigs : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(100);
            //builder.HasCheckConstraint("PageNumber", "PageNumber > 0 And PageNumber < 1500");
            //builder.HasCheckConstraint("PublishingDate", "PublishingDate < GETDATE()");
            builder.HasOne(x => x.Genre)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.GenreId);
            builder.HasOne(x => x.Goods)
                   .WithOne(x => x.Book);
            builder.HasOne(x => x.Publishing)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.PublishingId);
            builder.HasOne(x => x.NextBook)
                   .WithOne(x => x.PrevieBook)
                   .HasForeignKey<Book>(x => x.NextBookId)
                   .IsRequired(false);
            builder.HasOne(x => x.PrevieBook)
                   .WithOne(x => x.NextBook)
                   .HasForeignKey<Book>(x => x.PrevieBookId)
                   .IsRequired(false);
        }
    }
}
