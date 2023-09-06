using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
        public virtual ICollection<DeferredBook> DeferredBooks { get; set; } = new HashSet<DeferredBook>();
    }
}
