using System;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IClientDao
    {
        Client Create(string name, string lastName, string phoneNumber);
        Client Get(string phoneNumber);
        IEnumerable<Client> GetAll();
        int Delete(string phoneNumber);
    }
}