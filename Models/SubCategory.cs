using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }


    }
}
