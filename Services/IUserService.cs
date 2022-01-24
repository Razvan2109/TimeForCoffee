﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.DTOs;

namespace TimeForCoffee.Services
{
    public  interface IUserService
    {

        UserDTO GetUserMappedByUsername(string name);

        UserDTO CreateUser(UserDtoCreate toCreate);

        List<UserDTO> GetAllUsers();

        UserDTO DeleteByUsername(string name);

        UserDTO UpdateUserName(string username,string firstName, string lastName);
    }
}
