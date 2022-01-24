using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Repository.GenericRepository;

namespace TimeForCoffee.Repository.ReviewRepository
{
    public interface IReviewRepository:IGenericRepository<Review>
    {
        List<Review> GetReviewsWithGreaterRating(int rating);

        public List<Review> GetReviewsWithPlaceAndUser(int rating);

    }
}
