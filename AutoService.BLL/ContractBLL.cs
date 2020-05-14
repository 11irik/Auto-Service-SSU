using System;
using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ContractBLL : IContractBLL
    {
        private IContractDao _dao;

        public ContractBLL()
        {
            _dao = new ContractDao();
        }
        
        public Contract Create(long carId, DateTime startDate)
        {
            return _dao.Create(carId, startDate);
        }

        public IEnumerable<Contract> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(long contractId)
        {
            return _dao.Delete(contractId);
        }
    }
}