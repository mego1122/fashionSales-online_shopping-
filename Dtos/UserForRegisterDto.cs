using System;
using System.ComponentModel.DataAnnotations;

namespace FashionSales.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [MinLength(4)]

        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PhoneNumber at least 11 numbers")]
        public string PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string[] Roles { get; set; }
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}