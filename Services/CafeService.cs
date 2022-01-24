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

        public CafeSimpleDTO ChangeCafeName(string oldName, string newName)
        {
            Cafe cafe = _cafeRepository.GetByName(oldName);

            cafe.Name = newName;

            _cafeRepository.Update(cafe);
            _cafeRepository.Save();

            Location loc = _locationRepository.FindById(cafe.LocationId);
            CafeSimpleDTO cafeDto = new CafeSimpleDTO
            {
                Name = cafe.Name,
                Rating = cafe.Rating,
                Address = loc.Address,
                Country = loc.Country
            };

            return cafeDto;
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

        public CafeSimpleDTO DeleteCafeByName(string name)
        {
            Cafe toDelete = _cafeRepository.GetByName(name);

            Guid locationId = toDelete.LocationId;

            Location locToDelete= _locationRepository.FindById(locationId);

            CafeSimpleDTO cafe = new CafeSimpleDTO
            {
                Name = toDelete.Name,
                Rating = toDelete.Rating,
                Address = locToDelete.Address,
                Country = locToDelete.Country
            };

            _locationRepository.Delete(locToDelete);
            _locationRepository.Save();

           /* _cafeRepository.Delete(toDelete);
            _cafeRepository.Save();*/
            

            
            return cafe;
        }

        public List<CafeSimpleDTO> GetCafesByRating(float minRating)
        {
            List<CafeSimpleDTO> sortedCafes = new List<CafeSimpleDTO>();
            List<Cafe> unsortedCafes = _cafeRepository.GetAll().Result;
            foreach(Cafe cafe in unsortedCafes)
            {
                if (cafe.Rating >= minRating)
                {
                    Location location = _locationRepository.FindById(cafe.LocationId);
                    CafeSimpleDTO placeholder = new CafeSimpleDTO
                    {
                        Name = cafe.Name,
                        Rating = cafe.Rating,
                        Address = location.Address,
                        Country = location.Country
                    };

                    sortedCafes.Add(placeholder);
                }
            }

            return sortedCafes;
        }

        public CafeSimpleDTO UpdateCafeLocation(string name, string newAddress)
        {
            Cafe cafe = _cafeRepository.GetByName(name);
            Location cafeLocation = _locationRepository.FindById(cafe.LocationId);

            cafeLocation.Address = newAddress;
            
            _locationRepository.Update(cafeLocation);
            _locationRepository.Save();

            CafeSimpleDTO cafeDto = new CafeSimpleDTO
            {
                Name = cafe.Name,
                Rating = cafe.Rating,
                Address = cafeLocation.Address,
                Country = cafeLocation.Country
            };

            return cafeDto;

        }
    }
}
