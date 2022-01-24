using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Repository.GenericRepository;

namespace TimeForCoffee.Repository.BaristaRepository
{
    public interface IBaristaRepository:IGenericRepository<Barista>
    {
        List<Barista> GetByCafe(string cafe);

        Barista GetByName(string name);
    }
}
