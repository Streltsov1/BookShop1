using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Goods : IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Number { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public bool WriteOffGoods { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
        public virtual ICollection<DeferredBook> DeferredBooks { get; set; } = new HashSet<DeferredBook>();
    }
}
