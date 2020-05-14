using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IEmployeeBLL
    {
        Employee Create(string name, string lastName, double salary);
        IEnumerable<Employee> GetAll();
        int Delete(long id);
    }
}