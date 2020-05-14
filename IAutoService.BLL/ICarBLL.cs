using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface ICarBLL
    {
        Car Create(long clientId, string number);
        Car Get(string number);
        IEnumerable<Car> GetAll();
        int Delete(string number);
    }
}