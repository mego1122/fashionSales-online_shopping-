using FashionSales.Data.interfaces;
using FashionSales.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Internal;

namespace FashionSales.Data
{
    public class ProviderCategoryRepository : IProviderCategoryRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //constructor then
        

        private readonly DataContext _context;
        public ProviderCategoryRepository(DataContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> Add(Provider_Category pv)
        {
            try
            {
                
                int lastCategorytId = _context.Categories.Max(item => item.Id);
                pv.CategoryId = lastCategorytId;

              
           



                if (_context != null)
                {
                    await _context.Provider_Categories.AddAsync(pv);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Provider_Category prvcat)
        {
            try
            {

                _context.Provider_Categories.Remove(prvcat);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

  
        public async Task<bool> Update(Provider_Category prvcat)
        {

            try
            {
                var prvcatToUpdate = _context.Provider_Categories.Update(prvcat);
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
