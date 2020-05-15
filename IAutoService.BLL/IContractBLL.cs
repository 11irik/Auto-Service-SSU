using System;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IContractBLL
    {
        Contract Create(long carId, DateTime startDate);
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetAllByPhone(string phone);
        
        int Delete(long contractId);
    }
}