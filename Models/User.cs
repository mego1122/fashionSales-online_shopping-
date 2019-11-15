using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using FashionSales.Models;

namespace FashionSales.Models
{
    public class User : IdentityUser<int>
    {
       
        public string PhotoUrl { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}