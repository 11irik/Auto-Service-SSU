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
        private IContractServicesDao _contractServicesDao;

        public ServiceBLL()
        {
            _serviceDao = new ServiceDao();
            _contractServicesDao = new ContractServicesDao();
        }
        
        public Service Create(string name, double price)
        {
            return _serviceDao.Create(name, price);
        }

        public ContractService AddService(long contractId, long serviceId, long coefId, DateTime date)
        {
            return _contractServicesDao.Create(contractId, serviceId, coefId, date);
        }

        public IEnumerable<Service> GetAll()
        {
            return _serviceDao.GetAll();
        }

        public IEnumerable<ContractService> GetContractServices(long contractId)
        {
            return _contractServicesDao.GetAllByContract(contractId);
        }

        public int Delete(long id)
        {
            return _serviceDao.Delete(id);
        }

        public int DeleteContractService(long contractId, long serviceId)
        {
            return _contractServicesDao.Delete(contractId, serviceId);
        }
    }
}