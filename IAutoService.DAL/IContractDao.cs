using System;
using System.Collections;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IContractDao
    {
        Contract Create(long carId, DateTime startDate);
        IEnumerable<Contract> GetAllByPhone(string phoneNumber);
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetAllOpened();

        IEnumerable<Contract> GetById(long id);
        Contract Update(long contractId, DateTime startDate, DateTime endDate);
        int Delete(long contractId);
        
    }
}