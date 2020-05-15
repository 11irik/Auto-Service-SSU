using System.Collections;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace AutoService.PL.Models
{
    public class ClientModel
    {
        public long _id { get; set; }
        public string _phone { get; set; }
        public string _name { get; set; }
        public string _lastName { get; set; }
        public IEnumerable<Car> _car { get; set; }
    }
}