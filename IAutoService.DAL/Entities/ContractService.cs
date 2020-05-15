using System;

namespace IAutoService.DAL.Entities
{
    public class ContractService
    {
        private long _contractId;
        private long _serviceId;
        private DateTime _date;
        private long _coefId;
        private string _name;
        private double _price;
        private double _coef;

        public ContractService()
        {
            
        }

        public double Coef
        {
            get => _coef;
            set => _coef = value;
        }

        public long ContractId
        {
            get => _contractId;
            set => _contractId = value;
        }

        public long ServiceId
        {
            get => _serviceId;
            set => _serviceId = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public long CoefId
        {
            get => _coefId;
            set => _coefId = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }
    }
}