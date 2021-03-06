using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface IOrdersRepository
    {

        Task<bool> Add(Order Order);

        Task<bool> Update(Order Order);

        Task<bool> Delete(Order Order);

        Task<Order> Getorder(int id);

        Task<List<Order>> GetByCustomerName(string Name);
        Task<List<Order>> GetorderByCustomer(int id);

        Task<List<Order>> Get();
    }
}