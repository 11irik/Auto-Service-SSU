using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private IEmployeeDao _dao;

        public EmployeeBLL()
        {
            _dao = new EmployeeDao();
        }
        
        public Employee Create(string name, string lastName, double salary)
        {
            return _dao.Create(name, lastName, salary);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(long id)
        {
            return _dao.Delete(id);
        }
    }
}