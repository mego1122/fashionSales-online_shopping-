using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface IProductsRepository
    {

        Task<bool> Add(Product Product);

        Task<bool> Update(Product Product);

        Task<bool> Delete(Product Product);

        Task <Product> Get(int id);


        Task<List<Product>> Get();
    }
}