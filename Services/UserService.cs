using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Models.DTOs;
using TimeForCoffee.Repository.UserRepository;

namespace TimeForCoffee.Services
{
   public class UserService : IUserService
    {

        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetUserMappedByUsername(string name)
        {
            User user = _userRepository.GetByUsername(name);

            UserDTO result = new UserDTO
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName

            };

            return result;
        }

    }


       


}


        


