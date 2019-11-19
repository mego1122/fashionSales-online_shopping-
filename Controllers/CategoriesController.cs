using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionSales.Data;
using FashionSales.Models;

namespace FashionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

    

        public ICategoriesRepository CategoriesRepository;

        public CategoriesController(ICategoriesRepository _CategoryRepository)
        {
            CategoriesRepository = _CategoryRepository;
        }



        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await CategoriesRepository.Get();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody]Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categId = await CategoriesRepository.Add(model);
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

        [HttpPost]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            bool result = false;

            if (category == null)
            {
                return BadRequest();
            }

            try
            {
                result = await CategoriesRepository.Delete(category);
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
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody]Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await CategoriesRepository.Update(model);

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



