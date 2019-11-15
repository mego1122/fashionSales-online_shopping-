using System;
using System.Collections.Generic;
using FashionSales.Models;

namespace FashionSales.Dtos
{
    public class UserForDetailedDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }


    }
}