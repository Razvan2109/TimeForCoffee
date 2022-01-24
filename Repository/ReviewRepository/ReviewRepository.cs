using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Repository.GenericRepository;
using TimeForCoffee.Models;
using TimeForCoffee.Data;
using Microsoft.EntityFrameworkCore;

namespace TimeForCoffee.Repository.ReviewRepository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {

        public ReviewRepository(TimeForCoffeeContext context) : base(context)
        {

        }
        public List<Review> GetReviewsWithGreaterRating(int rating)
        {
            var QueryResult = (from r in _context.Reviews
                               join c in _context.Cafes
                               on r.CafeId equals c.Id
                               join u in _context.Users
                               on r.UserId equals u.Id
                               where r.score > rating
                               select r).AsEnumerable();
            return QueryResult.ToList();
        }
        public List<Review> GetReviewsWithPlaceAndUser(int rating)
        {
            var QueryResult = (from r in _context.Reviews
                               join c in _context.Cafes
                               on r.CafeId equals c.Id
                               join u in _context.Users
                               on r.UserId equals u.Id
                               select r).AsEnumerable();
            return QueryResult.ToList();
        }

    }
}
