using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface ICarDao
    {
        Car Create(long clientId, string number, string brand, int manufacturerYear);
        Car Get(string number);
        Car Get(long id);
        IEnumerable<Car> GetAll();
        IEnumerable<Car> GetAllByClient(long clientId);
        int Delete(string number);
    }
}