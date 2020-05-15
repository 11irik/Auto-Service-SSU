using System;
using System.Collections;
using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ContractBLL : IContractBLL
    {
        private IContractDao _contractDao;
        private IContractServicesDao _contractServicesDao;
        
        public ContractBLL()
        {
            _contractDao = new ContractDao();
            _contractServicesDao = new ContractServicesDao();
        }
        
        public Contract Create(long carId, DateTime startDate)
        {
            return _contractDao.Create(carId, startDate);
        }

        public ContractService AddService(long contractId, long serviceId, long coefId, DateTime date)
        {
            return _contractServicesDao.Create(contractId, serviceId, coefId, date);
        }

        public Contract UpdateDate(long contractId, DateTime startDate, DateTime endDate)
        {
            return _contractDao.Update(contractId, startDate, endDate);
        }

        public double GetContractPrice(long id)
        {
            return _contractServicesDao.GetContractPrice(id);
        }

        public IEnumerable<ContractService> GetContractServices(long contractId)
        {
            return _contractServicesDao.GetAllByContract(contractId);
        }
        public int DeleteContractService(long contractId, long serviceId)
        {
            return _contractServicesDao.Delete(contractId, serviceId);
        }
        
        public IEnumerable<Contract> GetAll()
        {
            return _contractDao.GetAll();
        }
        
        public IEnumerable<Contract> GetAllOpened()
        {
            return _contractDao.GetAllOpened();
        }

        public IEnumerable<Contract> GetById(long id)
        {
            return _contractDao.GetById(id);
        }

        public IEnumerable<Contract> GetAllByPhone(string phone)
        {
            return _contractDao.GetAllByPhone(phone);
        }

        public int Delete(long contractId)
        {
            return _contractDao.Delete(contractId);
        }
    }
}