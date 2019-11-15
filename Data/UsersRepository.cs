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
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

     

        public async Task<User> GetUser(int id, bool isCurrentUser)
        {
            var query = _context.Users.AsQueryable();

            if (isCurrentUser)
                query = query.IgnoreQueryFilters();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}