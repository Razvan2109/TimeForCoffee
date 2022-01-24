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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewServices;

        public ReviewController(IReviewService reviewService)
        {
            _reviewServices = reviewService;
        }

        [HttpPost("AddReview")]
        public IActionResult AddReview(ReviewDTO toAdd)
        {
            try
            {
                var result = _reviewServices.CreateReview(toAdd);
                return Ok(result);

            }catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteReview")]
        public IActionResult DeleteReviews(string name, string cafe)
        {
            try
            {
                var result = _reviewServices.DeleteReviews(name,cafe);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpGet("GetAllReviewsFromCafe")]
        public IActionResult GetAllReviewsForCafe(string cafe)
        {
            try
            {
                var result = _reviewServices.GetAllReviewsForCafe(cafe);
                return Ok(result);

            }catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdatePreviousReviews")]
        public IActionResult UpdatePreviousReviews(string name, string cafe, string text, int score)
        {
            try
            {
                var result = _reviewServices.UpdatePreviousReviews(name,cafe,text,score);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        
    }
}
