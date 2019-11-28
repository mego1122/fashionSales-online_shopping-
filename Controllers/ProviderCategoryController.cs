using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FashionSales.Data.interfaces;
using FashionSales.Models;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Roles = "provider")]
        [HttpPost]
        //[Route("Addprovcateg")]
        public async Task<IActionResult> Postprovcateg(Provider_Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    int pid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                    Provider_Category prvcat = new Provider_Category() { ProviderId =pid, CategoryId = 0 };

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

      

        //delete provcateg
        [HttpDelete]
        [Authorize(Roles = "provider")]
        //  [Route("UpdateCategory")]
        public async Task<IActionResult> Delete(int categId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int pid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                    Provider_Category prvcat = new Provider_Category() { ProviderId = pid, CategoryId = categId };

                    await ProviderCategoryRepository.Delete(prvcat);

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