using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class CarPartBLL : ICarPartBLL
    {
        private ICarPartDao _dao;

        //todo add exception handling
        public CarPartBLL()
        {
            _dao = new CarPartDao();
        }
        
        public CarPart Create(string name, long manufacturerId, double price, int stock)
        {
            return _dao.Create(name, manufacturerId, price, stock);
        }

        public IEnumerable<CarPart> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(long id)
        {
            return _dao.Delete(id);
        }
    }
}