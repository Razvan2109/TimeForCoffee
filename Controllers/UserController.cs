using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Services;
using TimeForCoffee.Models.DTOs;

namespace TimeForCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userService)
        {
            _userServices = userService;
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
