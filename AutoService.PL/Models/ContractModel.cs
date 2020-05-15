using System;
using System.Collections;
using System.Collections.Generic;
using IAutoService.DAL.Entities;

namespace AutoService.PL.Models
{
    public class ContractModel
    {
        public long _id { get; set; }
        public DateTime _startDate { get; set; }
        public DateTime _endDate { get; set; }
        public long _carId { get; set; }
        public IEnumerable<ContractService> _services { get; set; }
        public string _clientLastName { get; set; }
        public string _clientPhone { get; set; }
        public string _clientName { get; set; }
        public double _sum { get; set; }
        public string _carNumber { get; set; }
        public string _brandName { get; set; }
    }
}