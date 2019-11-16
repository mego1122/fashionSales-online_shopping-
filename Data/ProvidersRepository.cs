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

      

        public async Task<bool> Add(Provider Provider)
        {
            try
            {
                await _context.Providers.AddAsync(Provider);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Provider Provider)
        {
            try
            {
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Provider Get(int id)
        {
            return _context.Providers.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Provider>> Get()
        {
            return await _context.Providers.ToListAsync();
        }



        public async Task<List<Provider>> GetByName(string Name)
        {
            return await _context.Providers.Where(c => c.UserName == Name).ToListAsync();
        }



        public async Task<bool> Update(Provider Provider)
        {


            try
            {
                var ProviderToUpdate = this.Get(Provider.Id);
                ProviderToUpdate.UserName = ProviderToUpdate.UserName;
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