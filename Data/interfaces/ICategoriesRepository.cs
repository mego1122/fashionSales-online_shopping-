using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface ICategoriesRepository
    {
        Task<bool> Add(Category category);

        Task<bool> Update(Category category);

        Task<bool> Delete(Category category);

         Category Get(int id);

        Task<List<Category>> GetByName(string Name);

        Task<List<Category>> Get();

    }
}