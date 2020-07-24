using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FashionSales.Data;
using FashionSales.Dtos;
using FashionSales.Helpers;
using FashionSales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FashionSales.Controllers
{
   // [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        private readonly DataContext _context;



        public UsersController(IUsersRepository repo, IMapper mapper, UserManager<User> userManager, DataContext context)
        {
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
            _context = context;

        }







        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var isCurrentUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == id;

            var user = await _repo.GetUser(id, isCurrentUser);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }








        //[HttpGet("{id}", Name = "Getprovider")]
        //public async Task<IActionResult> Getprovider(int id)
        //{

        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        //    var userToReturn = _mapper.Map<UserForDetailedDto>(user);

        //    return Ok(userToReturn);
        //}











       // [HttpGet("GetUsers")]
        //[HttpGet, Route("GetUsers/{role=role}")]
        [HttpGet("GetUsers")]
   //     [Authorize(Roles = "Admin provider")]
        public async Task<IActionResult> GetUsers(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return Ok(users);
        }






        [HttpDelete("delete/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string username)
        {
            if (username == null)
            {
                return BadRequest("username should not be null!");
            }
            var user = await _userManager.FindByNameAsync(username);
            if (!(user == null))
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok("UserDeleted");
                }
            }
            return NotFound();


        }


    }
}