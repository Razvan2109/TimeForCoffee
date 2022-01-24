using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.DTOs;
using TimeForCoffee.Services;

namespace TimeForCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly ICafeService _cafeServices;

        public CafeController(ICafeService cafeService)
        {
            _cafeServices = cafeService;
        }

        [HttpPost("CreateCafe")]
        public IActionResult CreateCafe(CafeSimpleDTO toCreate)
        {
            try
            {
                var result = _cafeServices.CreateCafe(toCreate);
                return Ok(result);


            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteCafe")]
        public IActionResult DeleteCafeByName(string toDelete)
        {
            try
            {
                var result = _cafeServices.DeleteCafeByName(toDelete);
                return Ok(result);


            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetCafesByRating")]
        public IActionResult GetCafesByRating(float minRating)
        {
            try
            {
                var result = _cafeServices.GetCafesByRating(minRating);
                return Ok(result);


            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateCafeLocation(string name,string newAddress)
        {
            try
            {
                var result = _cafeServices.UpdateCafeLocation(name, newAddress);
                return Ok(result);


            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("ChangeCafeName")]
        public IActionResult ChangeCafeName(string oldName, string newName)
        {
            try
            {
                var result = _cafeServices.ChangeCafeName(oldName, newName);
                return Ok(result);


            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
