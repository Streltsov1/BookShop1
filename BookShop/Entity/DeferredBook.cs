using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class DeferredBook : IEntity
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public Goods Goods { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
