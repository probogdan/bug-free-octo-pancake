using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _IBS_VetPlus.Models
{
    public class OrderViewModel
    {
        public Guid BuyerId { get; set; }

        public Guid ItemId { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public int Price { get; set; }
    }
}