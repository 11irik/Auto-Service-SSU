using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ServiceCoefficientBLL : IServiceCoefficientBLL
    {
        private IServiceCoefficientDao _dao;

        public ServiceCoefficientBLL()
        {
            _dao = new ServiceCoefficientDao();
        }
        
        public ServiceCoefficient Create(string name, double coefficient)
        {
            return _dao.Create(name, coefficient);
        }

        public IEnumerable<ServiceCoefficient> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(long id)
        {
            return _dao.Delete(id);
        }
    }
}