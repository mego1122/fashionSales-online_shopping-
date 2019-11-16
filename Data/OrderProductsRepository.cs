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
    public class OrderProductsRepository : IOrderProductsRepository
    {
        private readonly DataContext _context;
        public OrderProductsRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Add(OrderProduct OrderProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(OrderProduct OrderProduct)
        {
            throw new NotImplementedException();
        }

        public OrderProduct Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderProduct>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderProduct>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(OrderProduct OrderProduct)
        {
            throw new NotImplementedException();
        }
    }
}