using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.BaseEntity;

namespace TimeForCoffee.Models
{
    public class Location:BaseEntity.BaseEntity
    {
        public string Address { get; set; }

        public string Country { get; set; }

        public virtual Cafe Cafe { get; set; }
    }
}
