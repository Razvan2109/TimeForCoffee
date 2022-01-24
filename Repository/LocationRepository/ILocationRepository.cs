using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Repository.GenericRepository;

namespace TimeForCoffee.Repository.LocationRepository
{
    public interface ILocationRepository:IGenericRepository<Location>
    {
        List<Location> GetByCountry(string country);

        Location GetByAddress(string address);
    }
}
