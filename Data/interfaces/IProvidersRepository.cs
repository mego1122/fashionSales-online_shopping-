using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface IProvidersRepository
    {

        Task<bool> Add(Provider category);

        Task<bool> Update(Provider category);

        Task<bool> Delete(Provider category);

        Provider Get(int id);

        Task<List<Provider>> GetByName(string Name);

        Task<List<Provider>> Get();
    }
}