using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.DTOs;

namespace TimeForCoffee.Services
{
    public interface IReviewService
    {
        public ReviewDTO CreateReview(ReviewDTO reviewToCreate);

        public List<ReviewDTO> DeleteReviews(string name, string cafe);

        public List<ReviewDTO> GetAllReviewsForCafe(string cafe);

        public List<ReviewDTO> UpdatePreviousReviews(string name, string cafe, string text, int score);

    }
}
