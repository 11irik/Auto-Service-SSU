using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ClientBLL : IClientBLL
    {
        private IClientDao _dao;

        public ClientBLL()
        {
            _dao = new ClientDao();
        }
        
        public Client Create(string name, string lastName, string phoneNumber)
        {
            return _dao.Create(name, lastName, phoneNumber);
        }

        public Client Get(string phoneNumber)
        {
            return _dao.Get(phoneNumber);
        }

        public IEnumerable<Client> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(string phoneNumber)
        {
            return _dao.Delete(phoneNumber);
        }
    }
}