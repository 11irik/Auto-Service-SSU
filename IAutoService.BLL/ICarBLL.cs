using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface ICarBLL
    {
        Car Create(long clientId, string number, string brand, int manufacturerYear);
        Car Get(string number);
        Car Get(long id);
        Car Update(long carId, string number, string brand, int manufacturerYear);

        IEnumerable<Car> GetAll();
        int Delete(string number);
    }
}