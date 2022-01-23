using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.BaseEntity;

namespace TimeForCoffee.Models
{
    public class Barista:BaseEntity.BaseEntity
    {
        public string Name { get; set; }
    
        public string Speciality { get; set; }

        public ICollection<Cafe> Cafes { get; set; }
    
    }
}
