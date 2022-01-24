using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Repository.GenericRepository;
using TimeForCoffee.Models;
using TimeForCoffee.Data;
using Microsoft.EntityFrameworkCore;


namespace TimeForCoffee.Repository.CafeRepository
{
    public class CafeRepository : GenericRepository<Cafe>, ICafeRepository
    {
        public CafeRepository(TimeForCoffeeContext context) : base(context)
        {

        }

        public List<Cafe> GetByMinRating(int minRating)
        {
            
            var QueryResult = (from c in _context.Cafes
                               join l in _context.Locations
                               on c.Location equals l
                               where c.Rating > minRating
                               select c).AsEnumerable();

            return QueryResult.ToList();
        }

        public Cafe GetByName(string name)
        {
            var QueryResult = (from c in _context.Cafes
                               where c.Name.Equals(name)
                               select c).FirstOrDefault();

            return QueryResult;
        }
    }
}
