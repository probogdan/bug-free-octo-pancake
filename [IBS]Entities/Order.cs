using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_Entities
{
    public class Order
    {
        public Guid BuyerId { get; set; }

        public Guid ItemId { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public int Price { get; set; }
    }
}
