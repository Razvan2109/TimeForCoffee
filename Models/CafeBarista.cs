using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeForCoffee.Models
{
    public class CafeBarista
    {
        public Guid CafeId { get; set; }
        public Cafe Cafe { get; set; }
        public Guid BaristaId { get; set; }
        public Barista Barista { get; set; }
    }
}
