using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }




    }
}
