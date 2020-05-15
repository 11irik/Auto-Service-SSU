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


        public ServiceBLL()
        {
            _serviceDao = new ServiceDao();

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
    }
}