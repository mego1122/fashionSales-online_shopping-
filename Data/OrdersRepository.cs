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
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DataContext _context;
        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Order Order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Order Order)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Order Order)
        {
            throw new NotImplementedException();
        }
    }
}