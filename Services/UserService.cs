using Microsoft.AspNetCore.Http;
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

        public UserDTO CreateUser(UserDtoCreate toCreate)
        {
            User user = new User
            {
                Username = toCreate.username,
                FirstName = toCreate.firstName,
                LastName = toCreate.lastName,
                Email = toCreate.email,
                Password = BCrypt.Net.BCrypt.HashPassword(toCreate.password),
                DateCreated=DateTime.Now,
                Role="User"
            };

          

            _userRepository.Create(user);

            _userRepository.Save();

            UserDTO userDTO = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
            };

            return userDTO;



        }

        public UserDTO DeleteByUsername(string name)
        {
            User toDelete = _userRepository.GetByUsername(name);
            _userRepository.Delete(toDelete);

            _userRepository.Save();

            UserDTO result = new UserDTO
            {
                Username = toDelete.Username,
                FirstName = toDelete.FirstName,
                LastName = toDelete.LastName

            };

            return result;


        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> users=new List<UserDTO>();
            List<User> usersDetailed= _userRepository.GetAll().Result;

            foreach(User user in usersDetailed)
            {
                UserDTO userDTO = new UserDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username
                };
                users.Add(userDTO);
            }

            return users;
        }

        public User GetCredentials(string username, string password)
        {
            User user = _userRepository.GetByUsernameAndPassword(username, password);

            return user;
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

        public UserDTO UpdateUserName(string username,string firstName,string lastName)
        {
            User user = _userRepository.GetByUsername(username);
            user.FirstName = firstName;
            user.LastName = lastName;


            _userRepository.Update(user);
            _userRepository.Save();

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


        


