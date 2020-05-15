using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IServiceBLL
    {
        Service Create(string name, double price);
        IEnumerable<Service> GetAll();
        IEnumerable<ContractService> GetContractServices(long contractId);
        public int DeleteContractService(long contractId, long serviceId);
        int Delete(long id);
    }
}