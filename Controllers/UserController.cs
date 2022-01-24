using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Services;
using TimeForCoffee.Models.DTOs;
using TimeForCoffee.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace TimeForCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        private readonly IConfiguration _config;

        public UserController(IUserService userService,IConfiguration config)
        {
            _userServices = userService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserLoginDTO login)
        {
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if(user != null)
            {
                var tokenStr = GenerateToken(user);
                return Ok(tokenStr);
            }
            return NotFound("User not found");
        }

        private string GenerateToken(User user)
        {
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(UserLoginDTO login)
        {
            var current = _userServices.GetCredentials(login.Username,login.Password);

            if (current != null)
            {
                return current;
            }

            return null;
        }

        [HttpGet("GetByUsername")]
        public IActionResult GetByUsername(string name)
        {
            var result = _userServices.GetUserMappedByUsername(name);
            return Ok(result);
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var result = _userServices.GetAllUsers();
            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserDtoCreate toCreate) {
            try
            {
                var result = _userServices.CreateUser(toCreate);
                return Ok(result);


            }catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteByUsername")]
        public IActionResult DeleteUserByUsername(string name)
        {
            try
            {
                var result=_userServices.DeleteByUsername(name);
                return Ok(result);
               

            }catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUserName(string username,string firstName,string lastName)
        {
            try
            {
                var result = _userServices.UpdateUserName(username,firstName,lastName);
                return Ok(result);


            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }



    }
}
