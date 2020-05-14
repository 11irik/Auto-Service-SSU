using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ServiceBLL : IServiceBLL
    {
        private IServiceDao _dao;

        public ServiceBLL()
        {
            _dao = new ServiceDao();
        }
        
        public Service Create(string name, double price)
        {
            return _dao.Create(name, price);
        }

        public IEnumerable<Service> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(long id)
        {
            return _dao.Delete(id);
        }
    }
}