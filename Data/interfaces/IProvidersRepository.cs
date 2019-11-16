using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface IProvidersRepository
    {

        Task<bool> Add(Provider Provider);

        Task<bool> Update(Provider Provider);

        Task<bool> Delete(Provider Provider);

        Provider Get(int id);

        Task<List<Provider>> GetByName(string Name);

        Task<List<Provider>> Get();
    }
}