using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class ClientBLL : IClientBLL
    {
        private IClientDao _clientDao;
        private ICarDao _carDao;

        public ClientBLL()
        {
            _clientDao = new ClientDao();
            _carDao = new CarDao();
        }
        
        public Client Create(string name, string lastName, string phoneNumber)
        {
            return _clientDao.Create(name, lastName, phoneNumber);
        }

        public Client Get(string phoneNumber)
        {
            return _clientDao.Get(phoneNumber);
        }
        
        public Client Get(long id)
        {
            return _clientDao.Get(id);
        }

        public Client Update(long id, string name, string lastName, string phoneNumber)
        {
            return _clientDao.Update(id, name, lastName, phoneNumber);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientDao.GetAll();
        }

        public IEnumerable<Car> GetClientCars(long clientId)
        {
            return _carDao.GetAllByClient(clientId);
        }

        public int Delete(string phoneNumber)
        {
            return _clientDao.Delete(phoneNumber);
        }
    }
}