using System;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IContractDao
    {
        Contract Create(long carId, DateTime startDate);
        IEnumerable<Contract> GetAll();
        int Delete(long contractId);
        
    }
}