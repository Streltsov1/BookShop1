using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() { Id = 1, Name = "Ukraine" },
                new Country() { Id = 2, Name = "Italy" },
                new Country() { Id = 3, Name = "Great Britain" },
                new Country() { Id = 4, Name = "France" },
                new Country() { Id = 5, Name = "Poland" },
                new Country() { Id = 6, Name = "USA" }
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre() { Id = 1, Name = "History" },
                new Genre() { Id = 2, Name = "Satire" },
                new Genre() { Id = 3, Name = "Mystery" },
                new Genre() { Id = 4, Name = "Horror" },
                new Genre() { Id = 5, Name = "Fantasy" },
                new Genre() { Id = 6, Name = "Detective" }
            });
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author() { Id = 1, Name = "Oleg", Surname = "Streltsov", Birthdate = DateTime.Now, CountryId = 1 },
                new Author() { Id = 2, Name = "Taras", Surname = "Shevchenko", Birthdate = DateTime.Now, CountryId = 1},
                new Author() { Id = 3, Name = "Joanne", Surname = "Rowling", Birthdate = DateTime.Now, CountryId = 3},
                new Author() { Id = 4, Name = "Alexandre",Surname = "Dumas", Birthdate = DateTime.Now, CountryId = 4 },
                new Author() { Id = 5, Name = "Arthur",Surname = "Conan Doyle", Birthdate = DateTime.Now, CountryId = 3 },
                new Author() { Id = 6, Name = "fwefw",Surname = "fowrtef", Birthdate = DateTime.Now, CountryId = 2 }
            });
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book() { Id = 1, Name = "MyBook1", PageNumber = 210, PublishingDate = DateTime.Now, GenreId = 1, PublishingId = 1, AuthorId = 1 },
                new Book() { Id = 2, Name = "Harry poter", PageNumber = 310, PublishingDate = DateTime.Now, GenreId = 5, PublishingId = 2, AuthorId = 3 }
            });
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
                new Client() { Id = 1, Name = "Max", Surname = "Mozgov", Phone = "380634453876"},
                new Client() { Id = 2, Name = "Lena", Surname = "Orlova", Phone = "380235695697"},
                new Client() { Id = 3, Name = "Mark", Surname = "Krob", Phone = "380525612845"},
            });
            modelBuilder.Entity<Goods>().HasData(new Goods[]
            {
                new Goods() { Id = 1, BookId = 1, Cost = 100, Price = 150, Discount = 0, Number = 30, WriteOffGoods = false},
                new Goods() { Id = 2, BookId = 2, Cost = 120, Price = 190, Discount = 5, Number = 76, WriteOffGoods = false}, 
            });
            modelBuilder.Entity<PublishingHouse>().HasData(new PublishingHouse[]
            {
                new PublishingHouse() { Id = 1, Name = "FisrtPublishingHouse" },
                new PublishingHouse() { Id = 2, Name = "Second" },
                new PublishingHouse() { Id = 3, Name = "ThirdPB" },
                new PublishingHouse() { Id = 4, Name = "Four" },
                new PublishingHouse() { Id = 5, Name = "fewfwe" },
                new PublishingHouse() { Id = 6, Name = "[wetfpjwerg" }
            });
            modelBuilder.Entity<DeferredBook>().HasData(new DeferredBook[]
            {
                new DeferredBook() { Id = 1, ClientId = 1, GoodsId = 1 },
                new DeferredBook() { Id = 2, ClientId = 3, GoodsId = 2  },
            });
            modelBuilder.Entity<Sale>().HasData(new Sale[]
            {
                new Sale() { Id = 1, ClientId = 1, GoodsId = 1 },
                new Sale() { Id = 2, ClientId = 3, GoodsId = 2  },
            });
        }
    }
}

