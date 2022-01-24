using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Repository.GenericRepository;

namespace TimeForCoffee.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string username);
        User GetByUsernameIncludingReviews(string username);
        List<User> GetAllWithReviews_Include();
        List<User> GetAllWithReviews_Join();
       
    }

   
}
