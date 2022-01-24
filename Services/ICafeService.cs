using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models.DTOs;

namespace TimeForCoffee.Services
{
    public interface ICafeService
    {
        CafeSimpleDTO CreateCafe(CafeSimpleDTO cafeToCreate);

        CafeSimpleDTO DeleteCafeByName(string name);

        List<CafeSimpleDTO> GetCafesByRating(float minRating);

        CafeSimpleDTO UpdateCafeLocation(string name, string newAddress);

        CafeSimpleDTO ChangeCafeName(string oldName, string newName);

    }
}
