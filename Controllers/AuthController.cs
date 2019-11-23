using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FashionSales.Data;
using FashionSales.Dtos;
using FashionSales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace FashionSales.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _dataContext;

        public AuthController(IConfiguration config,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            DataContext dataContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _dataContext = dataContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = await _userManager.FindByNameAsync(userForRegisterDto.UserName);
            if(userExist != null)
            {
                return BadRequest("usernameExists");

            }
            var phoneExist = await _dataContext.Users.AnyAsync(u => u.PhoneNumber == userForRegisterDto.PhoneNumber);
            if (phoneExist)
            {
                return BadRequest("phoneExist");

            }
            var userToCreate = _mapper.Map<User>(userForRegisterDto);
            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

            var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
             
            }
            
            var user = await _userManager.FindByNameAsync(userToCreate.UserName);

            try
            {
                result = await _userManager.AddToRolesAsync(user, userForRegisterDto.Roles.Distinct());
                if (!result.Succeeded)
                {
                    await DeleteUserAsync(user);
                    return BadRequest();

                }
            }
            catch
            {
                await DeleteUserAsync(user);
                throw;
            }
            
            return CreatedAtRoute("GetUser",
                    new { controller = "Users", id = userToCreate.Id }, userToReturn);
        }
        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(int userId)
        {
            var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
                return await DeleteUserAsync(user);

            return (true, new string[] { });
        }


        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
            if(user == null)
            {
                return NotFound("userNotExists");
            }
            var result = await _signInManager
                .CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.Username.ToUpper());

                var userToReturn = _mapper.Map<UserForListDto>(appUser);
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new
                {
                    access_token = GenerateJwtToken(appUser).Result,
                    user = userToReturn,
                    roles
            });
            }

            return Unauthorized("wrongPassword");
        }
        [HttpPost("logout")]
        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("You Logged Out!");
        }
        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(100),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}