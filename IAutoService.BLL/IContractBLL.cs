using System;
using System.Collections;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IContractBLL
    {
        Contract Create(long carId, DateTime startDate);
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetById(long id);
        IEnumerable<Contract> GetAllByPhone(string phone);
        ContractService AddService(long contractId, long serviceId, long coefId, DateTime date);
        int DeleteContractService(long contractId, long serviceId);
        Contract UpdateDate(long contractId, DateTime startDate, DateTime endDate);
        public IEnumerable<Contract> GetAllOpened();
        public double GetContractPrice(long id);
        IEnumerable<ContractService> GetContractServices(long contractId);        
        int Delete(long contractId);
    }
}