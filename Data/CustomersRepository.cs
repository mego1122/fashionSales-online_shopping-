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

        public Task<bool> Add(Customer Customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Customer Customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Customer Customer)
        {
            throw new NotImplementedException();
        }
    }
}