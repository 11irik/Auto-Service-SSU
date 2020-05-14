using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IServiceDao
    {
        Service Create(string name, double price);
        IEnumerable<Service> GetAll();
        int Delete(long id);
    }
}