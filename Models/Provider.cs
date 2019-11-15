using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Provider : User
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
