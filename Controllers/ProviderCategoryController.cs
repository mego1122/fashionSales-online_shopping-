using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionSales.Data.interfaces;
using FashionSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderCategoryController : ControllerBase
    {

        private IProviderCategoryRepository ProviderCategoryRepository;

        public ProviderCategoryController(IProviderCategoryRepository _ProviderCategoryRepository)
        {
            ProviderCategoryRepository = _ProviderCategoryRepository;
        }





        //[HttpPost]
        [HttpPost]
        //[Route("Addprovcateg")]
        public async Task<IActionResult> Postprovcateg(Provider model)
        {
            if (ModelState.IsValid)
            {
                try
                {
               



                    Provider_Category prvcat = new Provider_Category() { ProviderId =1, CategoryId = 0 };

                    var categId = await ProviderCategoryRepository.Add(prvcat);
                    if (categId == true)
                    {
                        return Ok(categId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

      


        [HttpPut]
        //  [Route("UpdateCategory")]
        public async Task<IActionResult> Putprovcateg([FromBody]Provider_Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ProviderCategoryRepository.Update(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}