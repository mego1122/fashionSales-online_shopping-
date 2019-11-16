using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }


        public float TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public OrderState State { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

    }

    public enum OrderState
    {
        pending,
        accepted,
        done
    }
}

