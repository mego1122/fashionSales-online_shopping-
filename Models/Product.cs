﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public int SubCategoryId { get; set; }

        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }




    }
}
