using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Description;
using FashionSales.Data;
using FashionSales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository ProductsRepository;

        public ProductsController(IProductsRepository _ProductsRepository)
        {
            ProductsRepository = _ProductsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await ProductsRepository.Get();
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getid")]

        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await ProductsRepository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
       
        [HttpPost]
        [Authorize(Roles = "provider")]
        public async Task<IActionResult> PostProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int pid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    model.ProviderId = pid;

                    var ProdId = await ProductsRepository.Add(model);
                    if (ProdId == true)
                    {
                        return Ok(ProdId);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromQuery] Product prod)
        {
            bool result = false;
            
            if (prod == null)
            {
                return NotFound();
            }

            try
            {
                result = await ProductsRepository.Delete(prod);

                if (result == false)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutProduct([FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ProductsRepository.Update(model);

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