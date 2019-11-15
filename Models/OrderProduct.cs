using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public int Quantity { get; set; }
        public Order Order { get; set; }
        public  Product Product { get; set; }

}
}
