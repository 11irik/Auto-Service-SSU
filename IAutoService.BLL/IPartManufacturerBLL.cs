using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.BLL
{
    public interface IPartManufacturerBLL
    {
        PartManufacturer Create(string name);
        IEnumerable<PartManufacturer> GetAll();
        int Delete(long id);
    }
}