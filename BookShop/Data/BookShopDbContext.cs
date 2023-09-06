using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext() : base()
        { this.Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            optionsBuilder.UseSqlServer(conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorConfigs());
            modelBuilder.ApplyConfiguration(new BookConfigs());
            modelBuilder.ApplyConfiguration(new ClientConfigs());
            modelBuilder.ApplyConfiguration(new GoodsConfigs());
            modelBuilder.Entity<Country>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<PublishingHouse>().Property(x => x.Name).HasMaxLength(100);
            DbInitializer.SeedData(modelBuilder);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DeferredBook> DeferredBooks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
