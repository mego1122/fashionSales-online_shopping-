using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface IOrderProductsRepository
    {

        Task<bool> Add(OrderProduct OrderProduct);

        Task<bool> Update(OrderProduct OrderProduct);

        Task<bool> Delete(OrderProduct OrderProduct);

        OrderProduct Get(int id);

        Task<List<OrderProduct>> GetByName(string Name);

        Task<List<OrderProduct>> Get();
    }
}