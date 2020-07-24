using FashionSales.Data.interfaces;
using FashionSales.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        //public CartRepository(DataContext context)
        //{
        //    _context = context;
        //}
        //public async Task<bool> Add(Cart cart)
        //{
        //    try
        //    {
        //        if (_context != null)
        //        {
        //            await _context.Carts.AddAsync(cart);
        //            await _context.SaveChangesAsync();
        //        }

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> Delete(Cart cart)
        //{
        //    try
        //    {
        //        _context.Carts.Remove(cart);
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> Update(Cart cart)
        //{
        //    try
        //    {
        //        _context.Carts.Update(cart);
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

     

        ////public async Task<Cart> GetById (int id)
        ////{
        ////    return await _context.Carts.SingleOrDefaultAsync(c => c.Id == id);
        ////}

        //public async Task<List<Cart>> Get()
        //{
        //    return await _context.Carts.ToListAsync();
        //}

        //public async Task<List<Cart>> GetCartsByCustomer(int custId)
        //{
        //    return await _context.Carts.Where(a => a.CustomerId == custId).ToListAsync();
        //}
    }
}
