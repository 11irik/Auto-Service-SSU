using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IEmployeeDao
    {
        Employee Create(string name, string lastName, double salary);
        IEnumerable<Employee> GetAll();
        int Delete(long id);
    }
}