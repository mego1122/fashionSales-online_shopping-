using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface ISubCategoriesRepository
    {
        Task<bool> Add(SubCategory category);

        Task<bool> Update(SubCategory category);

        Task<bool> Delete(SubCategory category);

        SubCategory Get(int id);

        Task<List<SubCategory>> GetByName(string Name);

        Task<List<SubCategory>> Get();

    }
}