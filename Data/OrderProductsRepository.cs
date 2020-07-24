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

        public async Task<bool> Add(OrderProduct OrderProduct)
        {
            try
            {
                int lastorderId = _context.Orders.Where(x=>x.CustomerId==3).Max(item => item.Id);
                OrderProduct.OrderId = lastorderId;
                await _context.OrderProducts.AddAsync(OrderProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(OrderProduct OrderProduct)
        {
            try
            {
                _context.OrderProducts.Remove(OrderProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public async Task<List<OrderProduct>> Get()
        {
            return await _context.OrderProducts.ToListAsync();
        }

        public OrderProduct Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderProduct>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> Update(OrderProduct OrderProduct)
        {


            try
            {
              
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}