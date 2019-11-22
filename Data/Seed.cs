using System.Collections.Generic;
using System.Linq;
using FashionSales.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace FashionSales.Data
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                
                var roles = new List<Role>
                {
                    new Role{Name = "Admin"},
                    new Role{Name = "customer"},
                    new Role{Name = "provider"},
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

             

                var adminUser = new User
                {
                    UserName = "Admin"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "pass@123").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
                }
                
            }
        }
    }
}