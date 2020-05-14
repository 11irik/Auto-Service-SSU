using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface ICarDao
    {
        Car Create(long clientId, string number);
        Car Get(string number);
        IEnumerable<Car> GetAll();
        int Delete(string number);
    }
}