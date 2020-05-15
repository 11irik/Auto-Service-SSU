using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface ICarBLL
    {
        Car Create(long clientId, string number, string brand, int manufacturerYear);
        Car Get(string number);
        Car Get(long id);

        IEnumerable<Car> GetAll();
        int Delete(string number);
    }
}