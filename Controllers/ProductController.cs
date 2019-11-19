using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionSales.Data;
using FashionSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private IProductsRepository ProductssRepository;

        public ProductController(IProductsRepository _ProductssRepository)
        {
            ProductssRepository = _ProductssRepository;
        }



        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var products = await ProductssRepository.Get();
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

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var prod = await ProductssRepository.Add(model);
                    if (prod == true)
                    {
                        return Ok(prod);
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

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            bool result = false;

            if (product == null)
            {
                // return BadRequest();
                return NotFound();
            }

            try
            {
                result = await ProductssRepository.Delete(product);
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


        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ProductssRepository.Update(model);

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



