using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class ExtraAdds
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
        public ICollection<ProductExtraAdds> ProductExtraAdds { get; set; }



    }
}
