using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IServiceBLL
    {
        Service Create(string name, double price);
        IEnumerable<Service> GetAll();
        int Delete(long id);
    }
}