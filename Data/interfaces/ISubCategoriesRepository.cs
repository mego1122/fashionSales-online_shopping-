using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FashionSales.Helpers;
using FashionSales.Models;

namespace FashionSales.Data
{
    public interface ISubCategoriesRepository
    {
        Task<bool> Add(SubCategory SubCategory);

        Task<bool> Update(SubCategory SubCategory);

        Task<bool> Delete(SubCategory SubCategory);

        SubCategory Get(int id);

        Task<List<SubCategory>> GetByName(string Name);

        Task<List<SubCategory>> Get();

    }
}