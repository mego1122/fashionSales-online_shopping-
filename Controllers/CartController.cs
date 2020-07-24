using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FashionSales.Data;
using FashionSales.Models;
using FashionSales.Data.interfaces;

namespace FashionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //private ICartRepository CartRepository;

        //public CartController(ICartRepository _CartRepository)
        //{
        //    CartRepository = _CartRepository;
        //}




        //[HttpGet("GetCartsByCustomer")]
        //public async Task<IActionResult> GetCartsByCustomer(int custId)
        //{
        //    try
        //    {
        //        var carts = await CartRepository.GetCartsByCustomer(custId);
        //        if (carts == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(carts);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}



        //[HttpGet]
        //public async Task<IActionResult> GetCarts()
        //{
        //    try
        //    {
        //        var carts = await CartRepository.Get();
        //        if (carts == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(carts);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}


        //[HttpGet("GetCartById")]
      
        //public async Task<IActionResult> GetCartById(int id)
        //{
        //    try
        //    {
        //        var cart = await CartRepository.GetById(id);
        //        if (cart == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(cart);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}


        //[HttpPost]
        //public async Task<IActionResult> PostCart(Cart model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            model.CustomerId = 2;
        //            var CartId = await CartRepository.Add(model);
        //            if (CartId == true)
        //            {
        //                return Ok(CartId);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }

        //    }

        //    return BadRequest();
        //}

        //[HttpDelete]

        //public async Task<IActionResult> DeleteCarty(Cart model)
        //{
        //    bool result = false;
        //    try
        //    {
        //        result = await CartRepository.Delete(model);

        //        if (result == false)
        //        {
        //            return NotFound();
        //        }
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }
        //}


        //[HttpPut]
        //public async Task<IActionResult> PutCart([FromBody]Cart model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await CartRepository.Update(model);

        //            return Ok();
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
        //            {
        //                return NotFound();
        //            }

        //            return BadRequest();
        //        }
        //    }

        //    return BadRequest();
        //}
    }
}