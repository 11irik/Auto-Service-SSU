using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IServiceCoefficientBLL
    {
        ServiceCoefficient Create(string name, double coefficient);
        IEnumerable<ServiceCoefficient> GetAll();
        int Delete(long id);
    }
}