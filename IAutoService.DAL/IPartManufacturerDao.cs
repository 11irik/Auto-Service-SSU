using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace IAutoService.DAL
{
    public interface IPartManufacturerDao
    {
        PartManufacturer Create(string name);
        IEnumerable<PartManufacturer> GetAll();
        int Delete(long id);
    }
}