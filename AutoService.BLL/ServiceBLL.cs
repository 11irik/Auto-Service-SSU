using System;
using System.Collections;
using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ServiceBLL : IServiceBLL
    {
        private IServiceDao _serviceDao;
        // private IServiceEmployeesDao _serviceEmployeesDao;


        public ServiceBLL()
        {
            _serviceDao = new ServiceDao();
            // _serviceEmployeesDao = new ServiceEmployeesDao();

        }
        
        public Service Create(string name, double price)
        {
            return _serviceDao.Create(name, price);
        }

        public IEnumerable<Service> GetAll()
        {
            return _serviceDao.GetAll();
        }

      

        public int Delete(long id)
        {
            return _serviceDao.Delete(id);
        }

        // public ServiceEmployee WriteEmployee(long serviceId, long employeeId)
        // {
        //     return _serviceEmployeesDao.Create(serviceId, employeeId);
        // }

        // public int WriteOutEmployee(long serviceId, long employeeId)
        // {
        //     return _serviceEmployeesDao.Delete(serviceId, employeeId);
        // }
        //
        // public IEnumerable<Employee> GetAllByService(long serviceId)
        // {
        //     throw new NotImplementedException();
        // }
    }
}