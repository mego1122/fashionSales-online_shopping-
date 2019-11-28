using FashionSales.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionSales.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}



        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductExtraAdds> ProductExtraAdds { get; set; }
        public DbSet<ExtraAdds> ExtraAdds { get; set; }
     

        public DbSet<Provider_Category> Provider_Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderProduct>().HasKey(ba => new { ba.OrderId, ba.ProductId });
            builder.Entity<Provider_Category>().HasKey(ba => new { ba.CategoryId, ba.ProviderId });
            builder.Entity<ProductExtraAdds>().HasKey(ba => new { ba.ExtraAddId, ba.ProductId });

            //builder.Entity<Provider_Category>().HasOne(b => b.provider).WithMany(c => c.Provider_Category).HasForeignKey(c => c.ProviderId);
            //builder.Entity<Provider_Category>().HasOne(b => b.Category).WithMany(c => c.Provider_Category).HasForeignKey(c => c.CategoryId);



            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<OrderProduct>().HasKey(c => new { c.ProductId, c.OrderId });

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });

        }
    }
}