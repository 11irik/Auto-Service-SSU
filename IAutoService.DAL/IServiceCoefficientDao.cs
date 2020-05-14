using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IServiceCoefficientDao
    {
        ServiceCoefficient Create(string name, double coefficient);
        IEnumerable<ServiceCoefficient> GetAll();
        int Delete(long id);
    }
}