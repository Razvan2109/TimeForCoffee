using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Models.DTOs;
using TimeForCoffee.Repository.CafeRepository;
using TimeForCoffee.Repository.LocationRepository;

namespace TimeForCoffee.Services
{
    public class CafeService : ICafeService
    {


        public ICafeRepository _cafeRepository;
        public ILocationRepository _locationRepository;

        public CafeService(ICafeRepository cafeRepository,ILocationRepository locationRepository)
        {
            _cafeRepository = cafeRepository;
            _locationRepository = locationRepository;
        }

        public CafeSimpleDTO CreateCafe(CafeSimpleDTO cafeToCreate)
        {

            Location newLocation = new Location
            {
                Address = cafeToCreate.Address,
                Country = cafeToCreate.Country,
                DateCreated = DateTime.Now
            };

            _locationRepository.Create(newLocation);
            _locationRepository.Save();

            Cafe newCafe = new Cafe
            {
                Name = cafeToCreate.Name,
                Rating = cafeToCreate.Rating,
                DateCreated = DateTime.Now,
                LocationId=newLocation.Id
                
            };

            _cafeRepository.Create(newCafe);

            _cafeRepository.Save();
            

            CafeSimpleDTO cafe = new CafeSimpleDTO
            {
                Name = newCafe.Name,
                Rating = newCafe.Rating,
                Address = newCafe.Location.Address,
                Country = newCafe.Location.Country
            };

            return cafe;



        }
    }
}
