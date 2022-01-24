using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeForCoffee.Models.DTOs
{
    public class ReviewDTO
    {
        public string Username { get; set; }
        public string Cafe { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }

    }
}
