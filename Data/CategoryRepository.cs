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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;
        public CategoriesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Category category)
        {
            try
            {
                if (_context != null)
                {
                    await _context.Categories.AddAsync(category);
                    await _context.SaveChangesAsync();
                }
                 
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

  
        public Category Get(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }

        public async Task< Category> Gett(int id)
        {
            return await  _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }


        public async Task<List<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }



        public async Task<List<Category>> GetByName(string Name)
        {
            return await _context.Categories.Where(c => c.Name == Name).ToListAsync();
        }



        public async Task<bool> Update(Category category)
        {
           

            try
            {
                var categoryToUpdate = this.Get(category.Id);
                categoryToUpdate.Name = category.Name;
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