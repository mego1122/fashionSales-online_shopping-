using FashionSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionSales.Data.interfaces
{
   public interface IProviderCategoryRepository
    {
        Task<bool> Add(Provider_Category pv);

        Task<bool> Update(Provider_Category prvcat);

        Task<bool> Delete(Provider_Category prvcat);

      

    }
}
