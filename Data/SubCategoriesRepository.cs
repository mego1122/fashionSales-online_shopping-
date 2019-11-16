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
    public class SubCategoriesRepository : ISubCategoriesRepository
    {
        private readonly DataContext _context;
        public SubCategoriesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(SubCategory SubCategory)
        {
            try
            {
                await _context.SubCategories.AddAsync(SubCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

      

        public async Task<bool> Delete(SubCategory SubCategory)
        {
            try
            {
                _context.SubCategories.Remove(SubCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SubCategory Get(int id)
        {
            return _context.SubCategories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<SubCategory>> Get()
        {
            return await _context.SubCategories.ToListAsync();
        }


        public async Task<List<SubCategory>> GetByName(string Name)
        {
            return await _context.SubCategories.Where(c => c.Name == Name).ToListAsync();
        }

        public async Task<bool> Update(SubCategory SubCategory)
        {
            try
            {
                var SubcategoryToUpdate = this.Get(SubCategory.Id);
                SubcategoryToUpdate.Name = SubCategory.Name;
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