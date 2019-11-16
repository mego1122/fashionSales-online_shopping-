using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionSales.Helpers;
using FashionSales.Models;
using Microsoft.EntityFrameworkCore;
using FashionSales.Data;
using Microsoft.VisualBasic;

namespace FashionSales.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Product Product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Product Product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product Product)
        {
            throw new NotImplementedException();
        }
    }
}