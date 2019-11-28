using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionSales.Helpers;
using FashionSales.Models;
using Microsoft.EntityFrameworkCore;
using FashionSales.Data;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace FashionSales.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Product Product)
        {
          
            try
            {
                await _context.Products.AddAsync(Product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Product Product)
        {
            try
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

      
      

        public async Task<List<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
           return await _context.Products.SingleOrDefaultAsync(a => a.Id == id); 
        }

        public async Task<bool> Update(Product Product)
        {


            try
            {
                 _context.Products.Update(Product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}