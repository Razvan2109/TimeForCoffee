using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Repository.GenericRepository;

namespace TimeForCoffee.Repository.CafeRepository
{
    public interface ICafeRepository:IGenericRepository<Cafe>
    {
        Cafe GetByName(string name);

        List<Cafe> GetByMinRating(int minRating);
    }
}
