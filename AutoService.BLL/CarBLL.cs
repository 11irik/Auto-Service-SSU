using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class CarBLL : ICarBLL
    {
        private ICarDao _dao;
        //todo add exception handling
        public CarBLL()
        {
            _dao = new CarDao();
        }
        
        public Car Create(long clientId, string number)
        {
            return _dao.Create(clientId, number);
        }

        public Car Get(string number)
        {
            return _dao.Get(number);
        }

        public IEnumerable<Car> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(string number)
        {
            return _dao.Delete(number);
        }
    }
}