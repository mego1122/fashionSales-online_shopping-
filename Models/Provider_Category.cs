using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Provider_Category
    {
        [ForeignKey("provider")]
        public int? ProviderId { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public Provider provider { get; set; }
    }
}
