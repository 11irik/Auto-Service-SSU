using System;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IContractServicesDao
    {
        ContractService Create(long contractId, long serviceId, long coefId, DateTime date);
        IEnumerable<ContractService> GetAllByContract(long contractId);
        int Delete(long contractId, long serviceId);
    }
}