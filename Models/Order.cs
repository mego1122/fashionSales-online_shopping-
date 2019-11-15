using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProviderId { get; set; }


        public float TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public ICollection< OrderProduct> OrderProducts { get; set; }

    }
}
