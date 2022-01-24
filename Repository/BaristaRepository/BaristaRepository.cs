using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Repository.GenericRepository;
using TimeForCoffee.Models;
using TimeForCoffee.Data;
using Microsoft.EntityFrameworkCore;

namespace TimeForCoffee.Repository.BaristaRepository
{
    public class BaristaRepository : GenericRepository<Barista>, IBaristaRepository

    {
       public BaristaRepository(TimeForCoffeeContext context):base(context)
        {

        }
        
        public List<Barista> GetByCafe(string cafe)
        {
            var QueryResult = (from b in _context.Baristas
                               join cb in _context.CafeBaristas
                               on b.Id equals cb.BaristaId
                               join c in _context.Cafes
                               on cb.CafeId equals c.Id
                               where c.Name.Equals(cafe)
                               select b).AsEnumerable();
            
            return QueryResult.ToList();
        }

        public Barista GetByName(string name)
        {
            var QueryResult = (from b in _context.Baristas
                               where b.Name.Equals(name)
                               select b).FirstOrDefault();
            
            return QueryResult;
        }
    }
}
