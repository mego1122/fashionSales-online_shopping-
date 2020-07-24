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

        public async Task<bool> Add(Order Order)
        {
            try
            {
                await _context.Orders.AddAsync(Order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Order Order)
        {
            try
            {
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Order> Getorder(int id)
        {
            return await _context.Orders.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Order Getorderss(int id)
        {
            return _context.Orders.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }


        public async Task <List<Order>> GetorderByCustomer(int id)
        {
            return await _context.Orders.Where(c => c.CustomerId == id).ToListAsync();
        }



        public async Task<List<Order>> GetByCustomerName(string Name)
        {
            return await _context.Orders.Where(c => c.Customer.UserName == Name).ToListAsync();
        }

        //public Task<bool> Update(Order Order)
        //{
        //    throw new NotImplementedException();
        //}



        public async Task<bool> Update(Order Order)
        {
            

            try
            {
                var OrderToUpdate = this.Getorderss(Order.Id);
                OrderToUpdate.CustomerId = Order.CustomerId;
                OrderToUpdate.ProviderId = Order.ProviderId;
                OrderToUpdate.TotalPrice = Order.TotalPrice;
                OrderToUpdate.State = Order.State;
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