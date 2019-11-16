using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface ICustomersRepository
    {
        Task<bool> Add(Customer Customer);

        Task<bool> Update(Customer Customer);

        Task<bool> Delete(Customer Customer);

        Customer Get(int id);

        Task<List<Customer>> GetByName(string Name);

        Task<List<Customer>> Get();

    }
}