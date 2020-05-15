using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class CarBLL : ICarBLL
    {
        private ICarDao _carDao;
        //todo add exception handling
        public CarBLL()
        {
            _carDao = new CarDao();
        }
        
        public Car Create(long clientId, string number, string brand, int manufacturerYear)
        {
            return _carDao.Create(clientId, number, brand, manufacturerYear);
        }

        public Car Get(string number)
        {
            return _carDao.Get(number);
        }

        public Car Get(long id)
        {
            return _carDao.Get(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _carDao.GetAll();
        }

        public int Delete(string number)
        {
            return _carDao.Delete(number);
        }
    }
}