using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.BaseEntity;

namespace TimeForCoffee.Models
{
    public class User:BaseEntity.BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}
