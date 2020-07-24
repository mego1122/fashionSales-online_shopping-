using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FashionSales.Data;
using FashionSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {


        private readonly IOrderProductsRepository OrderproductRepository;

        public OrderProductController(IOrderProductsRepository _OrderproductRepository)
        {
            OrderproductRepository = _OrderproductRepository;
        }


        [HttpPost]
        public async Task<IActionResult> postOrderprod(OrderProduct model)
        {
           
            if (ModelState.IsValid)
            {
                try

                {
                   
                    var Order = await OrderproductRepository.Add(model);
                    if (Order == true)
                    {
                        return Ok(Order);
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

    }
}