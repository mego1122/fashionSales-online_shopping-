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
    public class ProvidersRepository : IProvidersRepository
    {
        private readonly DataContext _context;
        public ProvidersRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Provider category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Provider category)
        {
            throw new NotImplementedException();
        }

        public Provider Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Provider>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Provider>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Provider category)
        {
            throw new NotImplementedException();
        }
    }
}