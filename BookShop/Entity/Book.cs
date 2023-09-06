using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public DateTime PublishingDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int PublishingId { get; set; }
        public virtual PublishingHouse Publishing { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int? NextBookId { get; set; }
        public int? PrevieBookId { get; set; }
        public virtual Book? NextBook { get; set; }
        public virtual Book? PrevieBook { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
