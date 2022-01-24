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

        [HttpPost("DeleteCafe")]
        publicIactionResult DeleteCafeByName(string toDelete)
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
    }
}
