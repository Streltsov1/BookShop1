using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public interface IUoW
    {
        IRepository<Book> BookRepo { get; }
        IRepository<Author> AuthorRepo { get; }
        IRepository<Country> CountryRepo { get; }
        IRepository<Client> ClientRepo { get; }
        IRepository<Goods> GoodsRepo { get; }
        IRepository<DeferredBook> DeferredBookRepo { get; }
        IRepository<Genre> GenreRepo { get; }
        IRepository<PublishingHouse> PublishingRepo { get; }
        IRepository<Sale> SaleRepo { get; }
        void Save();
    }

    public class UnitOfWork : IUoW, IDisposable
    {
        private static BookShopDbContext context = new BookShopDbContext();
        private IRepository<Book>? bookRepo = null;
        private IRepository<Author>? authorRepo = null;
        private IRepository<Country>? countryRepo = null;
        private IRepository<Client>? clientRepo = null;
        private IRepository<Goods>? goodsRepo = null;
        private IRepository<DeferredBook>? deferredBookRepo = null;
        private IRepository<Genre>? genreRepo = null;
        private IRepository<PublishingHouse>? publishingRepo = null;
        private IRepository<Sale>? saleRepo = null;

        public IRepository<Book> BookRepo
        {
            get
            {
                if (this.bookRepo == null)
                {
                    this.bookRepo = new Repository<Book>(context);
                }
                return bookRepo;
            }
        }
        public IRepository<Author> AuthorRepo
        {
            get
            {
                if (this.authorRepo == null)
                {
                    this.authorRepo = new Repository<Author>(context);
                }
                return authorRepo;
            }
        }
        public IRepository<Country> CountryRepo
        {
            get
            {
                if (this.countryRepo == null)
                {
                    this.countryRepo = new Repository<Country>(context);
                }
                return countryRepo;
            }
        }
        public IRepository<Client> ClientRepo
        {
            get
            {
                if (this.clientRepo == null)
                {
                    this.clientRepo = new Repository<Client>(context);
                }
                return clientRepo;
            }
        }
        public IRepository<Goods> GoodsRepo
        {
            get
            {
                if (this.goodsRepo == null)
                {
                    this.goodsRepo = new Repository<Goods>(context);
                }
                return goodsRepo;
            }
        }
        public IRepository<DeferredBook> DeferredBookRepo
        {
            get
            {
                if (this.deferredBookRepo == null)
                {
                    this.deferredBookRepo = new Repository<DeferredBook>(context);
                }
                return deferredBookRepo;
            }
        }
        public IRepository<Genre> GenreRepo
        {
            get
            {
                if (this.genreRepo == null)
                {
                    this.genreRepo = new Repository<Genre>(context);
                }
                return genreRepo;
            }
        }
        public IRepository<PublishingHouse> PublishingRepo
        {
            get
            {
                if (this.publishingRepo == null)
                {
                    this.publishingRepo = new Repository<PublishingHouse>(context);
                }
                return publishingRepo;
            }
        }
        public IRepository<Sale> SaleRepo
        {
            get
            {
                if (this.saleRepo == null)
                {
                    this.saleRepo = new Repository<Sale>(context);
                }
                return saleRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
