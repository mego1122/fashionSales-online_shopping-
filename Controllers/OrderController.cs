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
    public class OrderController : ControllerBase
    {

        private readonly IOrdersRepository OrdersRepository;

        public OrderController(IOrdersRepository _OrderRepository)
        {
            OrdersRepository = _OrderRepository;
        }


        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrdrs()
        {
            try
            {
                var Ordrs = await OrdersRepository.Get();
                if (Ordrs == null)
                {
                    return NotFound();
                }
                return Ok(Ordrs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetCustomerOrder")]
        public async Task<IActionResult> GetCustomerOrder(int id)
        {
            try
            {
                var Ordrs = await OrdersRepository.GetorderByCustomer(id);
                if (Ordrs == null)
                {
                    return NotFound();
                }
                return Ok(Ordrs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await OrdersRepository.Getorder(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetOrderByName")]
        public async Task<IActionResult> GetOrderByName(string Name)
        {
            try
            {
                var order = await OrdersRepository.GetByCustomerName(Name);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromQuery] int id)
        {
            bool result = false;
            var order = await OrdersRepository.Getorder(id);
            if (order == null)
            {
                return NotFound();
            }

            try
            {
                result = await OrdersRepository.Delete(order);

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
        public async Task<IActionResult> AddOrder(Order model)
        { 
            model.State = OrderState.accepted;
            if (ModelState.IsValid)
            {
                try
                {
                    var OrderId = await OrdersRepository.Add(model);
                    if (OrderId == true)
                    {
                        return Ok(OrderId);
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