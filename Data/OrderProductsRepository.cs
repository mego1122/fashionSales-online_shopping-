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
    public class OrderProductsRepository : IOrderProductsRepository
    {
        private readonly DataContext _context;
        public OrderProductsRepository(DataContext context)
        {
            _context = context;
        }
       
    }
}