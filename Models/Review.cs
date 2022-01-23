using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.BaseEntity;

namespace TimeForCoffee.Models
{
    public class Review : BaseEntity.BaseEntity
    {

        public User User { get; set; }

        public Guid UserId { get; set; }

        public Cafe Cafe { get; set; }

        public Guid CafeId { get; set; }

        public string Text { get; set; }

        public int score { get; set; }

    }
}
