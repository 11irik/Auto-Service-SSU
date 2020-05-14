using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface ICarPartBLL
    {
        CarPart Create(string name, long manufacturerId, double price, int stock);
        IEnumerable<CarPart> GetAll();
        int Delete(long id);
    }
}