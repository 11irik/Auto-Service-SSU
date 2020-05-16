using System.Collections;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IClientBLL
    {
        Client Create(string name, string lastName, string phoneNumber);
        Client Get(string phoneNumber);
        Client Get(long id);
        Client Update(long id, string name, string lastName, string phoneNumber);
        IEnumerable<Client> GetAll();
        IEnumerable<Car> GetClientCars(long clientId);
        int Delete(string phoneNumber);
    }
}