using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeForCoffee.Models.DTOs
{
    public class CafeSimpleDTO
    {
        public string Name { get; set; }

        public float Rating { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }
    }
}
