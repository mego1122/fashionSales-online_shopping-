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

        public Task<bool> Add(SubCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(SubCategory category)
        {
            throw new NotImplementedException();
        }

        public SubCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategory>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategory>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SubCategory category)
        {
            throw new NotImplementedException();
        }
    }
}