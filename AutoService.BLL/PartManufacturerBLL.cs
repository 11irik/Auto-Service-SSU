using System.Collections.Generic;
using AutoService.DAL;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;

namespace AutoService.BLL
{
    public class PartManufacturerBLL : IPartManufacturerBLL
    {
        private IPartManufacturerDao _dao;

        public PartManufacturerBLL()
        {
            _dao = new PartManufacturerDao();
        }
        
        public PartManufacturer Create(string name)
        {
            return _dao.Create(name);
        }

        public IEnumerable<PartManufacturer> GetAll()
        {
            return _dao.GetAll();
        }

        public int Delete(long id)
        {
            return _dao.Delete(id);
        }
    }
}