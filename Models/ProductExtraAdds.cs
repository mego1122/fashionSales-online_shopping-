using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class ProductExtraAdds
    {
      
        [Column(Order = 1)]
        [ForeignKey("ExtraAdds")]
        public int ExtraAddId { get; set; }

   
        [Column(Order = 2)]
        [ForeignKey("Product")]

        public int ProductId { get; set; }

        public Product Product { get; set; }
        public ExtraAdds ExtraAdds { get; set; }

    }
}
