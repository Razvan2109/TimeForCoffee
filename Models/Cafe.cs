using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.BaseEntity;

namespace TimeForCoffee.Models
{
    public class Cafe:BaseEntity.BaseEntity
    {
        public string Name { get; set; }

        public float Rating { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public virtual Location Location { get; set; }

        public ICollection<Barista> Baristas { get; set; }

    }
}
