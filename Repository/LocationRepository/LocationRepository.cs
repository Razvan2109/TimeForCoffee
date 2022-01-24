using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Repository.GenericRepository;
using TimeForCoffee.Models;
using TimeForCoffee.Data;
using Microsoft.EntityFrameworkCore;


namespace TimeForCoffee.Repository.LocationRepository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(TimeForCoffeeContext context) : base(context)
        {

        }

        public Location GetByAddress(string address)
        {
            var QueryResult = (from l in _context.Locations
                               where l.Address.Equals(address)
                               select l).FirstOrDefault();
            return QueryResult;
        }

        public List<Location> GetByCountry(string country)
        {
            var QueryResult = (from l in _context.Locations
                               where l.Country.Equals(country)
                               select l).AsEnumerable();

            return QueryResult.ToList();
        }
    }
}
