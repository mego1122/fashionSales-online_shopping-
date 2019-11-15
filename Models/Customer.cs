using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Customer : User
    {
        public ICollection<Order> Orders { get; set; }
    }
}
