using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }


        public string Location { get; set; }

        public string Address { get; set; }

        public int MobileNum { get; set; }
        public string Description { get; set; }



    }
}
