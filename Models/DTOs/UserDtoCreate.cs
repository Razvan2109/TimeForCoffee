using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeForCoffee.Models.DTOs
{
    public class UserDtoCreate
    {
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }


    }
}
