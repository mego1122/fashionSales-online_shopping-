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
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DataContext _context;
        public CustomersRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<bool> Add(Customer Customer)
        {
            try
            {
                await _context.Customers.AddAsync(Customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Customer Customer)
        {
            try
            {
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }



        public async Task<List<Customer>> GetByName(string Name)
        {
            return await _context.Customers.Where(c => c.UserName == Name).ToListAsync();
        }



        public async Task<bool> Update(Customer Customer)
        {


            try
            {
                var CustomerToUpdate = this.Get(Customer.Id);
                CustomerToUpdate.UserName = Customer.UserName;
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