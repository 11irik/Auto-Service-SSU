using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface ICarPartDao
    {
        CarPart Create(string name, long manufacturerId, double price, int stock);
        IEnumerable<CarPart> GetAll();
        int Delete(long id);
    }
}