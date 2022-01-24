using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Repository.GenericRepository;
using TimeForCoffee.Models;
using TimeForCoffee.Data;
using Microsoft.EntityFrameworkCore;

namespace TimeForCoffee.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TimeForCoffeeContext context) : base(context)
        {

        }


        public User GetByUsername(string username)
        {

            var QueryResult = (from u in _table
                               where u.Username.ToLower().Equals(username.ToLower())
                               select u).FirstOrDefault();
            return QueryResult;
        }

        public User GetByUsernameIncludingReviews(string username)
        {
            return _table.Include(x => x.Reviews).FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
        }

        public List<User> GetAllWithReviews_Include()
        {
            return _table.Include(x => x.Reviews).ToList();
        }

        public List<User> GetAllWithReviews_Join()
        {
            var queryResult = _table.Join(_context.Reviews,
                u => u.Id,
                r => r.UserId,
                (u, r) => new { u, r }).Select(o => o.u);

            return queryResult.ToList();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var queryResult = (from u in _table
                               where u.Username.ToLower().Equals(username.ToLower())
                               select u).FirstOrDefault();

           if( BCrypt.Net.BCrypt.Verify(password, queryResult.Password))
            {
                return queryResult;
            }

            return null;


        }
    }
}
