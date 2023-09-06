using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public virtual Goods Goods { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
