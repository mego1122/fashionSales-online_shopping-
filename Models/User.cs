using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using FashionSales.Models;

namespace FashionSales.Models
{
    public class User : IdentityUser<int>
    {
       
        public byte[] PasswordSalt { get; set; }

        public string LocationLong { get; set; }
        public string LocationLatt { get; set; }

        public string Address { get; set; }
        public string Description { get; set; }

        public string PhotoUrl { get; set; }



        public int MobileNumber { get; set; }

        public string Government { get; set; }





        public ICollection<UserRole> UserRoles { get; set; }
    }
}